using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using OpenCvSharp;
using OpenCvSharp.Extensions;
using OpenCvSharp.Blob;

using System.Runtime.InteropServices;

using Lucene.Net;
using Lucene.Net.Documents;
using Lucene.Net.Store;
using Lucene.Net.Analysis.CJK;




namespace WindowsFormsApplication3
{

    public partial class Form1 : Form
    {
        public Mat src_base;
        public Mat src_test;
        ContourClass[] DB = new ContourClass[100];
        ContourClass org;

        public Form1()
        {
            InitializeComponent();

            ContourClass start = new ContourClass();
            start.img = Cv2.ImRead("start.jpg");
            for (int i = 0; i < 2; i++)
            {
                start.Kmeans(start, "start");
                start.GrabCut(start, "start");
            }

            for (int i = 0; i < 10; i++)
            {
                DB[i] = new ContourClass();
                DB[i].DB(DB[i], i);
            }
        }


        //private System.Drawing.Bitmap pic1;
        //private string name1;

        public void button2_Click(object sender, EventArgs e)
        {
            Bitmap[] pic = new Bitmap[5];
            string name;
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.DefaultExt = "jpg";
            openFile.Filter = "Graphics interchange Format (*.jpg)|*.jpg|All files(*.*)|*.*";
            openFile.ShowDialog();

            if (openFile.FileName.Length > 0)
            {
                pic[0] = new Bitmap(openFile.FileName);
                name = openFile.FileName;

                pictureBox1.Image = pic[0];
            }

            org = new ContourClass();
            org.img = OpenCvSharp.Extensions.BitmapConverter.ToMat(pic[0]);
            
            org.Kmeans(org, "org");
            org.GrabCut(org, "org");
            org.Gray_Binary(org, "org");
            org.Erode_Dilate(org, "org");
            org.Contour(org, "org");
            org.DeleteBackground(org, "org");


            string[] order = org.Similarity(org, DB);
            Mat[] num = new Mat[4];

            for (int i = 0; i < 4; i++)
            {
                num[i] = Cv2.ImRead(order[i]);
                pic[i+1] = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(num[i]);
            }
            
            pictureBox2.Image = pic[1];
            pictureBox3.Image = pic[2];
            pictureBox4.Image = pic[3];
            pictureBox5.Image = pic[4];

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string txt = textBox1.Text;
            
            LuceneClass test = new LuceneClass();
            string[] str = new string[6];
            str = test.test(txt);
            string result = "result\n";
            for(int i = 0; i < 10; i++)
            {
                if (str[i] == null) break;
                result += str[i];
            }

            MessageBox.Show(result);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double correl;

            src_base = Cv2.ImRead("1.jpg");
            src_test = Cv2.ImRead("2.jpg");
            Bitmap bt = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(src_base);
            pictureBox3.Image = bt;

            histogramclass hc = new histogramclass();
            correl = hc.get_correl(src_base, src_test);

            MessageBox.Show(correl.ToString());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int x = 44032;

            string str = null;

            for (int i = 1; i <= 21; i++)
            {
                for (int j = 1; j <= 28; j++)
                {
                    str = str+"{0} : {1}"+ x.ToString()+ (char)x+"\t";
                    x++;
                }
                str = str + "\n";
            }

            MessageBox.Show(str);

            int y = x;
            str = null;
            for (int i = 1; i <= 21; i++)
            {
                for (int j = 1; j <= 28; j++)
                {
                    str = str + "{0} : {1}" + y.ToString() + (char)y + "\t";
                    y++;
                }
                str = str + "\n";
            }
            MessageBox.Show(str);

        }
    }

    /*
    [Serializable]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct Image
    {
        [MarshalAs(UnmanagedType.I4)]
        public Mat img, gray1, gray2, kmeans, grabcut, dilate, erod, contours2, contours3;
    }

    [Serializable]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct Test
    {
        [MarshalAs(UnmanagedType.I4,SizeConst =sizeof(int))]
        public int a;
    }

    class WrapDemoLib
    {
        
        [DllImport("CpLib.dll")]
        extern public static int Add(int a, int b);
        public static int WrapAdd(int a, int b)
        {
            return Add(a, b);
        }

        [DllImport("CpLib.dll")]
        extern public static void test2();

        [DllImport("CpLib.dll")]
        extern public static int test1(ref Test test);

        [DllImport("CpLib.dll")]
        extern public static void Kmeans(ref Image image, string str);
        // public static void WrapKmeans(Image image, string str)
        // {
        //     Kmeans(image, str);
        // }
    }
    */
    
}

    

