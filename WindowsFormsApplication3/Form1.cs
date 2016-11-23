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
        public bool check;
        public Mat src_base;
        public Mat src_test;
        public Mat DB_base;
        public Mat DB_test;
        ContourClass[] DB = new ContourClass[100];
        histogramclass hc = new histogramclass();
        OpenFileDialog openFile = new OpenFileDialog();
        ContourClass org;
        ContourClass nobackimg = new ContourClass();
        ContourClass[] DBnobackimg = new ContourClass[100];

        public Bitmap[] pictest = new Bitmap[5];
        public Bitmap[] pic = new Bitmap[5];
        public Bitmap[] picnoback = new Bitmap[5];
        public Mat[] Mplantimg = new Mat[100];
        public string name;

        public List<string> list1 = new List<string>();
        public List<string> list2 = new List<string>();
        public string[,] str = new string[2, 10];

        public int type = 0;

        LuceneClass test = new LuceneClass();

        public double orderresult;
        public double contourresult;
        public double OCresult;
        public int imgcnt = 10;
        public int[] gapcopy = new int[100];

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
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

            list1.AddRange(new List<string> { "a", "ab", "abc", "abcd", "가", "가나", "가나다", "가나다라" });

            for (int i = 0; i < list1.Count; i++)
            {
                list2.Add(Seperate(list1[i]));
            }

            comboBox1.Visible = false;
            groupBox1.Visible = false;
            artist.WordWrap = true;
            title.WordWrap = true;
            content.WordWrap = true;
        }

        public void ImgBtn_Click(object sender, EventArgs e)
        {
            openFile.DefaultExt = "jpg";
            openFile.Filter = "Graphics interchange Format (*.jpg)|*.jpg|All files(*.*)|*.*";
            openFile.ShowDialog();

            if (openFile.FileName.Length > 0)
            {
                pic[0] = new Bitmap(openFile.FileName);
                name = openFile.FileName;

                pictureBox1.Image = pic[0];
            }
        }

        private void TxtBtn_Click(object sender, EventArgs e)
        {
            string txt = textBox1.Text;

            List<ListBoxClass> ListBox = new List<ListBoxClass>();

            if (AllRadio.Checked)
            {
                type = 1;
            }
            else if (TitleRadio.Checked)
            {
                type = 2;
            }
            else if (ArtistRadio.Checked)
            {
                type = 3;
            }
            else if (ContentRadio.Checked)
            {
                type = 4;
            }
            else
            {
                if (MessageBox.Show("Please Check Search Type", "", MessageBoxButtons.OK) == DialogResult.OK) // 경고창 출력
                {
                    return;
                }
            }

            str = test.SearchTxT(txt, type);

            for (int i = 0; i < 10; i++)
            {
                if (str[i, 1] == null) break;
                ListBox.Add(new ListBoxClass { ListBox_Text = str[i, 1], ListBox_Value = str[i, 0] });
            }

            listBox1.DataSource = ListBox;
            listBox1.DisplayMember = "ListBox_Text";
            listBox1.ValueMember = "ListBox_Value";

            listBox1.Visible = true;
            groupBox1.Visible = false;

        }

        private void jyBtn_Click(object sender, EventArgs e)
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

        private void hyBtn_Click(object sender, EventArgs e)
        {
            string[,] test = new string[5, 2];

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    test[i, j] = i + ", " + j + "\n";
                }
            }

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    MessageBox.Show(test[i, j]);
                }
            }



            /*
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
            */

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

            if (textBox1.Text == "")
            {
                comboBox1.DroppedDown = false;
            }
            else
            {
                comboBox1.DroppedDown = true;
            }

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
            if (comboBox1.SelectedItem.ToString() == "")
            {
                textBox1.Text = comboBox1.SelectedItem.ToString();
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = comboBox1.SelectedItem.ToString();
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            BackBtn.Visible = true;

            string[,] searchId = test.SearchId(listBox1.SelectedValue.ToString(), type);
            artist.Text = searchId[0, 1];
            title.Text = searchId[0, 2];
            content.Text = searchId[0, 3];

            Font font1 = new Font("굴림", 10, FontStyle.Bold);
            Font font2 = new Font("굴림", 10, FontStyle.Regular);

            if (searchId[0, 0] == "2")
            {
                title.Font = font1;
                artist.Font = font2;
                content.Font = font2;
            }
            else if (searchId[0, 0] == "3")
            {
                title.Font = font2;
                artist.Font = font1;
                content.Font = font2;
            }
            else if (searchId[0, 0] == "4")
            {
                title.Font = font2;
                artist.Font = font2;
                content.Font = font1;
            }
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            BackBtn.Visible = false;
            groupBox1.Visible = false;
        }

        private void Order_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkBox1.Checked == true && checkBox2.Checked == true)
                {
                    for (int i = 0; i < imgcnt; i++)
                    {
                        OCresult =((double)((gapcopy[i] + 155000) / 465000)+ (org.ansjy[i]))/2;
                        MessageBox.Show(OCresult.ToString());
                    }
                }
                else if (checkBox1.Checked == true)
                {
                    contour();
                    checkBox1.Checked = false;
                }
                else if (checkBox2.Checked == true)
                {
                    order();
                    checkBox2.Checked = false;
                }
                
                else
                {
                    MessageBox.Show("체크를 1개 이상은 꼭 해주세요!","Error");
                }
            }
            catch
            {
                MessageBox.Show("이미지를 반드시 로드해주세요!","Error");
                checkBox1.Checked = false;
                checkBox2.Checked = false;
            }
        }

        public class ListBoxClass
        {
            public string ListBox_Value { get; set; }
            public string ListBox_Text { get; set; }

            public ListBoxClass()
            {
                ListBox_Value = string.Empty;
                ListBox_Text = string.Empty;
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
        public void order()
        {
            Mat[] num = new Mat[4];
            Mat[] DBimg = new Mat[100];
            double[] DBcorrel = new double[100];
            int[] gap = new int[imgcnt];
            double[] gapgroup = new double[5];
            double correl = 0;
            double intersect = 0;
            double orgresult = 0;
            int[] imgnumcheck = new int[imgcnt];
            //int[] imgnumcheckarray = new int[5];

            //오리지날 사진저장 및 사진띄우기
            //pic[0] = new Bitmap(openFile.FileName);
            //name = openFile.FileName;

            pictureBox1.Image = pic[0];

            //오리지날 그림 배경 없애기
            nobackimg = new ContourClass();
            nobackimg.img = OpenCvSharp.Extensions.BitmapConverter.ToMat(pic[0]);

            //DB_base = Cv2.ImRead("mushroom1.jpg");
            //nobackimg.img = DB_base;

            nobackimg.Kmeans(nobackimg, "org");
            nobackimg.GrabCut(nobackimg, "org");
            nobackimg.Gray_Binary(nobackimg, "org");
            nobackimg.Erode_Dilate(nobackimg, "org");
            nobackimg.Contour(nobackimg, "org");
            nobackimg.DeleteBackground(nobackimg, "org");

            //오리지널과 오리지널을 비교해 비교최대값 얻어내기
            src_base = nobackimg.img;
            correl = hc.get_correl(src_base, src_base);
            intersect = hc.get_intersect(src_base, src_base);

            orgresult = (correl + intersect) / 2;
            int temp;
            int temp2;
            //다른 디비들 비교값 생성하기
            for (int i = 0; i < imgcnt; i++)
            {
                try
                {
                    pictest[0] = new Bitmap("mushroom" + i.ToString() + ".jpg");
                    DB_base = OpenCvSharp.Extensions.BitmapConverter.ToMat(pictest[0]);
                    DBnobackimg[i] = new ContourClass(); //배열 초기화해조야지대                                                              
                    DBnobackimg[i].img = DB_base;
                    DBnobackimg[i].Kmeans(DBnobackimg[i], "org");
                    DBnobackimg[i].GrabCut(DBnobackimg[i], "org");
                    DBnobackimg[i].Gray_Binary(DBnobackimg[i], "org");
                    DBnobackimg[i].Erode_Dilate(DBnobackimg[i], "org");
                    DBnobackimg[i].Contour(DBnobackimg[i], "org");
                    DBnobackimg[i].WDeleteBackground(DBnobackimg[i], "mushroom", i);
                    
                    //다이렉트로 하기위해서 쓰는 리드
                    //Mplantimg[i] = Cv2.ImRead("mushroom_DeleteBackground" + i.ToString()+"_.jpg");
                    //Mplantimg[i] = Cv2.ImRead("mushroom_DeleteBackground" + i.ToString() + ".jpg");
                    //배경지우기 처리후 이미지
                    Mplantimg[i] = DBnobackimg[i].img;
                    src_test = Mplantimg[i];
                    correl = hc.get_correl(src_base, src_test);
                    intersect = hc.get_intersect(src_base, src_test);
                    DBcorrel[i] = (correl + intersect) / 2;
                    gap[i] = (int)Math.Abs(orgresult - DBcorrel[i]);

                }
                catch (System.NullReferenceException)
                {
                    MessageBox.Show("OrderButton test 중 파일을 읽지 못하였습니다.");
                }
            }
            //위에 체크박스를 위해 정렬되지 않은 갭 담아놓기
            for(int i = 0; i<imgcnt; i++)
            {
                gapcopy[i] = gap[i];
            }

            for (int i = 0; i < imgcnt; i++)
            {
                imgnumcheck[i] = i;
            }
            for (int k = 0; k < imgcnt; k++)
            {
                check = false;
                for (int j = 0; j < imgcnt - 1; j++)
                {
                    if (gap[j] > gap[j + 1])
                    {
                        check = true;
                        temp = gap[j];
                        gap[j] = gap[j + 1];
                        gap[j + 1] = temp;

                        temp2 = imgnumcheck[j];
                        imgnumcheck[j] = imgnumcheck[j + 1];
                        imgnumcheck[j + 1] = temp2;
                    }
                }
                if (check == false)
                {
                    break;
                }
            }
            for (int i = 0; i < 4; i++)
            {
                num[i] = Cv2.ImRead("mushroom" + imgnumcheck[i + 1] + ".jpg");
                pic[i + 1] = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(num[i]);
            }

            pictureBox2.Image = pic[1];
            pictureBox3.Image = pic[2];
            pictureBox4.Image = pic[3];
            pictureBox5.Image = pic[4];
        }
        
        public void contour()
        {

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
                pic[i + 1] = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(num[i]);
            }

            pictureBox2.Image = pic[1];
            pictureBox3.Image = pic[2];
            pictureBox4.Image = pic[3];
            pictureBox5.Image = pic[4];
        }
    }
}

    

