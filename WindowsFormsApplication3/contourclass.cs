using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;

namespace WindowsFormsApplication3
{
    class ContourClass
    {
        public Mat img, kmeans, grabcut, gray1, gray2, dilate, erode, contour1, contour2;
        public OpenCvSharp.Point[][] contours;
        public double ans;

        public void DB(ContourClass image, int i)
        {
            string str = "org_contour" + i.ToString() + ".jpg";
            image.img = Cv2.ImRead(str);
            //image.Kmeans(image, str);
            //image.GrabCut2(image, str);

            //image.Gray_Binary(image, str);
            image.Gray_Binary2(image, str);
            image.Erode_Dilate2(image, str);
            image.Contour(image, str);
            //image.Contour2(image, str);
            //image.DeleteBackground(image, str);
        }

        public void Kmeans(ContourClass image, String str)
        {
            int clusterCnt = 1, maxCnt = 1;
            Mat dst, labels, centers;

            dst = new Mat(image.img.Rows * image.img.Cols, 1, MatType.CV_8UC3);
            image.kmeans = image.img.Reshape(0, image.img.Rows * image.img.Cols);
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
                    image.kmeans.Reshape(0, image.kmeans.Rows * image.kmeans.Cols);
                    dst.Reshape(image.kmeans.Rows * image.kmeans.Cols, 1, MatType.CV_8UC3);
                }

                image.kmeans.ConvertTo(image.kmeans, MatType.CV_32FC3);
                labels = new Mat();
                centers = new Mat();
                TermCriteria termcriteria = new TermCriteria(CriteriaType.Count & CriteriaType.Eps, 1000, 0.01);
                Cv2.Kmeans(image.kmeans, clusterCnt * 2, labels, termcriteria, 1, KMeansFlags.PpCenters, centers);

                for (int i = 0; i < image.kmeans.Rows * image.kmeans.Cols; i++)
                {
                    int nLabel = labels.At<int>(i, 0);
                    Vec3b vect = dst.At<Vec3b>(i, 0);
                    vect[0] = centers.At<byte>(nLabel, 0);
                    vect[1] = centers.At<byte>(nLabel, 1);
                    vect[2] = centers.At<byte>(nLabel, 2);
                    dst.Set<Vec3b>(i, 0, vect);
                }

                image.kmeans = dst.Reshape(0, image.img.Rows);
                clusterCnt--;
            }

