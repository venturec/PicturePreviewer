namespace PicturePreviewer
{
    partial class PicturePreviewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PicturePreviewer));
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.tbRecordNumberOf = new System.Windows.Forms.TextBox();
            this.btnSaveTo = new System.Windows.Forms.Button();
            this.lblFileNumberOf = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.tbCategory = new System.Windows.Forms.TextBox();
            this.cbReview = new System.Windows.Forms.CheckBox();
            this.btnBookmark = new System.Windows.Forms.Button();
            this.lblFileName = new System.Windows.Forms.Label();
            this.pbPreview = new System.Windows.Forms.PictureBox();
            this.flowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.cbFullSizePicture = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).BeginInit();
            this.flowPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Font = new System.Drawing.Font("Showcard Gothic", 45F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnNext.Location = new System.Drawing.Point(2016, 58);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(40, 861);
            this.btnNext.TabIndex = 9;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrevious.Font = new System.Drawing.Font("Showcard Gothic", 45F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrevious.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnPrevious.Location = new System.Drawing.Point(3, 58);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(40, 861);
            this.btnPrevious.TabIndex = 7;
            this.btnPrevious.Text = "<";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // tbRecordNumberOf
            // 
            this.tbRecordNumberOf.Enabled = false;
            this.tbRecordNumberOf.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbRecordNumberOf.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tbRecordNumberOf.Location = new System.Drawing.Point(694, 14);
            this.tbRecordNumberOf.Name = "tbRecordNumberOf";
            this.tbRecordNumberOf.ReadOnly = true;
            this.tbRecordNumberOf.Size = new System.Drawing.Size(362, 23);
            this.tbRecordNumberOf.TabIndex = 3;
            // 
            // btnSaveTo
            // 
            this.btnSaveTo.Location = new System.Drawing.Point(1588, 15);
            this.btnSaveTo.Name = "btnSaveTo";
            this.btnSaveTo.Size = new System.Drawing.Size(143, 28);
            this.btnSaveTo.TabIndex = 6;
            this.btnSaveTo.Tag = "Allows you to Save the Image To a different location";
            this.btnSaveTo.Text = "Save Image To";
            this.btnSaveTo.UseVisualStyleBackColor = true;
            this.btnSaveTo.Click += new System.EventHandler(this.btnSaveTo_Click);
            // 
            // lblFileNumberOf
            // 
            this.lblFileNumberOf.AutoSize = true;
            this.lblFileNumberOf.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileNumberOf.Location = new System.Drawing.Point(577, 19);
            this.lblFileNumberOf.Name = "lblFileNumberOf";
            this.lblFileNumberOf.Size = new System.Drawing.Size(111, 13);
            this.lblFileNumberOf.TabIndex = 2;
            this.lblFileNumberOf.Text = "File Number x Of y";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategory.Location = new System.Drawing.Point(12, 19);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(57, 13);
            this.lblCategory.TabIndex = 0;
            this.lblCategory.Text = "Category";
            // 
            // tbCategory
            // 
            this.tbCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCategory.Location = new System.Drawing.Point(76, 13);
            this.tbCategory.Name = "tbCategory";
            this.tbCategory.ReadOnly = true;
            this.tbCategory.Size = new System.Drawing.Size(444, 26);
            this.tbCategory.TabIndex = 1;
            // 
            // cbReview
            // 
            this.cbReview.AutoSize = true;
            this.cbReview.Location = new System.Drawing.Point(1098, 20);
            this.cbReview.Name = "cbReview";
            this.cbReview.Size = new System.Drawing.Size(62, 17);
            this.cbReview.TabIndex = 4;
            this.cbReview.Text = "Review";
            this.cbReview.UseVisualStyleBackColor = true;
            this.cbReview.CheckedChanged += new System.EventHandler(this.cbReview_CheckedChanged);
            // 
            // btnBookmark
            // 
            this.btnBookmark.Location = new System.Drawing.Point(1414, 15);
            this.btnBookmark.Name = "btnBookmark";
            this.btnBookmark.Size = new System.Drawing.Size(143, 28);
            this.btnBookmark.TabIndex = 5;
            this.btnBookmark.Text = "Bookmark";
            this.btnBookmark.UseVisualStyleBackColor = true;
            this.btnBookmark.Click += new System.EventHandler(this.btnBookmark_Click);
            // 
            // lblFileName
            // 
            this.lblFileName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileName.Location = new System.Drawing.Point(1759, 20);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(251, 23);
            this.lblFileName.TabIndex = 10;
            this.lblFileName.Text = "NA";
            // 
            // pbPreview
            // 
            this.pbPreview.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pbPreview.ImageLocation = "";
            this.pbPreview.Location = new System.Drawing.Point(3, 3);
            this.pbPreview.Name = "pbPreview";
            this.pbPreview.Size = new System.Drawing.Size(1950, 840);
            this.pbPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbPreview.TabIndex = 11;
            this.pbPreview.TabStop = false;
            // 
            // flowPanel
            // 
            this.flowPanel.AutoScroll = true;
            this.flowPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowPanel.Controls.Add(this.pbPreview);
            this.flowPanel.Location = new System.Drawing.Point(49, 58);
            this.flowPanel.Name = "flowPanel";
            this.flowPanel.Size = new System.Drawing.Size(1961, 851);
            this.flowPanel.TabIndex = 12;
            // 
            // cbFullSizePicture
            // 
            this.cbFullSizePicture.AutoSize = true;
            this.cbFullSizePicture.Location = new System.Drawing.Point(1217, 20);
            this.cbFullSizePicture.Name = "cbFullSizePicture";
            this.cbFullSizePicture.Size = new System.Drawing.Size(101, 17);
            this.cbFullSizePicture.TabIndex = 13;
            this.cbFullSizePicture.Text = "Full Size Picture";
            this.cbFullSizePicture.UseVisualStyleBackColor = true;
            this.cbFullSizePicture.CheckedChanged += new System.EventHandler(this.cbFullSizePicture_CheckedChanged);
            // 
            // PicturePreviewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2056, 931);
            this.Controls.Add(this.cbFullSizePicture);
            this.Controls.Add(this.flowPanel);
            this.Controls.Add(this.lblFileName);
            this.Controls.Add(this.btnBookmark);
            this.Controls.Add(this.cbReview);
            this.Controls.Add(this.tbCategory);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.lblFileNumberOf);
            this.Controls.Add(this.btnSaveTo);
            this.Controls.Add(this.tbRecordNumberOf);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.btnNext);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PicturePreviewer";
            this.Text = "PicturePreviewer";
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).EndInit();
            this.flowPanel.ResumeLayout(false);
            this.flowPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.TextBox tbRecordNumberOf;
        private System.Windows.Forms.Button btnSaveTo;
        private System.Windows.Forms.Label lblFileNumberOf;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.TextBox tbCategory;
        private System.Windows.Forms.CheckBox cbReview;
        private System.Windows.Forms.Button btnBookmark;
        private System.Windows.Forms.Label lblFileName;
        private System.Drawing.Drawing2D.GraphicsPath mousePath;
        private System.Windows.Forms.PictureBox pbPreview;
        private System.Windows.Forms.FlowLayoutPanel flowPanel;
        private System.Windows.Forms.CheckBox cbFullSizePicture;
    }
}