using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace PicturePreviewer
{
    public partial class PicturePreviewLanding : Form
    {
        public PicturePreviewLanding()
        {
            InitializeComponent();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (this.tbPictureFolder.Text == "")
            {
                MessageBox.Show("Please select a folder where the pictures are stored");
            }
            else
            {
                PicturePreviewer pp = new PicturePreviewer();

                if (this.tvFoldersAndFiles.SelectedNode == null)
                {
                    pp.folderPath = this.tbPictureFolder.Text;
                    pp.getFromSubfolders = true;
                    pp.loadingFiles = true;
                    pp.getAllFiles();
                    pp.loadingFiles = false;
                }
                else
                {
                    pp.folderPath = this.tbPictureFolder.Text + "\\" + this.tvFoldersAndFiles.SelectedNode.Text;
                    pp.getFromSubfolders = this.cbGetFromSubDirectories.Checked;
                    pp.loadingFiles = true;
                    pp.getAllFiles();
                    pp.loadingFiles = false;
                }

                pp.Show();
            }
        }

        private void tbPictureFolder_DoubleClick(object sender, EventArgs e)
        {
            String folderPath = UtilityClass.folderBrowserSelectPath("Select Project Folder",
                                                                             false,
                                                                             FolderEnum.ReadFrom,
                                                                             Properties.Settings.Default.LastFolderLocation);
            this.populateTreeView(folderPath);
        }

        private void populateTreeView(String folderPath)
        {
            HashSet<String> mainFolderNames = new HashSet<string>();
            Dictionary<String, TreeNode> tnListAddDependencies = new Dictionary<String, TreeNode>();
            Dictionary<String, TreeNode> tnListRemoveDependencies = new Dictionary<String, TreeNode>();

            if (folderPath != "")
            {
                this.tbPictureFolder.Text = folderPath;

                Properties.Settings.Default.LastFolderLocation = this.tbPictureFolder.Text;
                Properties.Settings.Default.Save();
            }


            if (this.tbPictureFolder.Text != null
                && this.tbPictureFolder.Text != "")
            {
                this.tvFoldersAndFiles.Nodes.Clear();

                String[] subfoldersfolders = Directory.GetDirectories(this.tbPictureFolder.Text);

                String[] folders = new string[subfoldersfolders.Length + 1];
                folders[0] = this.tbPictureFolder.Text;
                Array.Copy(subfoldersfolders, 0, folders, 1, subfoldersfolders.Length);

                foreach (String folderName in folders)
                {
                    String[] folderNameSplit = folderName.Split('\\');
                    String[] fileNames = Directory.GetFiles(folderName);

                    TreeNode tnd1 = new TreeNode(folderNameSplit[folderNameSplit.Length - 1]);
                    mainFolderNames.Add(tnd1.Text);

                    foreach (String fileName in fileNames)
                    {
                        String[] fileNameSplit = fileName.Split('\\');
                        String[] objectNameSplit = fileNameSplit[fileNameSplit.Length - 1].Split('.');
                        TreeNode tnd2 = new TreeNode(fileNameSplit[fileNameSplit.Length - 1]);
                        tnd1.Nodes.Add(tnd2);
                    }

                    this.tvFoldersAndFiles.Nodes.Add(tnd1);
                }

            }
        }

        private void btnRenameFiles_Click(object sender, EventArgs e)
        {
            // Get all files in the selected folder only. Ignore the Get Files from Sub-Directories
            // Create the data set and pass this into RenameFiles object

            if (this.tbPictureFolder.Text != "")
            {
                String[] files = UtilityClass.getDirectoryFiles(this.tbPictureFolder.Text, false);

                Int32 fileCount = files.Length;

                RenameFiles rf = new RenameFiles();
                rf.folderPath = this.tbPictureFolder.Text;
                rf.filesArray = files;

                rf.populateDataGrid();
                rf.Show();
            }
        }

        private void btnGoToBookmark_Click(object sender, EventArgs e)
        {
            if (this.tbPictureFolder.Text == "")
            {
                MessageBox.Show("Please select a folder where the pictures are stored");
            }
            else
            {
                PicturePreviewer pp = new PicturePreviewer();
                pp.folderPath = this.tbPictureFolder.Text;
                pp.getFromSubfolders = this.cbGetFromSubDirectories.Checked;
                pp.loadingFiles = true;
                pp.goToBookmark();
                pp.loadingFiles = false;

                pp.Show();
            }
        }

        private void btnReview_Click(object sender, EventArgs e)
        {
            PicturePreviewer pp = new PicturePreviewer();
            pp.folderPath = this.tbPictureFolder.Text;
            pp.loadingFiles = true;
            pp.filterOnReview();
            pp.loadingFiles = false;

            pp.Show();
        }


        // The following methods will all fail if there are pictures within folders of folders and the the folder is high-lighted
        // Still need to figure out a good way to bypass a folder selection and just determine if the item selected is an actual image file or just a folder or other binary file.
        //private void tvFoldersAndFiles_NodeMouseHover(object sender, TreeNodeMouseHoverEventArgs e)
        //{
        //    TreeView tv = (TreeView)sender;
        //    TreeNodeMouseHoverEventArgs args = (TreeNodeMouseHoverEventArgs)e;

        //    if (args.Node.Parent != null)
        //    {
        //        String[] folderPathSplit = this.tbPictureFolder.Text.Split('\\');
        //        String[] nodeFullPath = args.Node.FullPath.Split('\\');

        //        String nodePath = "";

        //        if (nodeFullPath[0] == folderPathSplit[folderPathSplit.Length - 1])
        //        {
        //            for(Int32 i = 0; i < nodeFullPath.Length; i++)
        //            {
        //                if (i > 0)
        //                {
        //                    nodePath += nodeFullPath[i] + "\\";
        //                }
        //            }

        //            nodePath = nodePath.Remove(nodePath.Length - 1);
        //        }
        //        else
        //        {
        //            nodePath = args.Node.FullPath;
        //        }

        //        if (checkFormOpen())
        //        {
        //            updateOpenQuickViews(this.tbPictureFolder.Text + "\\" + nodePath);
        //        }
        //        else
        //        {
        //            QuickPreview qp = new QuickPreview();
        //            qp.setPreviewPath(this.tbPictureFolder.Text + "\\" + nodePath);
        //            qp.Show();
        //        }
        //    }
        //}

        private void tvFoldersAndFiles_DoubleClick(object sender, EventArgs e)
        {
            System.Windows.Forms.MouseEventArgs evtArgs = (System.Windows.Forms.MouseEventArgs)e;

            if (evtArgs.Button == MouseButtons.Left)
            {
                TreeView tv = (TreeView)sender;

                if (tv.SelectedNode.Parent != null)
                {

                    String[] folderPathSplit = this.tbPictureFolder.Text.Split('\\');
                    String[] nodeFullPath = tv.SelectedNode.FullPath.Split('\\');

                    String nodePath = "";

                    if (nodeFullPath[0] == folderPathSplit[folderPathSplit.Length - 1])
                    {
                        for (Int32 i = 0; i < nodeFullPath.Length; i++)
                        {
                            if (i > 0)
                            {
                                nodePath += nodeFullPath[i] + "\\";
                            }
                        }

                        nodePath = nodePath.Remove(nodePath.Length - 1);
                    }
                    else
                    {
                        nodePath = tv.SelectedNode.FullPath;
                    }

                    // Was a top level (folder) node clicked or an individual picture
                    if (tv.SelectedNode != null && tv.SelectedNode.Nodes.Count > 0)
                    {
                        PicturePreviewer pp = new PicturePreviewer();
                        pp.folderPath = this.tbPictureFolder.Text + "\\" + nodePath;
                        pp.getFromSubfolders = true;
                        pp.loadingFiles = true;
                        pp.getAllFiles();
                        pp.loadingFiles = false;

                        pp.Show();
                    }
                    else
                    {
                        PicturePreviewer pp = new PicturePreviewer();
                        pp.files = new string[1];
                        pp.files[0] = this.tbPictureFolder.Text + "\\" + nodePath;
                        pp.getImageLocation();
                        pp.Show();
                    }
                }
            }
        }

        //private void tvFoldersAndFiles_AfterSelect(object sender, TreeViewEventArgs e)
        //{
        //    TreeView tv = (TreeView)sender;

        //    if (tv.SelectedNode.Parent != null)
        //    {
        //        String[] folderPathSplit = this.tbPictureFolder.Text.Split('\\');
        //        String[] nodeFullPath = tv.SelectedNode.FullPath.Split('\\');

        //        String nodePath = "";
        //        if (nodeFullPath[0] == folderPathSplit[folderPathSplit.Length - 1])
        //        {
        //            for (Int32 i = 0; i < nodeFullPath.Length; i++)
        //            {
        //                if (i > 0)
        //                {
        //                    nodePath += nodeFullPath[i] + "\\";
        //                }
        //            }

        //            nodePath = nodePath.Remove(nodePath.Length - 1);
        //        }
        //        else
        //        {
        //            nodePath = tv.SelectedNode.FullPath;
        //        }

        //        if (checkFormOpen())
        //        {
        //            try
        //            {
        //                updateOpenQuickViews(this.tbPictureFolder.Text + "\\" + nodePath);
        //            }
        //            catch (Exception exc1)
        //            {
        //                // Don't care
        //            }
        //        }
        //        else
        //        {
        //            try
        //            {
        //                QuickPreview qp = new QuickPreview();
        //                qp.setPreviewPath(this.tbPictureFolder.Text + "\\" + nodePath);
        //                qp.Show();
        //            }
        //            catch (Exception exc1)
        //            {
        //                // Don't care
        //            }
        //        }
        //    }
        //}

        private void btnCaptureScreen_Click(object sender, EventArgs e)
        {

        }

        /*
        private void tvFoldersAndFiles_NodeSelect(object sender, TreeNode e)
        {
            TreeView tv = (TreeView)sender;
            TreeNodeMouseHoverEventArgs args = (TreeNodeMouseHoverEventArgs)e;

            if (args.Node.Parent != null)
            {
                if (checkFormOpen())
                {
                    updateOpenQuickViews(this.tbPictureFolder.Text + "\\" + args.Node.FullPath);
                }
                else
                {
                    QuickPreview qp = new QuickPreview();
                    qp.setPreviewPath(this.tbPictureFolder.Text + "\\" + args.Node.FullPath);
                    qp.Show();
                }
            }
        }
        */

        private Boolean checkFormOpen()
        {
            Boolean formOpen = false;

            FormCollection fc = Application.OpenForms;
            if (fc.Count > 0)
            {
                foreach (Form frm in fc)
                {
                    if (frm.Name == "QuickPreview")
                    {
                        formOpen = true;
                    }
                }
            }

            return formOpen;
        }

        private void updateOpenQuickViews(String picturePath)
        {
            FormCollection fc = Application.OpenForms;
            if (fc.Count > 0)
            {
                foreach (Form frm in fc)
                {
                    if (frm.Name == "QuickPreview")
                    {
                        QuickPreview qp = (QuickPreview)frm;
                        foreach (Control frmCtrl in qp.Controls)
                        {
                            if (frmCtrl.Name == "pbPreview")
                            {
                                PictureBox pBox = (PictureBox)frmCtrl;
                                pBox.ImageLocation = picturePath;
                            }
                        }
                    }
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.populateTreeView(this.tbPictureFolder.Text);
        }

        private void btnResequenceFileNumbers_Click(object sender, EventArgs e)
        {
            if (this.tbPictureFolder.Text == null
                || this.tbPictureFolder.Text == "")
            {
                return;
            }

            // Get all files in the subfolder. Do not traverse folders within folders as this could mess up the numbering sequence
            Int32 fileNumber = 1;
            String[] folderFiles = Directory.GetFiles(this.tbPictureFolder.Text);

            if (folderFiles.Length > 0)
            {
                List<Int32> fileIds = new List<Int32>();

                foreach (String fn in folderFiles)
                {
                    String[] filePathSplit = fn.Split('\\');
                    String fileName = filePathSplit[filePathSplit.Length - 1];

                    String[] fileNameSplit = fileName.Split('.');

                    // Now get the numeric character(s) from the file name and compare to fileNumber to determine if it is out of sequence
                    // Examples: Question1.png, Question26.png, Question104.png, 
                    Char[] fnCharArray = fileNameSplit[0].ToCharArray();

                    String tempFileNumber = "";

                    for (Int32 i = 8; i < fnCharArray.Length; i++)
                    {
                        tempFileNumber = tempFileNumber + fnCharArray[i].ToString();
                    }

                    fileIds.Add(Convert.ToInt32(tempFileNumber));
                }

                fileIds.Sort();

                for (Int32 i = 0; i < fileIds.Count; i++) 
                {
                    if (fileIds[i] != fileNumber)
                    {
                        // Get the original file and copy it with the new name, then delete the old one
                        foreach (String fn in folderFiles)
                        {
                            String[] filePathSplit = fn.Split('\\');
                            String fileName = filePathSplit[filePathSplit.Length - 1];

                            String[] fileNameSplit = fileName.Split('.');

                            // Now get the numeric character(s) from the file name and compare to fileNumber to determine if it is out of sequence
                            // Examples: Question1.png, Question26.png, Question104.png, 
                            Char[] fnCharArray = fileNameSplit[0].ToCharArray();

                            String tempFileNumber = "";

                            for (Int32 j = 8; j < fnCharArray.Length; j++)
                            {
                                tempFileNumber = tempFileNumber + fnCharArray[j].ToString();
                            }

                            if (Convert.ToInt32(tempFileNumber) == fileIds[i])
                            {
                                // Build the new file name with the new sequenced number
                                String newFileName = filePathSplit[0];
                                for (Int32 j = 1; j < filePathSplit.Length - 1; j++)
                                {
                                    newFileName = newFileName + "\\" + filePathSplit[j];
                                }

                                newFileName = newFileName + "\\Question" + fileNumber.ToString() + ".png";

                                File.Copy(fn, newFileName, false);

                                File.Delete(fn);

                                break;
                            }
                        }
                    }

                    fileNumber++;
                }
            }
        }

        //private void CaptureMyScreen()
        //{
        //    try
        //    {
        //        //Creating a new Bitmap object
        //        Bitmap captureBitmap = new Bitmap(1024, 768, PixelFormat.Format32bppArgb);
        //        //Bitmap captureBitmap = new Bitmap(int width, int height, PixelFormat);
        //        //Creating a Rectangle object which will
        //        //capture our Current Screen
        //        Rectangle captureRectangle = Screen.AllScreens[0].Bounds;
        //        //Creating a New Graphics Object
        //        Graphics captureGraphics = Graphics.FromImage(captureBitmap);
        //        //Copying Image from The Screen
        //        captureGraphics.CopyFromScreen(captureRectangle.Left, captureRectangle.Top, 0, 0, captureRectangle.Size);
        //        //Saving the Image File (I am here Saving it in My E drive).
        //        captureBitmap.Save(@"E:\Capture.jpg", ImageFormat.Jpeg);
        //        //Displaying the Successfull Result
        //        //MessageBox.Show("Screen Captured");
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}
    }
}