            string kmeanstr = str + "_kmeans";
            //Cv2.ImShow(kmeanstr, image.kmeans);
        }
        public void GrabCut(ContourClass image, String str)
        {
            //OpenCvSharp.Point point = new OpenCvSharp.Point(0, 0);
            //OpenCvSharp.Size size = new OpenCvSharp.Size(this.kmeans.Cols-1, this.kmeans.Rows-1);
            //Rect rectangle = new Rect(point, size);
            //Cv2.ImShow("test", image.kmeans);
            Rect rect = new Rect(0, 0, image.kmeans.Cols - 1, image.kmeans.Rows - 1);

            Mat result = new Mat(), fgModel = new Mat(), bgModel = new Mat();
            //fgModel.Zeros(MatType.CV_64FC1, 1, 13 * 5);
            //bgModel.Zeros(MatType.CV_64FC1, 1, 13 * 5);

            Cv2.GrabCut(image.kmeans, result, rect, bgModel, fgModel, 5, GrabCutModes.InitWithRect);
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

            image.grabcut = new Mat();
            image.kmeans.CopyTo(image.grabcut, result);

            string grabcutstr = str + "_grabCut";
            //Cv2.ImShow(grabcutstr, image.grabcut);
            //Cv2.ImShow("re", result);
            //imshow(grabCuts, image.grabcut);

        }
        public void Gray_Binary(ContourClass image, String str)
        {
            image.gray1 = new Mat();
            image.gray2 = new Mat();
            Cv2.CvtColor(image.grabcut, image.gray1, ColorConversionCodes.BGR2GRAY);
            Cv2.Threshold(image.gray1, image.gray2, 1, 255, ThresholdTypes.Binary);
            string graystr = str + "_gray";
        }

        public void Gray_Binary2(ContourClass image, String str)
        {
            image.gray1 = new Mat();
            image.gray2 = new Mat();
            Cv2.CvtColor(image.img, image.gray1, ColorConversionCodes.BGR2GRAY);
            Cv2.Threshold(image.gray1, image.gray2, 1, 255, ThresholdTypes.Binary);
            string graystr = str + "_gray";
        }
        public void Erode_Dilate2(ContourClass image, String str)
        {
            Mat element = new Mat();
            OpenCvSharp.Point point = new OpenCvSharp.Point(0, 0);
            OpenCvSharp.Size size = new OpenCvSharp.Size(3, 3);
            element = Cv2.GetStructuringElement(0, size, point);

            image.dilate = new Mat();
            image.erode = new Mat();

            //Cv2.Dilate(image.gray2, image.dilate, element);
            //Cv2.Dilate(image.dilate, image.dilate, element);

            Cv2.Erode(image.gray2, image.erode, element);
            // Cv2.Erode(image.erode, image.erode, element);

            Cv2.Dilate(image.erode, image.dilate, element);
            Cv2.Dilate(image.dilate, image.dilate, element);
            //Cv2.Erode(image.dilate, image.erode, element);

            string dilatestr = str + "_dilate";
            // Cv2.ImShow(dilatestr, this.dilate);

            string erodestr = str + "_erode";
            //Cv2.ImShow(erodestr, this.erode);


            //Cv2.ImShow(erodestr, image.dilate);
        }

        public void Erode_Dilate(ContourClass image, String str)
        {
            Mat element = new Mat();
            OpenCvSharp.Point point = new OpenCvSharp.Point(0, 0);
            OpenCvSharp.Size size = new OpenCvSharp.Size(3, 3);
            element = Cv2.GetStructuringElement(0, size, point);

            image.dilate = new Mat();
            image.erode = new Mat();

            Cv2.Dilate(image.gray2, image.dilate, element);
            Cv2.Dilate(image.dilate, image.dilate, element);

            Cv2.Erode(image.dilate, image.erode, element);
            Cv2.Erode(image.erode, image.erode, element);

            Cv2.Dilate(image.erode, image.dilate, element);
            Cv2.Erode(image.dilate, image.erode, element);

            string dilatestr = str + "_dilate";
            // Cv2.ImShow(dilatestr, this.dilate);

            string erodestr = str + "_erode";
            //Cv2.ImShow(erodestr, this.erode);


            //Cv2.ImShow(erodestr, image.erode);
        }

        public void Contour(ContourClass image, String str)
        {
            RNG rng = new RNG(12345);
            HierarchyIndex[] hierarchy = new HierarchyIndex[1];
            OpenCvSharp.Point point = new OpenCvSharp.Point(0, 0);

            image.contours = new OpenCvSharp.Point[1][];
            Cv2.FindContours(image.dilate, out image.contours, out hierarchy, RetrievalModes.Tree, ContourApproximationModes.ApproxSimple, point);

            int max_area = 0;
            int ci = 0;
            for (int i = 0; i < image.contours.Count(); i++)
            {
                OpenCvSharp.Point[] cnt = new OpenCvSharp.Point[1];
                cnt = image.contours[i];
                int area = (int)Cv2.ContourArea(cnt);

                if (area > max_area)
                {
                    max_area = area;
                    ci = i;
                }
            }

            image.contour1 = new Mat();
            image.contour2 = new Mat();
            image.contour1 = Mat.Zeros(image.dilate.Rows, image.dilate.Cols, MatType.CV_8UC3);
            Scalar color = new Scalar(rng.Uniform(0, 255), rng.Uniform(0, 255), rng.Uniform(0, 255));

            //Cv2.DrawContours(image.contour1, image.contours, ci, color, 100);
            Cv2.DrawContours(image.contour1, image.contours, ci, color, 1);
            string contourstr = str + "_contour";
            Cv2.CvtColor(image.contour1, image.contour2, ColorConversionCodes.BGR2GRAY);
            //Cv2.ImShow(contourstr, image.contour2);
            //for(int j = 0; j < 100; j++) {
            //    string deleteBgresult = contourstr + "_result"+j+".jpg";
            //    Cv2.ImWrite(deleteBgresult, image.contour2);
            //}
            //Cv2.ImShow(contourstr, image.contour1);
        }
        /*
        public void Contour2(contourclass image, String str)
        {
            image.gray1 = new Mat();
            image.gray2 = new Mat();
            Cv2.CvtColor(image.dilate, image.gray1, ColorConversionCodes.BGR2GRAY);
            Cv2.Threshold(image.gray1, image.gray2, 1, 255, ThresholdTypes.Binary);

            RNG rng = new RNG(12345);
            HierarchyIndex[] hierarchy = new HierarchyIndex[1];
            OpenCvSharp.Point point = new OpenCvSharp.Point(0, 0);

            image.contours = new OpenCvSharp.Point[1][];
            Cv2.FindContours(image.gray2, out image.contours, out hierarchy, RetrievalModes.Tree, ContourApproximationModes.ApproxSimple, point);

            int max_area = 0;
            int ci = 0;
            for (int i = 0; i < image.contours.Count(); i++)
            {
                OpenCvSharp.Point[] cnt = new OpenCvSharp.Point[1];
                cnt = image.contours[i];
                int area = (int)Cv2.ContourArea(cnt);

                if (area > max_area)
                {
                    max_area = area;
                    ci = i;
                }
            }

            image.contour1 = new Mat();
            image.contour2 = new Mat();
            image.contour1 = Mat.Zeros(image.gray2.Rows, image.img.Cols, MatType.CV_8UC3);
            Scalar color = new Scalar(rng.Uniform(0, 255), rng.Uniform(0, 255), rng.Uniform(0, 255));
            Cv2.DrawContours(image.contour1, image.contours, ci, color, 1);
            Cv2.CvtColor(image.contour1, image.contour2, ColorConversionCodes.BGR2GRAY);

            string contourstr = str + "_contour";

            //Cv2.ImShow(contourstr, image.contour2);
            //for (int j = 0; j < 100; j++)
            //{
            //    string deleteBgresult = contourstr + "_result"+j+".jpg";
            //    Cv2.ImWrite(deleteBgresult, this.contours2);
            //}
        }
        */
        public string[] Similarity(ContourClass image, ContourClass[] DB)
        {
            //double min = 1000;
            //int best = 0;
            double[] ans = new double[10];
            int[] order = new int[4];
            for (int i = 0; i < 10; i++)
            {
                ans[i] = new double();
                ans[i] = Cv2.MatchShapes(image.contour2, DB[i].contour2, ShapeMatchModes.I1, 0);
                DB[i].ans = ans[i];
            }

            /*
            for(int i = 0; i < 10;  i++)
            {
                if (ans[i] < min)
                {
                    min = ans[i];
                    best = i;
                }
            }
            */

            for (int i = 0; i < 9; i++)
            {
                for (int j = i + 1; j < 10; j++)
                {
                    if (ans[i] > ans[j])
                    {
                        double temp = ans[i];
                        ans[i] = ans[j];
                        ans[j] = temp;
                    }
                }
            }


            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (ans[i] == DB[j].ans)
                    {
                        order[i] = j;
                        break;
                    }
                }
            }


            string[] filename = new string[4];
            for (int i = 0; i < 4; i++)
            {
                filename[i] = "mushroom" + order[i].ToString() + ".jpg";
            }

            return filename;
        }

        public void DeleteBackground(ContourClass image, String str)
        {
            for (int j = 0; j < image.gray2.Rows; j++)
            {
                for (int i = 0; i < image.gray2.Cols; i++)
                {
                    if (image.gray2.At<char>(j, i) == 0)
                    {
                        Vec3b pix = image.img.At<Vec3b>(j, i);
                        pix[0] = 0;
                        pix[1] = 0;
                        pix[2] = 0;
                        image.img.Set<Vec3b>(j, i, pix);
                    }
                }
            }


            string deleteBgstr = str + "_DeleteBackground";
            //Cv2.ImShow(deleteBgstr, image.img);
            //string deleteBgresult = deleteBg + "_result.jpg";
            //imwrite(deleteBgresult, image.img);
        }
    }
}
