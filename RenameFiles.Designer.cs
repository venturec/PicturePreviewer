namespace PicturePreviewer
{
    partial class RenameFiles
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RenameFiles));
            this.fileDataGrid = new System.Windows.Forms.DataGridView();
            this.CurrentFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NewFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsChanged = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnSaveChanges = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.fileDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // fileDataGrid
            // 
            this.fileDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fileDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.fileDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CurrentFileName,
            this.NewFileName,
            this.IsChanged});
            this.fileDataGrid.Location = new System.Drawing.Point(12, 12);
            this.fileDataGrid.Name = "fileDataGrid";
            this.fileDataGrid.Size = new System.Drawing.Size(673, 582);
            this.fileDataGrid.TabIndex = 0;
            this.fileDataGrid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.fileDataGrid_CellValueChanged);
            // 
            // CurrentFileName
            // 
            this.CurrentFileName.HeaderText = "Current File Name";
            this.CurrentFileName.Name = "CurrentFileName";
            this.CurrentFileName.ReadOnly = true;
            this.CurrentFileName.Width = 250;
            // 
            // NewFileName
            // 
            this.NewFileName.HeaderText = "New File Name";
            this.NewFileName.Name = "NewFileName";
            this.NewFileName.Width = 250;
            // 
            // IsChanged
            // 
            this.IsChanged.HeaderText = "Is Changed";
            this.IsChanged.Name = "IsChanged";
            this.IsChanged.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsChanged.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.Location = new System.Drawing.Point(239, 615);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(139, 28);
            this.btnSaveChanges.TabIndex = 1;
            this.btnSaveChanges.Text = "Save Changes";
            this.btnSaveChanges.UseVisualStyleBackColor = true;
            this.btnSaveChanges.Click += new System.EventHandler(this.btnSaveChanges_Click);
            // 
            // RenameFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 655);
            this.Controls.Add(this.btnSaveChanges);
            this.Controls.Add(this.fileDataGrid);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RenameFiles";
            this.Text = "RenameFiles";
            ((System.ComponentModel.ISupportInitialize)(this.fileDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView fileDataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurrentFileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn NewFileName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsChanged;
        private System.Windows.Forms.Button btnSaveChanges;
    }
}