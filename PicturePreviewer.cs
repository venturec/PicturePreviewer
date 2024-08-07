﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Forms;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.CompilerServices;

namespace PicturePreviewer
{
    public partial class PicturePreviewer : Form
    {
        public String folderPath;
        public Boolean getFromSubfolders = false;

        public Boolean loadingFiles = false;

        private Int32 pictureArray = 0;

        public String[] files;
        public PicturePreviewer()
        {
            InitializeComponent();
        }

        public void getAllFiles()
        {
            files = UtilityClass.getDirectoryFiles(this.folderPath, this.getFromSubfolders);
            getImageLocation();
        }

        public void goToBookmark()
        {
            String userProfileDirectory = System.Environment.GetEnvironmentVariable("USERPROFILE");
            XmlDocument xd = new XmlDocument();
            xd.Load(userProfileDirectory + "\\AppData\\Roaming\\PicturePreviewer\\FileFlags.xml");
            XmlNodeList bookmarks = xd.GetElementsByTagName("bookmark");

            String bookmarkedLocation = bookmarks[0].InnerText;
            String[] bookmarkSplit = bookmarks[0].InnerText.Split('\\');

            this.folderPath = bookmarkSplit[0];

            for (Int32 i = 1; i < bookmarkSplit.Length - 1; i++)
            {
                this.folderPath = this.folderPath + "\\" + bookmarkSplit[i];
            }

            this.getFromSubfolders = false;

            files = UtilityClass.getDirectoryFiles(this.folderPath, this.getFromSubfolders);

            for (Int32 i = 0; i < files.Length; i++)
            {
                if (files[i] == bookmarks[0].ChildNodes[0].InnerText)
                {
                    pictureArray = i;
                    break;
                }
            }
            
            getImageLocation();
        }

        public void filterOnReview()
        {
            String userProfileDirectory = System.Environment.GetEnvironmentVariable("USERPROFILE");
            XmlDocument xd = new XmlDocument();
            xd.Load(userProfileDirectory + "\\AppData\\Roaming\\PicturePreviewer\\FileFlags.xml");
            XmlNodeList fileflags = xd.GetElementsByTagName("fileflag");

            List<String> filepaths = new List<string>();
            foreach (XmlNode ff in fileflags)
            {
                filepaths.Add(ff.ChildNodes[0].InnerText);
            }

            files = filepaths.ToArray();

            getImageLocation();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            this.pbPreview.Image = null;
            this.pbPreview.ImageLocation = null;

            if (pictureArray == files.Length - 1)
            {
                pictureArray = 0;
            }
            else
            {
                pictureArray = pictureArray + 1;
            }

            loadingFiles = true;
            
            getImageLocation();

            loadingFiles = false;
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            this.pbPreview.Image = null;
            this.pbPreview.ImageLocation = null;

            if (pictureArray == 0)
            {
                pictureArray = files.Length - 1;
            }
            else 
            {
                pictureArray = pictureArray - 1;
            }

            loadingFiles = true;

            getImageLocation();

            loadingFiles = false;
        }

        private void btnImgSizeInc_Click(object sender, EventArgs e)
        {
            Int32 h = this.pbPreview.Height;
            Int32 w = this.pbPreview.Width;

            this.pbPreview.Size = new System.Drawing.Size(w + 100, h + 100);
        }

