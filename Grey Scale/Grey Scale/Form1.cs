using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;

namespace Grey_Scale
    //THis code was created and written by J Payton Garrard All right reserved Copyright.
{
    public partial class Form1 : Form
    {
        private Image im2;

        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

            OpenFileDialog opf1 = new OpenFileDialog();
            opf1.Title = "Select Picture";
            //which = 0;

            if (opf1.ShowDialog() == DialogResult.OK)
            {
                Image im = Image.FromFile(opf1.FileName);
                im2 = resizeImage(im);
                pictureBox1.Image = im2;
                pictureBox1.Refresh();
            }
            opf1.Dispose();
        }

        /// <summary>
        /// Resizes Image to fit in the image box.
        /// </summary>
        /// <param name="imgToResize"></param>
        /// <returns></returns>
        private Image resizeImage(Image imgToResize)
        {
            int srcW = imgToResize.Width;
            int srcH = imgToResize.Height;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = ((float)pictureBox1.Width / (float)srcW);
            nPercentH = ((float)pictureBox1.Height / (float)srcH);

            if (nPercentH < nPercentW)
            {
                nPercent = nPercentH;
            }
            else
                nPercent = nPercentW;

            int destWidth = (int)(srcW * nPercent);
            int destHeight = (int)(srcH * nPercent);

            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage((Image)b);

            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();
            return (Image)b;
        }

        /// <summary>
        /// Converts a image into a grey scale image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void greyScaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //which =1;
            Bitmap btm = new Bitmap(im2);

            for (int x = 0; x < im2.Width; ++x)
            {
                for (int y = 0; y < im2.Height; ++y)
                {
                    Color curr = btm.GetPixel(x, y);
                    int grey = (int)((curr.R * .3) + (curr.G * .59) + (curr.B * .11));
                    Color ncol = Color.FromArgb(grey, grey, grey);
                    btm.SetPixel(x, y, ncol);
                }
            }
            Image m = (Image)btm;
            pictureBox1.Image = m;
            pictureBox1.Refresh();
        }

        /// <summary>
        /// Converts any image into a black and white image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toBlackWhiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap btm = new Bitmap(im2);
            Color ncol = Color.FromArgb(0, 0, 0);
            for (int x = 0; x < im2.Width; ++x)
            {
                for (int y = 0; y < im2.Height; ++y)
                {
                    Color curr = btm.GetPixel(x, y);
                    int grey = (int)((curr.R * .3) + (curr.G * .59) + (curr.B * .11));

                    if (grey <= 128)
                    {
                        ncol = Color.FromArgb(128, 128, 128);
                    }
                    else
                    {
                        ncol = Color.FromArgb(225, 225, 225);
                    }
                    btm.SetPixel(x, y, ncol);
                }
            }
            Image m = (Image)btm;
            pictureBox1.Image = m;
            pictureBox1.Refresh();
        }

        /// <summary>
        /// Saves image as a .jpeg
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void jpegToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sv1 = new SaveFileDialog();

            sv1.Filter = "JPEG Image|*.jpeg";
            if (sv1.ShowDialog() == DialogResult.OK)
            {
                string name = sv1.FileName;
                pictureBox1.Image.Save(name, System.Drawing.Imaging.ImageFormat.Jpeg);
                /* if (which == 1)
                 {
                     btm.Save(name, System.Drawing.Imaging.ImageFormat.Jpeg);
                 }
                 else
                 {
                    im2.Save(name, System.Drawing.Imaging.ImageFormat.Jpeg);
                 }*/
                sv1.Dispose();
            }
        }

        /// <summary>
        /// Save Image as a .gif
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gifToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sv1 = new SaveFileDialog();

            sv1.Filter = "GIF Image|*.gif";
            if (sv1.ShowDialog() == DialogResult.OK)
            {
                string name = sv1.FileName;
                pictureBox1.Image.Save(name, System.Drawing.Imaging.ImageFormat.Gif);
                /* if (which == 1)
                 {
                     btm.Save(name, System.Drawing.Imaging.ImageFormat.Jpeg);
                 }
                 else
                 {
                    im2.Save(name, System.Drawing.Imaging.ImageFormat.Jpeg);
                 }*/
                sv1.Dispose();
            }
        }

        /// <summary>
        /// Saves Image as a .bmp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bmpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sv1 = new SaveFileDialog();

            sv1.Filter = "BMP Image|*.bmp";
            if (sv1.ShowDialog() == DialogResult.OK)
            {
                string name = sv1.FileName;
                pictureBox1.Image.Save(name, System.Drawing.Imaging.ImageFormat.Bmp);
                /* if (which == 1)
                 {
                     btm.Save(name, System.Drawing.Imaging.ImageFormat.Jpeg);
                 }
                 else
                 {
                    im2.Save(name, System.Drawing.Imaging.ImageFormat.Jpeg);
                 }*/
                sv1.Dispose();
            }
        }

        /// <summary>
        /// Places copy right of image over base image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void makeCopyRightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf1 = new OpenFileDialog();
            opf1.Title = "Select Picture";

            if (opf1.ShowDialog() == DialogResult.OK)
            {
                Image im = Image.FromFile(opf1.FileName);
            }

            Image wim = pictureBox1.Image;
            Bitmap bit = new Bitmap(opf1.FileName);

            Graphics imageGraphic = Graphics.FromImage(wim);

            ImageAttributes attr = new ImageAttributes();

            attr.SetColorKey(bit.GetPixel(0,0),bit.GetPixel(0,0));

            int x = (bit.Width - wim.Width);
            int y = (bit.Height - wim.Height);

            Rectangle dstRect = new Rectangle(x,y,bit.Width,bit.Height);
            imageGraphic.DrawImage(bit,dstRect,0,0,bit.Width,bit.Height,GraphicsUnit.Pixel,attr);

            pictureBox1.Image= wim;
            pictureBox1.Refresh();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf1 = new OpenFileDialog();
            opf1.Title = "Select Picture";

            if (opf1.ShowDialog() == DialogResult.OK)
            {
                Image im = Image.FromFile(opf1.FileName);
            }

            Image wim = pictureBox1.Image;
            Bitmap bit = new Bitmap(opf1.FileName);

            Graphics imageGraphic = Graphics.FromImage(wim);

            ImageAttributes attr = new ImageAttributes();

            attr.SetColorKey(bit.GetPixel(0, 0), bit.GetPixel(0, 0));

            int x = (wim.Width - bit.Width);
            int y = (wim.Height - bit.Height);

            Rectangle dstRect = new Rectangle(0, 0, bit.Width, bit.Height);
            imageGraphic.DrawImage(bit, dstRect, 0, 0, bit.Width, bit.Height, GraphicsUnit.Pixel, attr);

            pictureBox1.Image = wim;
            pictureBox1.Refresh();
        }

        /// <summary>
        /// Converts image to Red Scale
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toRedScaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap btm = new Bitmap(im2);

            for (int x = 0; x < im2.Width; ++x)
            {
                for (int y = 0; y < im2.Height; ++y)
                {
                    Color curr = btm.GetPixel(x, y);
                    int red = (int)((curr.R * .3) + (curr.G * .59) + (curr.B * .11));
                    Color ncol = Color.FromArgb(255, red, red);
                    btm.SetPixel(x, y, ncol);
                }
            }
            Image m = (Image)btm;
            pictureBox1.Image = m;
            pictureBox1.Refresh();
        }

        /// <summary>
        /// Converts image Green Scale
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toGreenScaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap btm = new Bitmap(im2);

            for (int x = 0; x < im2.Width; ++x)
            {
                for (int y = 0; y < im2.Height; ++y)
                {
                    Color curr = btm.GetPixel(x, y);
                    int Green = (int)((curr.R * .3) + (curr.G * .59) + (curr.B * .11));
                    Color ncol = Color.FromArgb(Green, 255, Green);
                    btm.SetPixel(x, y, ncol);
                }
            }
            Image m = (Image)btm;
            pictureBox1.Image = m;
            pictureBox1.Refresh();
        }

        /// <summary>
        /// Converts image to blue scale
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toBlueScaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap btm = new Bitmap(im2);

            for (int x = 0; x < im2.Width; ++x)
            {
                for (int y = 0; y < im2.Height; ++y)
                {
                    Color curr = btm.GetPixel(x, y);
                    int Blue = (int)((curr.R * .3) + (curr.G * .59) + (curr.B * .11));
                    Color ncol = Color.FromArgb(Blue, Blue, 255);
                    btm.SetPixel(x, y, ncol);
                }
            }
            Image m = (Image)btm;
            pictureBox1.Image = m;
            pictureBox1.Refresh();
        }

        /// <summary>
        /// Undoes changes to base picture
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = im2;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void filesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

    }
}