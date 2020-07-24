using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sreenshoot
{


    public partial class SreenShoot : Form
    {

        private static Bitmap screenBitmap;
        private static Graphics screenGraphics;

        public SreenShoot()
        {
            InitializeComponent();
        }



        private void SreenShoot_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            saveLocation();
        }


        void saveLocation()
        {
            SaveFileDialog saveDialog = new SaveFileDialog();

            // Set filter options and filter index.
            saveDialog.Filter = "PNG Files (.png)|*.png|All Files (*.*)|*.*";
            saveDialog.FilterIndex = 1;
            saveDialog.FileName = "sreenshot";

            this.Hide();

  

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    Thread.Sleep(500);

                //print sreen
                screenBitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width,
                                    Screen.PrimaryScreen.Bounds.Height);
                    screenGraphics = Graphics.FromImage(screenBitmap);

                    //save to bitmap
                    screenGraphics.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y,
                                0, 0, Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy);

                    // save to file in dialog
                    screenBitmap.Save(saveDialog.FileName, ImageFormat.Png);
                }
            Thread.Sleep(300);

            this.Show();
        }



    }
}
