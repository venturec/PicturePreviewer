namespace PicturePreviewer
{
    partial class PicturePreviewLanding
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PicturePreviewLanding));
            this.btnPreview = new System.Windows.Forms.Button();
            this.tbPictureFolder = new System.Windows.Forms.TextBox();
            this.lblSelectFolder = new System.Windows.Forms.Label();
            this.cbGetFromSubDirectories = new System.Windows.Forms.CheckBox();
            this.btnRenameFiles = new System.Windows.Forms.Button();
            this.btnGoToBookmark = new System.Windows.Forms.Button();
            this.btnReview = new System.Windows.Forms.Button();
            this.tvFoldersAndFiles = new System.Windows.Forms.TreeView();
            this.btnCaptureScreen = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnResequenceFileNumbers = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPreview
            // 
            this.btnPreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreview.Location = new System.Drawing.Point(12, 66);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(151, 32);
            this.btnPreview.TabIndex = 3;
            this.btnPreview.Text = "Preview";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // tbPictureFolder
            // 
            this.tbPictureFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPictureFolder.Location = new System.Drawing.Point(123, 24);
            this.tbPictureFolder.Name = "tbPictureFolder";
            this.tbPictureFolder.Size = new System.Drawing.Size(609, 23);
            this.tbPictureFolder.TabIndex = 1;
            this.tbPictureFolder.DoubleClick += new System.EventHandler(this.tbPictureFolder_DoubleClick);
            // 
            // lblSelectFolder
            // 
            this.lblSelectFolder.AutoSize = true;
            this.lblSelectFolder.Location = new System.Drawing.Point(9, 27);
            this.lblSelectFolder.Name = "lblSelectFolder";
            this.lblSelectFolder.Size = new System.Drawing.Size(69, 13);
            this.lblSelectFolder.TabIndex = 0;
            this.lblSelectFolder.Text = "Select Folder";
            // 
            // cbGetFromSubDirectories
            // 
            this.cbGetFromSubDirectories.AutoSize = true;
            this.cbGetFromSubDirectories.Location = new System.Drawing.Point(772, 27);
            this.cbGetFromSubDirectories.Name = "cbGetFromSubDirectories";
            this.cbGetFromSubDirectories.Size = new System.Drawing.Size(165, 17);
            this.cbGetFromSubDirectories.TabIndex = 2;
            this.cbGetFromSubDirectories.Text = "Get Files from Sub-Directories";
            this.cbGetFromSubDirectories.UseVisualStyleBackColor = true;
            // 
            // btnRenameFiles
            // 
            this.btnRenameFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRenameFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRenameFiles.Location = new System.Drawing.Point(995, 167);
            this.btnRenameFiles.Name = "btnRenameFiles";
            this.btnRenameFiles.Size = new System.Drawing.Size(151, 32);
            this.btnRenameFiles.TabIndex = 10;
            this.btnRenameFiles.Text = "Rename Files";
            this.btnRenameFiles.UseVisualStyleBackColor = true;
            this.btnRenameFiles.Click += new System.EventHandler(this.btnRenameFiles_Click);
            // 
            // btnGoToBookmark
            // 
            this.btnGoToBookmark.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGoToBookmark.Location = new System.Drawing.Point(12, 104);
            this.btnGoToBookmark.Name = "btnGoToBookmark";
            this.btnGoToBookmark.Size = new System.Drawing.Size(151, 32);
            this.btnGoToBookmark.TabIndex = 4;
            this.btnGoToBookmark.Text = "Go To Bookmark";
            this.btnGoToBookmark.UseVisualStyleBackColor = true;
            this.btnGoToBookmark.Click += new System.EventHandler(this.btnGoToBookmark_Click);
            // 
            // btnReview
            // 
            this.btnReview.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReview.Location = new System.Drawing.Point(12, 142);
            this.btnReview.Name = "btnReview";
            this.btnReview.Size = new System.Drawing.Size(151, 30);
            this.btnReview.TabIndex = 5;
            this.btnReview.Text = "Filter on Review";
            this.btnReview.UseVisualStyleBackColor = true;
            this.btnReview.Click += new System.EventHandler(this.btnReview_Click);
            // 
            // tvFoldersAndFiles
            // 
            this.tvFoldersAndFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvFoldersAndFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvFoldersAndFiles.Location = new System.Drawing.Point(12, 205);
            this.tvFoldersAndFiles.Name = "tvFoldersAndFiles";
            this.tvFoldersAndFiles.Size = new System.Drawing.Size(1134, 671);
            this.tvFoldersAndFiles.TabIndex = 7;
            this.tvFoldersAndFiles.DoubleClick += new System.EventHandler(this.tvFoldersAndFiles_DoubleClick);
            // 
            // btnCaptureScreen
            // 
            this.btnCaptureScreen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCaptureScreen.Location = new System.Drawing.Point(995, 24);
            this.btnCaptureScreen.Name = "btnCaptureScreen";
            this.btnCaptureScreen.Size = new System.Drawing.Size(151, 52);
            this.btnCaptureScreen.TabIndex = 8;
            this.btnCaptureScreen.Text = "Capture Screen";
            this.btnCaptureScreen.UseVisualStyleBackColor = true;
            this.btnCaptureScreen.Click += new System.EventHandler(this.btnCaptureScreen_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(201, 142);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(151, 30);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnResequenceFileNumbers
            // 
            this.btnResequenceFileNumbers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResequenceFileNumbers.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResequenceFileNumbers.Location = new System.Drawing.Point(995, 129);
            this.btnResequenceFileNumbers.Name = "btnResequenceFileNumbers";
            this.btnResequenceFileNumbers.Size = new System.Drawing.Size(151, 32);
            this.btnResequenceFileNumbers.TabIndex = 9;
            this.btnResequenceFileNumbers.Text = "Resequence File Numbers";
            this.btnResequenceFileNumbers.UseVisualStyleBackColor = true;
            this.btnResequenceFileNumbers.Click += new System.EventHandler(this.btnResequenceFileNumbers_Click);
            // 
            // PicturePreviewLanding
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1158, 888);
            this.Controls.Add(this.btnResequenceFileNumbers);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnCaptureScreen);
            this.Controls.Add(this.tvFoldersAndFiles);
            this.Controls.Add(this.btnReview);
            this.Controls.Add(this.btnGoToBookmark);
            this.Controls.Add(this.btnRenameFiles);
            this.Controls.Add(this.cbGetFromSubDirectories);
            this.Controls.Add(this.lblSelectFolder);
            this.Controls.Add(this.tbPictureFolder);
            this.Controls.Add(this.btnPreview);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PicturePreviewLanding";
            this.Text = "Landing Page";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.TextBox tbPictureFolder;
        private System.Windows.Forms.Label lblSelectFolder;
        private System.Windows.Forms.CheckBox cbGetFromSubDirectories;
        private System.Windows.Forms.Button btnRenameFiles;
        private System.Windows.Forms.Button btnGoToBookmark;
        private System.Windows.Forms.Button btnReview;
        private System.Windows.Forms.TreeView tvFoldersAndFiles;
        private System.Windows.Forms.Button btnCaptureScreen;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnResequenceFileNumbers;
    }
}

