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
using OpenCvSharp.Extensions;
using OpenCvSharp.Blob;

using System.Runtime.InteropServices;



namespace WindowsFormsApplication3
{

    public partial class Form1 : Form
    {
        public Mat src_base;
        public Mat src_test;

        public Form1()
        {
            InitializeComponent();
            Image start = new Image();
            start.img = Cv2.ImRead("start.jpg");
            for (int i = 0; i < 2; i++)
            {
                start.Kmeans(start, "start");
                start.GrabCut(start, "start");
            }
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

            Image org = new Image();
            //WindowsFormsApplication3.Image org = new WindowsFormsApplication3.Image();
            org.img = OpenCvSharp.Extensions.BitmapConverter.ToMat(pic1);
            org.Kmeans(org, "org");
            org.GrabCut(org, "org");
            org.Gray_Binary(org, "org");
            org.Erode_Dilate(org, "org");
            org.Contour(org, "org");
            org.DeleteBackground(org, "org");
            Bitmap pic2 = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(org.img);
            pictureBox2.Image = pic2;
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
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


    struct Image
    {
        public Mat img, kmeans, grabcut, gray1, gray2, dilate, erode,contours2;
        //public List<List<OpenCvSharp.Point>> contours;
        public OpenCvSharp.Point[][] contours;
        //public Mat[] contours3;

        public void Kmeans(Image image,String str)
        {
            int clusterCnt = 1,maxCnt=1;
            Mat dst, labels, centers;
            dst = new Mat(this.img.Rows*this.img.Cols,1,MatType.CV_8UC3);
            this.kmeans = this.img.Reshape(0, this.img.Rows * this.img.Cols);
            
            while (clusterCnt > 0)
            {
                if (clusterCnt != maxCnt)
                //{
                //    this.kmeans = new Mat(this.img.Reshape(0, this.img.Rows * this.img.Cols));
                //    dst = new Mat(this.img.Rows * this.img.Cols, 1, MatType.CV_8UC3);
                    //dst = Mat(this.kmeans.rows * this.kmeans.Cols, 1, CV_8UC);
                    
                //}
                //else
                {
                    this.kmeans.Reshape(0, this.kmeans.Rows * this.kmeans.Cols);
                    dst.Reshape(this.kmeans.Rows * this.kmeans.Cols, 1, MatType.CV_8UC3);
                }

                this.kmeans.ConvertTo(this.kmeans, MatType.CV_32FC3);
                labels = new Mat();
                centers = new Mat();
                TermCriteria termcriteria = new TermCriteria(CriteriaType.Count & CriteriaType.Eps, 1000, 0.01);
                Cv2.Kmeans(this.kmeans, clusterCnt * 2, labels, termcriteria, 1, KMeansFlags.PpCenters, centers);

                for (int i = 0; i < this.kmeans.Rows * this.kmeans.Cols; i++)
                {
                    int nLabel = labels.At<int>(i, 0);
                    Vec3b vect = dst.At<Vec3b>(i, 0);
                    vect[0] = centers.At<byte>(nLabel, 0);
                    vect[1] = centers.At<byte>(nLabel, 1);
                    vect[2] = centers.At<byte>(nLabel, 2);
                    dst.Set<Vec3b>(i, 0, vect);
                }

                this.kmeans = dst.Reshape(0, this.img.Rows);
                clusterCnt--;
            }

            string kmeanstr = str + "_kmeans";
            //Cv2.ImShow(kmeanstr, this.kmeans);
            //imshow(kmean, image.kmeans);
            //imshow("kmean_img", image.kmeans);

        }

        public void GrabCut(Image image, String str)
        {
            //OpenCvSharp.Point point = new OpenCvSharp.Point(0, 0);
            //OpenCvSharp.Size size = new OpenCvSharp.Size(this.kmeans.Cols-1, this.kmeans.Rows-1);
            //Rect rectangle = new Rect(point, size);
            Rect rect = new Rect(0, 0, this.kmeans.Cols - 1, this.kmeans.Rows - 1);

            Mat result = new Mat(), fgModel = new Mat(), bgModel = new Mat();
            //fgModel.Zeros(MatType.CV_64FC1, 1, 13 * 5);
            //bgModel.Zeros(MatType.CV_64FC1, 1, 13 * 5);

            Cv2.GrabCut(this.kmeans, result, rect, bgModel, fgModel, 5, GrabCutModes.InitWithRect);
            //this.kmeans.GrabCut(result, rect, bgModel, fgModel, 5, GrabCutModes.InitWithRect);


            //Cv2.ImShow("fg", fgModel);
            //Cv2.ImShow("res", result);
            //this.kmeans = OpenCvSharp.GrabCutClasses.PR_FGD;

            Cv2.Compare(result, 3, result, CmpTypes.EQ);

            //Cv2.ImShow("res2", result);
            //Cv2.Subtract(result, 3, result);
            //Cv2.GrabCut(this.kmeans, result, rectangle, bgModel, fgModel, 5, GrabCutModes.InitWithRect);
            //Cv2.Compare(result, 3, result, CmpTypes.EQ);
            //Cv2.Compare(result, result, result, CmpTypes.EQ);
            //Cv2.Compare(result, result, result, CmpTypes.EQ);
            //Cv2.Compare(result, , result, CmpTypes.EQ);
            //MessageBox.Show("complete");

            this.grabcut = new Mat();
            this.kmeans.CopyTo(this.grabcut, result);

            string grabcutstr = str + "_grabCut";
            //Cv2.ImShow(grabcutstr, this.grabcut);
            //Cv2.ImShow("re", result);
            //imshow(grabCuts, image.grabcut);

        }
        
        public void Gray_Binary(Image image, String str)
        {
            this.gray1 = new Mat();
            this.gray2 = new Mat();
            Cv2.CvtColor(this.grabcut, this.gray1, ColorConversionCodes.BGR2GRAY);
            Cv2.Threshold(this.gray1, this.gray2, 1, 255, ThresholdTypes.Binary);
            string graystr = str + "_gray";
            //Cv2.ImShow("gray", this.gray1);
            //Cv2.ImShow(graystr, this.gray2);
        }

        public void Erode_Dilate(Image image, String str)
        {
            Mat element = new Mat();
            OpenCvSharp.Point point = new OpenCvSharp.Point(0, 0);
            OpenCvSharp.Size size = new OpenCvSharp.Size(3, 3);
            element = Cv2.GetStructuringElement(0, size, point);

            this.dilate = new Mat();
            this.erode = new Mat();

            Cv2.Dilate(this.gray2, this.dilate, element);
            Cv2.Dilate(this.dilate, this.dilate, element);
            
            Cv2.Erode(this.dilate, this.erode, element);
            Cv2.Erode(this.erode, this.erode, element);

            Cv2.Dilate(this.erode, this.dilate, element);
            Cv2.Erode(this.dilate, this.erode, element);

            string dilatestr = str + "_dilate";
           // Cv2.ImShow(dilatestr, this.dilate);

            string erodestr = str + "_erode";
           // Cv2.ImShow(erodestr, this.erode);
        }

        public void Contour(Image image, String str)
        {
            RNG rng = new RNG(12345);
            HierarchyIndex[] hierarchy = new HierarchyIndex[1];
            OpenCvSharp.Point point = new OpenCvSharp.Point(0, 0);

            this.contours = new OpenCvSharp.Point[1][];
            Cv2.FindContours(this.gray2, out this.contours, out hierarchy, RetrievalModes.Tree, ContourApproximationModes.ApproxSimple, point);

            int max_area = 0;
            int ci = 0;
            for (int i = 0; i < this.contours.Count(); i++)
            {
                OpenCvSharp.Point[] cnt = new OpenCvSharp.Point[1];
                cnt = this.contours[i];
                int area = (int)Cv2.ContourArea(cnt);

                if (area > max_area)
                {
                    max_area = area;
                    ci = i;
                }
            }

            this.contours2 = new Mat();
            this.contours2 = Mat.Zeros(this.gray2.Rows, this.gray2.Cols, MatType.CV_8UC3);
            Scalar color = new Scalar(rng.Uniform(0, 255), rng.Uniform(0, 255), rng.Uniform(0, 255));
            Cv2.DrawContours(this.contours2, this.contours, ci, color, 1);

            string contourstr = str + "_contour";
                
            // Cv2.ImShow(contourstr, this.contours2);
            //for (int j = 0; j < 100; j++)
            //{
            //    string deleteBgresult = contourstr + "_result"+j+".jpg";
            //    Cv2.ImWrite(deleteBgresult, this.contours2);
            //}
                     
        }

        public void DeleteBackground(Image image, String str)
        {
            for (int j = 0; j < image.gray2.Rows; j++)
            {
                for (int i = 0; i < image.gray2.Cols; i++)
                {
                    if (image.gray2.At<char>(j, i) == 0)
                    {
                        Vec3b pix = this.img.At<Vec3b>(j, i);
                        pix[0] = 0;
                        pix[1] = 0;
                        pix[2] = 0;
                        this.img.Set<Vec3b>(j, i, pix);
                    }
                }
            }


            string deleteBgstr = str + "_DeleteBackground";
            // Cv2.ImShow(deleteBgstr, image.img);
            //string deleteBgresult = deleteBg + "_result.jpg";
            //imwrite(deleteBgresult, image.img);
        }


    }
}
