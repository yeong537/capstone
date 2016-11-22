using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;

namespace WindowsFormsApplication3
{
    class histogramclass
    {
        public double get_correl(Mat src_base,Mat src_test1){
           
            Mat hsv_base = new Mat();
            Mat hsv_test1 = new Mat();

            Cv2.CvtColor(src_base,hsv_base,ColorConversionCodes.RGB2HSV);
            Cv2.CvtColor(src_test1, hsv_test1, ColorConversionCodes.RGB2HSV);
       
            int h_bins = 50; int s_bins = 60;
	        int[] histSize = new int[] { h_bins, s_bins };

            Rangef[] range = new Rangef[2];
            range[0].Start = (float)0;
            range[0].End = (float)180;
            range[1].Start = (float)0;
            range[1].End = (float)255;

	        int[] channels = new int [] { 0, 1 };

             Mat hist_base = new Mat();
             Mat hist_test1 = new Mat();

            //Calculate the histograms for the HSV images
            Cv2.CalcHist(new Mat[]{hsv_base}, channels, null, hist_base, 2, histSize, range, true, false);
            Cv2.Normalize(hist_base, hist_base, 0, 1, OpenCvSharp.NormTypes.MinMax,-1,null);

            Cv2.CalcHist(new Mat[] { hsv_test1 }, channels, null, hist_base, 2, histSize, range, true, false);
            Cv2.Normalize(hist_test1, hist_test1, 0, 1, OpenCvSharp.NormTypes.MinMax, -1, null);

            double hist_base_correl = Cv2.CompareHist(hist_base, hist_base, OpenCvSharp.HistCompMethods.Correl);

            return hist_base_correl;
           }
        public double get_intersect(Mat src_base, Mat src_test1)
        {

            Mat hsv_base = new Mat();
            Mat hsv_test1 = new Mat();

            Cv2.CvtColor(src_base, hsv_base, ColorConversionCodes.RGB2HSV);
            Cv2.CvtColor(src_test1, hsv_test1, ColorConversionCodes.RGB2HSV);

            int h_bins = 50; int s_bins = 60;
            int[] histSize = new int[] { h_bins, s_bins };

            Rangef[] range = new Rangef[2];
            range[0].Start = (float)0;
            range[0].End = (float)180;
            range[1].Start = (float)0;
            range[1].End = (float)255;

            int[] channels = new int[] { 0, 1 };

            Mat hist_base = new Mat();
            Mat hist_test1 = new Mat();

            //Calculate the histograms for the HSV images
            Cv2.CalcHist(new Mat[] { hsv_base }, channels, null, hist_base, 2, histSize, range, true, false);
            Cv2.Normalize(hist_base, hist_base, 0, 1, OpenCvSharp.NormTypes.MinMax, -1, null);

            Cv2.CalcHist(new Mat[] { hsv_test1 }, channels, null, hist_base, 2, histSize, range, true, false);
            Cv2.Normalize(hist_test1, hist_test1, 0, 1, OpenCvSharp.NormTypes.MinMax, -1, null);

            double hist_base_intersect = Cv2.CompareHist(hist_base, hist_base, OpenCvSharp.HistCompMethods.Intersect);

            return hist_base_intersect;
        }

    }
}

