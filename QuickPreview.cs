using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PicturePreviewer
{
    public partial class QuickPreview : Form
    {
        public QuickPreview()
        {
            InitializeComponent();
        }

        public void setPreviewPath(String pictureFilePath)
        {
            this.pbPreview.ImageLocation = pictureFilePath;
        }

        private void pbPreview_DoubleClick(object sender, EventArgs e)
        {
            PicturePreviewer pp = new PicturePreviewer();
            pp.files = new string[1];
            pp.files[0] = this.pbPreview.ImageLocation;
            pp.getImageLocation();
            pp.Show();
        }
    }
}
