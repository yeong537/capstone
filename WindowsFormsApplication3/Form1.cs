using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using OpenCvSharp;


namespace WindowsFormsApplication3
{

    struct image
    {
        public Mat img, gray1, gray2, kmeans, grabcut, dilate, erode3, contour2, contour3;
        VectorOfPoint contours;
    }
    

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private System.Drawing.Bitmap pic1;
        private string name1;

        public void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.DefaultExt = "jpg";
            openFile.Filter = "Graphics interchange Format (*.jpg)|*.jpg|All files(*.*)|*.*";
            openFile.ShowDialog();

            if (openFile.FileName.Length > 0)

            {
                pic1 = new Bitmap(openFile.FileName);
                name1 = openFile.FileName;
                
                pictureBox1.Image = pic1;

            }

            image org = new image();
            org.img = OpenCvSharp.Extensions.BitmapConverter.ToMat(pic1);
            Cv2.ImShow("original",org.img);
        }
    }
}
