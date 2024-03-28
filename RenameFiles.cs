using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PicturePreviewer
{
    public partial class RenameFiles : Form
    {
        public String folderPath;
        public String[] filesArray;

        public RenameFiles()
        {
            InitializeComponent();
        }

        public void populateDataGrid()
        {
            foreach (String fl in filesArray)
            {
                String[] fileSplit = fl.Split('\\');
                String fileName = fileSplit[fileSplit.Length - 1];
                this.fileDataGrid.Rows.Add(fileName, "", false);
            }
        }

        private void fileDataGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex == 1)
            {
                this.fileDataGrid.Rows[e.RowIndex].Cells["IsChanged"].Value = true;
            }
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {

        }
    }
}