        private void btnSaveTo_Click(object sender, EventArgs e)
        {
            String folderPath = UtilityClass.folderBrowserSelectPath("Please select a folder to save the image to", true, FolderEnum.SaveTo, Properties.Settings.Default.LastFolderMoveToLocation);

            if (folderPath != "")
            {
                Properties.Settings.Default.LastFolderMoveToLocation = folderPath;
                Properties.Settings.Default.Save();

                String[] fileNameParse = this.pbPreview.ImageLocation.Split('\\');

                String fileName = fileNameParse[fileNameParse.Length - 1];

                SaveFileDialog sfd = new SaveFileDialog();
                sfd.InitialDirectory = folderPath;
                sfd.FileName = fileName;
                sfd.ShowDialog();

                Boolean fileCopiedSuccessfully = false;

                if (sfd.FileName != "")
                {
                    // Check if file is locked first
                    FileInfo fi = new FileInfo(this.pbPreview.ImageLocation);
                    Boolean fileIsLocked = this.isFileLocked(fi);

                    if (fileIsLocked == true)
                    {
                        MessageBox.Show("File is being used by another process. Please try again.", "File Locked", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        FileStream fsOrig = new FileStream(this.pbPreview.ImageLocation, FileMode.Open);
                        FileStream fsNew = new FileStream(sfd.FileName, FileMode.Create);
                        fsOrig.CopyTo(fsNew);

                        fsOrig.Close();
                        fsNew.Close();

                        while (File.Exists(sfd.FileName) == false)
                        {
                            // do nothing
                        }

                        if (File.Exists(sfd.FileName))
                        {
                            fileCopiedSuccessfully = true;
                        }
                    }
                }

                if (fileCopiedSuccessfully == true)
                {
                    DialogResult drDelete = MessageBox.Show("Would you like to delete the the original file?", "Delete Original File", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    // Check if the New file exists first and then proceed with the delete if the user clicks Yes in the MessageBox
                    if (drDelete == DialogResult.Yes)
                    {
                        if (this.pictureArray > 0)
                        {
                            this.pictureArray = this.pictureArray - 1;
                        }

                        File.Delete(this.pbPreview.ImageLocation);

                        getAllFiles();
                    }
                }
            }
        }

        private Boolean isFileLocked(FileInfo file)
        {
            try
            {
                using (FileStream stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    stream.Close();
                }
            }
            catch (IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }

            //file is not locked
            return false;
        }

        public void getImageLocation()
        {
            if (files.Length == 0)
            {
                this.pbPreview.ImageLocation = "";
                this.tbCategory.Text = "";
                this.tbRecordNumberOf.Text = "Record Number: 0 of 0";
            }
            else if (files.Length > 0)
            {
                String imgLocation = files[pictureArray];

                setReviewValue(imgLocation);

                String[] imgLocationSplit = imgLocation.Split('\\');

                //Bitmap bmp = new Bitmap(imgLocation);
                this.pbPreview.ImageLocation = imgLocation;
                //this.pbPreview.SizeMode = PictureBoxSizeMode.Zoom;
                //this.pbPreview.Image = new Bitmap(bmp);

                this.tbCategory.Text = imgLocationSplit[imgLocationSplit.Length - 2];
                this.tbRecordNumberOf.Text = "Record Number: " + (pictureArray + 1).ToString() + " of " + (files.Length).ToString();
                this.lblFileName.Text = imgLocationSplit[imgLocationSplit.Length - 1];

                this.resetPictureSize();
            }
        }

        private void cbReview_CheckedChanged(object sender, EventArgs e)
        {
            if (this.loadingFiles == true) return;

            String userProfileDirectory = System.Environment.GetEnvironmentVariable("USERPROFILE");
            XmlDocument xd = new XmlDocument();
            xd.Load(userProfileDirectory + "\\AppData\\Roaming\\PicturePreviewer\\FileFlags.xml");

            if (this.cbReview.Checked == true)
            {
                XmlElement fileflag = xd.CreateElement("fileflag");
                XmlElement filepath = xd.CreateElement("filepath");
                XmlElement review = xd.CreateElement("review");

                filepath.InnerText = this.pbPreview.ImageLocation;
                review.InnerText = "true";

                fileflag.AppendChild(filepath);
                fileflag.AppendChild(review);

                xd.DocumentElement.AppendChild(fileflag);
                xd.Save(userProfileDirectory + "\\AppData\\Roaming\\PicturePreviewer\\FileFlags.xml");
            }
            else if (this.cbReview.Checked == false)
            {
                XmlNodeList fileFlags = xd.GetElementsByTagName("fileflags");
                XmlNodeList flNodeList = xd.GetElementsByTagName("fileflag");

                for (Int32 i = 0; i < flNodeList.Count; i++)
                {
                    String filePath = flNodeList[i].ChildNodes[0].InnerText;

                    if (filePath == this.pbPreview.ImageLocation)
                    {
                        fileFlags[0].RemoveChild(flNodeList[i]);
                        xd.Save(userProfileDirectory + "\\AppData\\Roaming\\PicturePreviewer\\FileFlags.xml");
                        break;
                    }
                }
            }
        }

        private void setReviewValue(String imgLocation)
        {
            String userProfileDirectory = System.Environment.GetEnvironmentVariable("USERPROFILE");

            XmlDocument xd = new XmlDocument();

            if (Directory.Exists(userProfileDirectory + "\\AppData\\Roaming\\PicturePreviewer"))
            {
                if (File.Exists(userProfileDirectory + "\\AppData\\Roaming\\PicturePreviewer\\FileFlags.xml"))
                {
                    xd.Load(userProfileDirectory + "\\AppData\\Roaming\\PicturePreviewer\\FileFlags.xml");
                }
            }
            else
            {
                DirectoryInfo di = Directory.CreateDirectory(userProfileDirectory + "\\AppData\\Roaming\\PicturePreviewer");
                StreamWriter sw = new StreamWriter(di.FullName + "\\FileFlags.xml");

                sw.Write("<fileflags>" +
                    "<bookmark>" + 
                    "<filepath></filepath>" + 
                    "</bookmark>" + 
                    "</fileflags>");

                sw.Close();

                xd.Load(userProfileDirectory + "\\AppData\\Roaming\\PicturePreviewer\\FileFlags.xml");
            }

            XmlNodeList ndList = xd.GetElementsByTagName("fileflag");

            this.loadingFiles = true;

            foreach (XmlNode nd in ndList)
            {
                String xmlPath = nd.ChildNodes[0].InnerText;

                if (xmlPath == imgLocation
                    && nd.ChildNodes[1].InnerText == "true")
                {
                    this.cbReview.Checked = true;
                    break;
                }
                else
                {
                    this.cbReview.Checked = false;
                }
            }

            this.loadingFiles = false;
        }

        private void btnBookmark_Click(object sender, EventArgs e)
        {
            if (this.loadingFiles == true) return;

            bookmarkLastLocation();
        }

        //private void PicturePreviewer_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    DialogResult dres = MessageBox.Show("Would you like to pick up where you left off on your next session?", "Bookmark Last Position", MessageBoxButtons.YesNo);

        //    if (dres == DialogResult.Yes) 
        //    {
        //        bookmarkLastLocation();
        //    }
        //}

        private void bookmarkLastLocation()
        {
            String userProfileDirectory = System.Environment.GetEnvironmentVariable("USERPROFILE");
            XmlDocument xd = new XmlDocument();
            xd.Load(userProfileDirectory + "\\AppData\\Roaming\\PicturePreviewer\\FileFlags.xml");

            XmlNodeList fileFlags = xd.GetElementsByTagName("fileflags");
            XmlNodeList bookmarks = xd.GetElementsByTagName("bookmark");
            
            if (bookmarks.Count > 0)
            {
                fileFlags[0].RemoveChild(bookmarks[0]);
            }

            XmlElement bookmark = xd.CreateElement("bookmark");
            XmlElement filepath = xd.CreateElement("filepath");

            filepath.InnerText = this.pbPreview.ImageLocation;

            bookmark.AppendChild(filepath);

            xd.DocumentElement.AppendChild(bookmark);

            xd.Save(userProfileDirectory + "\\AppData\\Roaming\\PicturePreviewer\\FileFlags.xml");
        }

        private void cbFullSizePicture_CheckedChanged(object sender, EventArgs e)
        {
            resetPictureSize();
        }

        private void resetPictureSize()
        {
            if (this.cbFullSizePicture.Checked == true)
            {
                String imgLocation = files[pictureArray];
                Bitmap bmp = new Bitmap(imgLocation);
                this.pbPreview.SizeMode = PictureBoxSizeMode.AutoSize;
                this.pbPreview.Image = new Bitmap(bmp);
            }
            else
            {
                String imgLocation = files[pictureArray];
                Bitmap bmp = new Bitmap(imgLocation);
                this.pbPreview.SizeMode = PictureBoxSizeMode.Zoom;
                this.pbPreview.Image = new Bitmap(bmp);
            }
        }

        private void PicturePreviewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult bookmarkThis = MessageBox.Show("Would you like to bookmark the last image before closing?", "Bookmark This File", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Check if the New file exists first and then proceed with the delete if the user clicks Yes in the MessageBox
            if (bookmarkThis == DialogResult.Yes)
            {
                this.bookmarkLastLocation();
            }
        }

        // This is way to big for tonight
        // If you delete a picture while in the previewer, then you also have to consider deleting the bookmarks as well
        // Will just manually delete the picture for now and come back to this.
        // Plus there are problems when deleting an image shown in the Picture Previewer anyway which looks like have not been resolved.
        // May try .Net 8.0 CORE to see if the issue is fixed there or find some other alternative method
        // Still can't figure out why this does not work, but the Save As DOES work when asking whether to delete the original image or not.
        //private void btnDelete_Click(object sender, EventArgs e)
        //{
        //    DialogResult drDelete = MessageBox.Show("Would you like to delete the the original file?", "Delete Original File", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        //    // Check if the New file exists first and then proceed with the delete if the user clicks Yes in the MessageBox
        //    if (drDelete == DialogResult.Yes)
        //    {
        //        // There is a known bug with PictureBoxPreview where the dispose() and setting Image / Image location to null does not work
        //        // Using this as a work-around
        //        String fileToDel = this.pbPreview.ImageLocation;
        //        String folderPath = this.folderPath;
        //        Int32 prevPictureArray = 0;

        //        if (pictureArray == 0)
        //        {
        //            prevPictureArray = 0;
        //        }
        //        else
        //        {
        //            prevPictureArray = pictureArray - 1;
        //        }

        //        this.Close();

        //        File.Delete(fileToDel);

        //        PicturePreviewer pp = new PicturePreviewer();
        //        pp.folderPath = folderPath;
        //        pp.pictureArray = prevPictureArray;

        //        this.Show();
        //    }
        //}
    }
}
