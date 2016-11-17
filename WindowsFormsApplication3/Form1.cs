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

        public List<string> list1 = new List<string>();
        public List<string> list2 = new List<string>();

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

                //MessageBox.Show(str[i]);
                //result += str[i];
                str[i] = str[i].Replace("txt",)
            }

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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            comboBox1.Text = textBox1.Text;
            comboBox1.Items.Clear();

            for (int i = 0; i < list2.Count; i++)
            {
                if (list2[i].ToString().IndexOf(Seperate(textBox1.Text)) >= 0)
                {
                    comboBox1.Items.Add(list1[i].ToString());

                }
            }

            if(textBox1.Text == "")
            {
                comboBox1.DroppedDown = false;
            }
            else
            {
                comboBox1.DroppedDown = true;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            list1.AddRange(new List<string> { "a", "ab", "abc", "abcd", "가", "가나", "가나다", "가나다라" });

            for(int i = 0; i < list1.Count; i++)
            {
                list2.Add(Seperate(list1[i]));
            }
            
            comboBox1.Visible = false;

        }

        public string Seperate(string data)
        {
            int a, b, c;
            string result = "";
            int cnt;

            // ㄱ ㄲ ㄴ ㄷ ㄸ ㄹ ㅁ ㅂ ㅃ ㅅ ㅆ ㅇ ㅈ ㅉ ㅊ ㅋ ㅌ ㅍ ㅎ
            int[] ChoSung = { 0x3131, 0x3132, 0x3134, 0x3137, 0x3138, 0x3139, 0x3141, 0x3142, 0x3143, 0x3145, 0x3146, 0x3147, 0x3148, 0x3149, 0x314a, 0x314b, 0x314c, 0x314d, 0x314e };
            // ㅏ ㅐ ㅑ ㅒ ㅓ ㅔ ㅕ ㅖ ㅗ ㅘ ㅙ ㅚ ㅛ ㅜ ㅝ ㅞ ㅟ ㅠ ㅡ ㅢ ㅣ
            int[] JwungSung = { 0x314f, 0x3150, 0x3151, 0x3152, 0x3153, 0x3154, 0x3155, 0x3156, 0x3157, 0x3158, 0x3159, 0x315a, 0x315b, 0x315c, 0x315d, 0x315e, 0x315f, 0x3160, 0x3161, 0x3162, 0x3163 };
            // ㄱ ㄲ ㄳ ㄴ ㄵ ㄶ ㄷ ㄹ ㄺ ㄻ ㄼ ㄽ ㄾ ㄿ ㅀ ㅁ ㅂ ㅄ ㅅ ㅆ ㅇ ㅈ ㅊ ㅋ ㅌ ㅍ ㅎ
            int[] JongSung = { 0, 0x3131, 0x3132, 0x3133, 0x3134, 0x3135, 0x3136, 0x3137, 0x3139, 0x313a, 0x313b, 0x313c, 0x313d, 0x313e, 0x313f, 0x3140, 0x3141, 0x3142, 0x3144, 0x3145, 0x3146, 0x3147, 0x3148, 0x314a, 0x314b, 0x314c, 0x314d, 0x314e };

            int x;

            for (cnt = 0; cnt < data.Length; cnt++)
            {
                x = (int)data[cnt];

                //한글일 경우만 분리 시행
                if (x >= 0xAC00 && x <= 0xD7A3)
                {
                    c = x - 0xAC00;
                    a = c / (21 * 28);
                    c = c % (21 * 28);
                    b = c / 28;
                    c = c % 28;
                    /*
                    a = (int)a;
                    b = (int)b;
                    c = (int)c;
                    */
                    result += string.Format("{0}{1}", (char)ChoSung[a], (char)JwungSung[b]);
                    //result += string.Format("{0}", (char)ChoSung[a]); //초성만

                    // $c가 0이면, 즉 받침이 있을경우
                    if (c != 0)
                        result += string.Format("{0}", (char)JongSung[c]);
                }
                else
                {
                    result += string.Format("{0}", (char)x);

                }
            }
            return result;

        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            textBox1.Focus();
            if (comboBox1.SelectedItem.ToString()=="")
            {
                textBox1.Text = comboBox1.SelectedItem.ToString();

            }

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

    

