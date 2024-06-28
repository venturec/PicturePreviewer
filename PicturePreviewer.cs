using System;
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
            files = UtilityClass.getDirectoryFiles(this.folderPath, this.getFromSubfolders);

            String userProfileDirectory = System.Environment.GetEnvironmentVariable("USERPROFILE");
            XmlDocument xd = new XmlDocument();
            xd.Load(userProfileDirectory + "\\AppData\\Roaming\\PicturePreviewer\\FileFlags.xml");
            XmlNodeList bookmarks = xd.GetElementsByTagName("bookmark");

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

                if (sfd.FileName != "")
                {
                    FileStream fsOrig = new FileStream(this.pbPreview.ImageLocation, FileMode.Open);
                    FileStream fsNew = new FileStream(sfd.FileName, FileMode.Create);
                    fsOrig.CopyTo(fsNew);

                    fsOrig.Close();
                    fsNew.Close();
                }

                DialogResult drDelete = MessageBox.Show("Would you like to delete the the original file?", "Delete Original File", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // Check if the New file exists first and then proceed with the delete if the user clicks Yes in the MessageBox
                if (drDelete == DialogResult.Yes
                    && File.Exists(sfd.FileName))
                {
                    File.Delete(this.pbPreview.ImageLocation);

                    if (this.pictureArray > 0)
                    {
                        this.pictureArray = this.pictureArray - 1;
                    }

                    getAllFiles();
                }
            }
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
            Debug.WriteLine("");
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

    }
}
