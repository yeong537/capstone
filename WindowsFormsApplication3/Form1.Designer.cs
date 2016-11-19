namespace WindowsFormsApplication3
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.TxtBtn = new System.Windows.Forms.Button();
            this.jyBtn = new System.Windows.Forms.Button();
            this.hyBtn = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ImgBtn = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.AllRadio = new System.Windows.Forms.RadioButton();
            this.TitleRadio = new System.Windows.Forms.RadioButton();
            this.ArtistRadio = new System.Windows.Forms.RadioButton();
            this.ContentRadio = new System.Windows.Forms.RadioButton();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.content = new System.Windows.Forms.RichTextBox();
            this.title = new System.Windows.Forms.RichTextBox();
            this.artist = new System.Windows.Forms.RichTextBox();
            this.BackBtn = new System.Windows.Forms.Button();
            this.Order = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(244, 21);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // TxtBtn
            // 
            this.TxtBtn.Location = new System.Drawing.Point(267, 13);
            this.TxtBtn.Name = "TxtBtn";
            this.TxtBtn.Size = new System.Drawing.Size(75, 23);
            this.TxtBtn.TabIndex = 2;
            this.TxtBtn.Text = "text btn";
            this.TxtBtn.UseVisualStyleBackColor = true;
            this.TxtBtn.Click += new System.EventHandler(this.TxtBtn_Click);
            // 
            // jyBtn
            // 
            this.jyBtn.Location = new System.Drawing.Point(357, 13);
            this.jyBtn.Name = "jyBtn";
            this.jyBtn.Size = new System.Drawing.Size(75, 23);
            this.jyBtn.TabIndex = 8;
            this.jyBtn.Text = "jytest";
            this.jyBtn.UseVisualStyleBackColor = true;
            this.jyBtn.Click += new System.EventHandler(this.jyBtn_Click);
            // 
            // hyBtn
            // 
            this.hyBtn.Location = new System.Drawing.Point(438, 13);
            this.hyBtn.Name = "hyBtn";
            this.hyBtn.Size = new System.Drawing.Size(75, 23);
            this.hyBtn.TabIndex = 9;
            this.hyBtn.Text = "hytest";
            this.hyBtn.UseVisualStyleBackColor = true;
            this.hyBtn.Click += new System.EventHandler(this.hyBtn_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(13, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(243, 20);
            this.comboBox1.TabIndex = 10;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.comboBox1.SelectionChangeCommitted += new System.EventHandler(this.comboBox1_SelectionChangeCommitted);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(11, 73);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(331, 256);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // ImgBtn
            // 
            this.ImgBtn.Location = new System.Drawing.Point(11, 335);
            this.ImgBtn.Name = "ImgBtn";
            this.ImgBtn.Size = new System.Drawing.Size(331, 23);
            this.ImgBtn.TabIndex = 3;
            this.ImgBtn.Text = "image";
            this.ImgBtn.UseVisualStyleBackColor = true;
            this.ImgBtn.Click += new System.EventHandler(this.ImgBtn_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(12, 364);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(80, 74);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(98, 364);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(79, 74);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 5;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Location = new System.Drawing.Point(183, 364);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(73, 74);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 6;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Location = new System.Drawing.Point(263, 365);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(79, 73);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 7;
            this.pictureBox5.TabStop = false;
            // 
            // AllRadio
            // 
            this.AllRadio.AutoSize = true;
            this.AllRadio.Location = new System.Drawing.Point(11, 55);
            this.AllRadio.Name = "AllRadio";
            this.AllRadio.Size = new System.Drawing.Size(36, 16);
            this.AllRadio.TabIndex = 11;
            this.AllRadio.TabStop = true;
            this.AllRadio.Text = "all";
            this.AllRadio.UseVisualStyleBackColor = true;
            // 
            // TitleRadio
            // 
            this.TitleRadio.AutoSize = true;
            this.TitleRadio.Location = new System.Drawing.Point(66, 55);
            this.TitleRadio.Name = "TitleRadio";
            this.TitleRadio.Size = new System.Drawing.Size(42, 16);
            this.TitleRadio.TabIndex = 12;
            this.TitleRadio.TabStop = true;
            this.TitleRadio.Text = "title";
            this.TitleRadio.UseVisualStyleBackColor = true;
            // 
            // ArtistRadio
            // 
            this.ArtistRadio.AutoSize = true;
            this.ArtistRadio.Location = new System.Drawing.Point(127, 55);
            this.ArtistRadio.Name = "ArtistRadio";
            this.ArtistRadio.Size = new System.Drawing.Size(50, 16);
            this.ArtistRadio.TabIndex = 13;
            this.ArtistRadio.TabStop = true;
            this.ArtistRadio.Text = "artist";
            this.ArtistRadio.UseVisualStyleBackColor = true;
            // 
            // ContentRadio
            // 
            this.ContentRadio.AutoSize = true;
            this.ContentRadio.Location = new System.Drawing.Point(190, 55);
            this.ContentRadio.Name = "ContentRadio";
            this.ContentRadio.Size = new System.Drawing.Size(64, 16);
            this.ContentRadio.TabIndex = 14;
            this.ContentRadio.TabStop = true;
            this.ContentRadio.Text = "content";
            this.ContentRadio.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(357, 73);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(445, 256);
            this.listBox1.TabIndex = 15;
            this.listBox1.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.content);
            this.groupBox1.Controls.Add(this.title);
            this.groupBox1.Controls.Add(this.artist);
            this.groupBox1.Location = new System.Drawing.Point(357, 73);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(445, 383);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            // 
            // content
            // 
            this.content.Location = new System.Drawing.Point(6, 80);
            this.content.Name = "content";
            this.content.ReadOnly = true;
            this.content.Size = new System.Drawing.Size(433, 297);
            this.content.TabIndex = 2;
            this.content.Text = "";
            // 
            // title
            // 
            this.title.Location = new System.Drawing.Point(6, 49);
            this.title.Name = "title";
            this.title.ReadOnly = true;
            this.title.Size = new System.Drawing.Size(433, 25);
            this.title.TabIndex = 1;
            this.title.Text = "";
            // 
            // artist
            // 
            this.artist.Location = new System.Drawing.Point(6, 18);
            this.artist.Name = "artist";
            this.artist.ReadOnly = true;
            this.artist.Size = new System.Drawing.Size(433, 25);
            this.artist.TabIndex = 0;
            this.artist.Text = "";
            // 
            // BackBtn
            // 
            this.BackBtn.Location = new System.Drawing.Point(357, 44);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.Size = new System.Drawing.Size(75, 23);
            this.BackBtn.TabIndex = 17;
            this.BackBtn.Text = "back";
            this.BackBtn.UseVisualStyleBackColor = true;
            this.BackBtn.Visible = false;
            this.BackBtn.Click += new System.EventHandler(this.BackBtn_Click);
            // 
            // Order
            // 
            this.Order.Location = new System.Drawing.Point(519, 13);
            this.Order.Name = "Order";
            this.Order.Size = new System.Drawing.Size(75, 23);
            this.Order.TabIndex = 18;
            this.Order.Text = "Order";
            this.Order.UseVisualStyleBackColor = true;
            this.Order.Click += new System.EventHandler(this.Order_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 480);
            this.Controls.Add(this.Order);
            this.Controls.Add(this.BackBtn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.ContentRadio);
            this.Controls.Add(this.ArtistRadio);
            this.Controls.Add(this.TitleRadio);
            this.Controls.Add(this.AllRadio);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.hyBtn);
            this.Controls.Add(this.jyBtn);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.ImgBtn);
            this.Controls.Add(this.TxtBtn);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button TxtBtn;
        private System.Windows.Forms.Button jyBtn;
        private System.Windows.Forms.Button hyBtn;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button ImgBtn;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.RadioButton AllRadio;
        private System.Windows.Forms.RadioButton TitleRadio;
        private System.Windows.Forms.RadioButton ArtistRadio;
        private System.Windows.Forms.RadioButton ContentRadio;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox content;
        private System.Windows.Forms.RichTextBox title;
        private System.Windows.Forms.RichTextBox artist;
        private System.Windows.Forms.Button BackBtn;
        private System.Windows.Forms.Button Order;
    }
}

