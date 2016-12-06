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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ImgBtn = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.NameRadio = new System.Windows.Forms.RadioButton();
            this.SpeciesRadio = new System.Windows.Forms.RadioButton();
            this.SymptomRadio = new System.Windows.Forms.RadioButton();
            this.EcologyRadio = new System.Windows.Forms.RadioButton();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Species = new System.Windows.Forms.RichTextBox();
            this.Ecology = new System.Windows.Forms.RichTextBox();
            this.BackBtn = new System.Windows.Forms.Button();
            this.symptom = new System.Windows.Forms.RichTextBox();
            this.Name1 = new System.Windows.Forms.RichTextBox();
            this.ImageLoad = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(9, 20);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(244, 21);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // TxtBtn
            // 
            this.TxtBtn.Location = new System.Drawing.Point(257, 17);
            this.TxtBtn.Name = "TxtBtn";
            this.TxtBtn.Size = new System.Drawing.Size(75, 23);
            this.TxtBtn.TabIndex = 2;
            this.TxtBtn.Text = "text btn";
            this.TxtBtn.UseVisualStyleBackColor = true;
            this.TxtBtn.Click += new System.EventHandler(this.TxtBtn_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(9, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(243, 20);
            this.comboBox1.TabIndex = 10;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.comboBox1.SelectionChangeCommitted += new System.EventHandler(this.comboBox1_SelectionChangeCommitted);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(7, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(325, 337);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // ImgBtn
            // 
            this.ImgBtn.Location = new System.Drawing.Point(124, 353);
            this.ImgBtn.Name = "ImgBtn";
            this.ImgBtn.Size = new System.Drawing.Size(101, 23);
            this.ImgBtn.TabIndex = 3;
            this.ImgBtn.Text = "Query Image Load";
            this.ImgBtn.UseVisualStyleBackColor = true;
            this.ImgBtn.Click += new System.EventHandler(this.ImgBtn_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(6, 20);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(124, 74);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(136, 20);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(124, 74);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 5;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Location = new System.Drawing.Point(266, 20);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(124, 74);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 6;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Location = new System.Drawing.Point(396, 20);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(124, 73);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 7;
            this.pictureBox5.TabStop = false;
            // 
            // NameRadio
            // 
            this.NameRadio.AutoSize = true;
            this.NameRadio.Location = new System.Drawing.Point(7, 48);
            this.NameRadio.Name = "NameRadio";
            this.NameRadio.Size = new System.Drawing.Size(57, 16);
            this.NameRadio.TabIndex = 11;
            this.NameRadio.TabStop = true;
            this.NameRadio.Text = "Name";
            this.NameRadio.UseVisualStyleBackColor = true;
            // 
            // SpeciesRadio
            // 
            this.SpeciesRadio.AutoSize = true;
            this.SpeciesRadio.Location = new System.Drawing.Point(70, 48);
            this.SpeciesRadio.Name = "SpeciesRadio";
            this.SpeciesRadio.Size = new System.Drawing.Size(69, 16);
            this.SpeciesRadio.TabIndex = 12;
            this.SpeciesRadio.TabStop = true;
            this.SpeciesRadio.Text = "Species";
            this.SpeciesRadio.UseVisualStyleBackColor = true;
            // 
            // SymptomRadio
            // 
            this.SymptomRadio.AutoSize = true;
            this.SymptomRadio.Location = new System.Drawing.Point(145, 48);
            this.SymptomRadio.Name = "SymptomRadio";
            this.SymptomRadio.Size = new System.Drawing.Size(77, 16);
            this.SymptomRadio.TabIndex = 13;
            this.SymptomRadio.TabStop = true;
            this.SymptomRadio.Text = "Symptom";
            this.SymptomRadio.UseVisualStyleBackColor = true;
            // 
            // EcologyRadio
            // 
            this.EcologyRadio.AutoSize = true;
            this.EcologyRadio.Location = new System.Drawing.Point(228, 48);
            this.EcologyRadio.Name = "EcologyRadio";
            this.EcologyRadio.Size = new System.Drawing.Size(69, 16);
            this.EcologyRadio.TabIndex = 14;
            this.EcologyRadio.TabStop = true;
            this.EcologyRadio.Text = "Ecology";
            this.EcologyRadio.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(362, 96);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(436, 376);
            this.listBox1.TabIndex = 15;
            this.listBox1.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Species);
            this.groupBox1.Controls.Add(this.Ecology);
            this.groupBox1.Controls.Add(this.BackBtn);
            this.groupBox1.Controls.Add(this.symptom);
            this.groupBox1.Controls.Add(this.Name1);
            this.groupBox1.Location = new System.Drawing.Point(357, 87);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(445, 382);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Text Result";
            // 
            // Species
            // 
            this.Species.Location = new System.Drawing.Point(182, 18);
            this.Species.Name = "Species";
            this.Species.ReadOnly = true;
            this.Species.Size = new System.Drawing.Size(173, 25);
            this.Species.TabIndex = 3;
            this.Species.Text = "";
            // 
            // Ecology
            // 
            this.Ecology.Location = new System.Drawing.Point(6, 211);
            this.Ecology.Name = "Ecology";
            this.Ecology.ReadOnly = true;
            this.Ecology.Size = new System.Drawing.Size(433, 166);
            this.Ecology.TabIndex = 2;
            this.Ecology.Text = "";
            // 
            // BackBtn
            // 
            this.BackBtn.Location = new System.Drawing.Point(361, 16);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.Size = new System.Drawing.Size(75, 23);
            this.BackBtn.TabIndex = 17;
            this.BackBtn.Text = "back";
            this.BackBtn.UseVisualStyleBackColor = true;
            this.BackBtn.Visible = false;
            this.BackBtn.Click += new System.EventHandler(this.BackBtn_Click);
            // 
            // symptom
            // 
            this.symptom.Location = new System.Drawing.Point(6, 49);
            this.symptom.Name = "symptom";
            this.symptom.ReadOnly = true;
            this.symptom.Size = new System.Drawing.Size(433, 156);
            this.symptom.TabIndex = 1;
            this.symptom.Text = "";
            // 
            // Name1
            // 
            this.Name1.Location = new System.Drawing.Point(6, 18);
            this.Name1.Name = "Name1";
            this.Name1.ReadOnly = true;
            this.Name1.Size = new System.Drawing.Size(170, 25);
            this.Name1.TabIndex = 0;
            this.Name1.Text = "";
            // 
            // ImageLoad
            // 
            this.ImageLoad.Location = new System.Drawing.Point(231, 353);
            this.ImageLoad.Name = "ImageLoad";
            this.ImageLoad.Size = new System.Drawing.Size(101, 23);
            this.ImageLoad.TabIndex = 18;
            this.ImageLoad.Text = "Image Search";
            this.ImageLoad.UseVisualStyleBackColor = true;
            this.ImageLoad.Click += new System.EventHandler(this.Order_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(7, 357);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(60, 16);
            this.checkBox1.TabIndex = 19;
            this.checkBox1.Text = "Shape";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(64, 357);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(54, 16);
            this.checkBox2.TabIndex = 20;
            this.checkBox2.Text = "Color";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pictureBox7);
            this.groupBox2.Controls.Add(this.pictureBox6);
            this.groupBox2.Controls.Add(this.pictureBox2);
            this.groupBox2.Controls.Add(this.pictureBox3);
            this.groupBox2.Controls.Add(this.pictureBox4);
            this.groupBox2.Controls.Add(this.pictureBox5);
            this.groupBox2.Location = new System.Drawing.Point(13, 475);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(789, 100);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Image Result";
            // 
            // pictureBox7
            // 
            this.pictureBox7.Location = new System.Drawing.Point(656, 20);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(124, 73);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 9;
            this.pictureBox7.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Location = new System.Drawing.Point(526, 20);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(124, 73);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 8;
            this.pictureBox6.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.pictureBox1);
            this.groupBox3.Controls.Add(this.ImgBtn);
            this.groupBox3.Controls.Add(this.checkBox2);
            this.groupBox3.Controls.Add(this.ImageLoad);
            this.groupBox3.Controls.Add(this.checkBox1);
            this.groupBox3.Location = new System.Drawing.Point(13, 87);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(338, 382);
            this.groupBox3.TabIndex = 22;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Image Search";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.TxtBtn);
            this.groupBox4.Controls.Add(this.textBox1);
            this.groupBox4.Controls.Add(this.comboBox1);
            this.groupBox4.Controls.Add(this.NameRadio);
            this.groupBox4.Controls.Add(this.SpeciesRadio);
            this.groupBox4.Controls.Add(this.EcologyRadio);
            this.groupBox4.Controls.Add(this.SymptomRadio);
            this.groupBox4.Location = new System.Drawing.Point(13, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(338, 73);
            this.groupBox4.TabIndex = 23;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Text Search";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.pictureBox8);
            this.groupBox5.Location = new System.Drawing.Point(357, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(442, 73);
            this.groupBox5.TabIndex = 24;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Text Result Image";
            // 
            // pictureBox8
            // 
            this.pictureBox8.Location = new System.Drawing.Point(7, 17);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(100, 50);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox8.TabIndex = 0;
            this.pictureBox8.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 585);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button TxtBtn;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button ImgBtn;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.RadioButton NameRadio;
        private System.Windows.Forms.RadioButton SpeciesRadio;
        private System.Windows.Forms.RadioButton SymptomRadio;
        private System.Windows.Forms.RadioButton EcologyRadio;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox Ecology;
        private System.Windows.Forms.RichTextBox symptom;
        private System.Windows.Forms.RichTextBox Name1;
        private System.Windows.Forms.Button BackBtn;
        private System.Windows.Forms.Button ImageLoad;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.RichTextBox Species;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.PictureBox pictureBox8;
    }
}

