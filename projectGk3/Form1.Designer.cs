namespace projectGk3
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox4 = new PictureBox();
            groupBox1 = new GroupBox();
            label3 = new Label();
            buttonClean = new Button();
            trackBar1 = new TrackBar();
            radioButtonFullImage = new RadioButton();
            radioButtonBrush = new RadioButton();
            groupBoxFilter = new GroupBox();
            checkBoxAutoDivisor = new CheckBox();
            label2 = new Label();
            label1 = new Label();
            numericUpDowndivisor = new NumericUpDown();
            numericUpDownOffSet = new NumericUpDown();
            numericUpDown33 = new NumericUpDown();
            numericUpDown23 = new NumericUpDown();
            numericUpDown32 = new NumericUpDown();
            numericUpDown22 = new NumericUpDown();
            numericUpDown31 = new NumericUpDown();
            numericUpDown21 = new NumericUpDown();
            numericUpDown13 = new NumericUpDown();
            numericUpDown12 = new NumericUpDown();
            numericUpDown11 = new NumericUpDown();
            radioButtonOwn = new RadioButton();
            radioButtonLaplace = new RadioButton();
            radioButtonFlat = new RadioButton();
            radioButtonSharpen = new RadioButton();
            radioButtonBlurr = new RadioButton();
            radioButtonIdentity = new RadioButton();
            button1 = new Button();
            buttonPhotoLoad = new Button();
            panel2 = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            groupBoxFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDowndivisor).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownOffSet).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown33).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown23).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown32).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown22).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown31).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown21).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown13).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown12).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown11).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(3, 5);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(563, 529);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            pictureBox1.Paint += pictureBox1_Paint;
            pictureBox1.MouseDown += pictureBox1_MouseDown;
            pictureBox1.MouseMove += pictureBox1_MouseMove;
            pictureBox1.MouseUp += pictureBox1_MouseUp;
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new Point(601, 12);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(191, 136);
            pictureBox2.TabIndex = 3;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Location = new Point(601, 154);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(191, 135);
            pictureBox3.TabIndex = 4;
            pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.Location = new Point(601, 295);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(191, 139);
            pictureBox4.TabIndex = 5;
            pictureBox4.TabStop = false;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(buttonClean);
            groupBox1.Controls.Add(trackBar1);
            groupBox1.Controls.Add(radioButtonFullImage);
            groupBox1.Controls.Add(radioButtonBrush);
            groupBox1.Location = new Point(823, 18);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(238, 119);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Obszar Zastosowania Filtra";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(165, 68);
            label3.Name = "label3";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 5;
            label3.Text = "label3";
            // 
            // buttonClean
            // 
            buttonClean.Location = new Point(148, 96);
            buttonClean.Name = "buttonClean";
            buttonClean.Size = new Size(75, 23);
            buttonClean.TabIndex = 4;
            buttonClean.Text = "Wyczyść";
            buttonClean.UseVisualStyleBackColor = true;
            buttonClean.Click += buttonClean_Click;
            // 
            // trackBar1
            // 
            trackBar1.Location = new Point(6, 68);
            trackBar1.Maximum = 300;
            trackBar1.Minimum = 1;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(153, 45);
            trackBar1.TabIndex = 2;
            trackBar1.Value = 1;
            trackBar1.Scroll += trackBar1_Scroll;
            // 
            // radioButtonFullImage
            // 
            radioButtonFullImage.AutoSize = true;
            radioButtonFullImage.Location = new Point(6, 47);
            radioButtonFullImage.Name = "radioButtonFullImage";
            radioButtonFullImage.Size = new Size(82, 19);
            radioButtonFullImage.TabIndex = 1;
            radioButtonFullImage.TabStop = true;
            radioButtonFullImage.Text = "Cały Obraz";
            radioButtonFullImage.UseVisualStyleBackColor = true;
            // 
            // radioButtonBrush
            // 
            radioButtonBrush.AutoSize = true;
            radioButtonBrush.Location = new Point(6, 22);
            radioButtonBrush.Name = "radioButtonBrush";
            radioButtonBrush.Size = new Size(101, 19);
            radioButtonBrush.TabIndex = 0;
            radioButtonBrush.TabStop = true;
            radioButtonBrush.Text = "Pędzel Kołowy";
            radioButtonBrush.UseVisualStyleBackColor = true;
            radioButtonBrush.CheckedChanged += radioButtonBrush_CheckedChanged;
            // 
            // groupBoxFilter
            // 
            groupBoxFilter.Controls.Add(checkBoxAutoDivisor);
            groupBoxFilter.Controls.Add(label2);
            groupBoxFilter.Controls.Add(label1);
            groupBoxFilter.Controls.Add(numericUpDowndivisor);
            groupBoxFilter.Controls.Add(numericUpDownOffSet);
            groupBoxFilter.Controls.Add(numericUpDown33);
            groupBoxFilter.Controls.Add(numericUpDown23);
            groupBoxFilter.Controls.Add(numericUpDown32);
            groupBoxFilter.Controls.Add(numericUpDown22);
            groupBoxFilter.Controls.Add(numericUpDown31);
            groupBoxFilter.Controls.Add(numericUpDown21);
            groupBoxFilter.Controls.Add(numericUpDown13);
            groupBoxFilter.Controls.Add(numericUpDown12);
            groupBoxFilter.Controls.Add(numericUpDown11);
            groupBoxFilter.Controls.Add(radioButtonOwn);
            groupBoxFilter.Controls.Add(radioButtonLaplace);
            groupBoxFilter.Controls.Add(radioButtonFlat);
            groupBoxFilter.Controls.Add(radioButtonSharpen);
            groupBoxFilter.Controls.Add(radioButtonBlurr);
            groupBoxFilter.Controls.Add(radioButtonIdentity);
            groupBoxFilter.Location = new Point(823, 143);
            groupBoxFilter.Name = "groupBoxFilter";
            groupBoxFilter.Size = new Size(238, 348);
            groupBoxFilter.TabIndex = 7;
            groupBoxFilter.TabStop = false;
            groupBoxFilter.Text = "Wybór Filtra Macierzowego";
            groupBoxFilter.Enter += groupBox2_Enter;
            // 
            // checkBoxAutoDivisor
            // 
            checkBoxAutoDivisor.AutoSize = true;
            checkBoxAutoDivisor.Enabled = false;
            checkBoxAutoDivisor.Location = new Point(15, 323);
            checkBoxAutoDivisor.Name = "checkBoxAutoDivisor";
            checkBoxAutoDivisor.Size = new Size(224, 19);
            checkBoxAutoDivisor.TabIndex = 20;
            checkBoxAutoDivisor.Text = "Automatyczne wyznaczanie dzielnika ";
            checkBoxAutoDivisor.UseVisualStyleBackColor = true;
            checkBoxAutoDivisor.CheckedChanged += checkBoxAutoDivisor_CheckedChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 299);
            label2.Name = "label2";
            label2.Size = new Size(48, 15);
            label2.TabIndex = 19;
            label2.Text = "Dzielnik";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 270);
            label1.Name = "label1";
            label1.Size = new Size(72, 15);
            label1.TabIndex = 18;
            label1.Text = "Przesunięcie";
            // 
            // numericUpDowndivisor
            // 
            numericUpDowndivisor.DecimalPlaces = 5;
            numericUpDowndivisor.Enabled = false;
            numericUpDowndivisor.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numericUpDowndivisor.Location = new Point(118, 297);
            numericUpDowndivisor.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numericUpDowndivisor.Minimum = new decimal(new int[] { 1000, 0, 0, int.MinValue });
            numericUpDowndivisor.Name = "numericUpDowndivisor";
            numericUpDowndivisor.Size = new Size(120, 23);
            numericUpDowndivisor.TabIndex = 17;
            // 
            // numericUpDownOffSet
            // 
            numericUpDownOffSet.Location = new Point(116, 268);
            numericUpDownOffSet.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericUpDownOffSet.Minimum = new decimal(new int[] { 255, 0, 0, int.MinValue });
            numericUpDownOffSet.Name = "numericUpDownOffSet";
            numericUpDownOffSet.Size = new Size(120, 23);
            numericUpDownOffSet.TabIndex = 16;
            // 
            // numericUpDown33
            // 
            numericUpDown33.DecimalPlaces = 5;
            numericUpDown33.Enabled = false;
            numericUpDown33.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numericUpDown33.Location = new Point(160, 230);
            numericUpDown33.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numericUpDown33.Minimum = new decimal(new int[] { 1000, 0, 0, int.MinValue });
            numericUpDown33.Name = "numericUpDown33";
            numericUpDown33.Size = new Size(78, 23);
            numericUpDown33.TabIndex = 15;
            // 
            // numericUpDown23
            // 
            numericUpDown23.DecimalPlaces = 5;
            numericUpDown23.Enabled = false;
            numericUpDown23.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numericUpDown23.Location = new Point(160, 201);
            numericUpDown23.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numericUpDown23.Minimum = new decimal(new int[] { 1000, 0, 0, int.MinValue });
            numericUpDown23.Name = "numericUpDown23";
            numericUpDown23.Size = new Size(76, 23);
            numericUpDown23.TabIndex = 14;
            // 
            // numericUpDown32
            // 
            numericUpDown32.DecimalPlaces = 5;
            numericUpDown32.Enabled = false;
            numericUpDown32.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numericUpDown32.Location = new Point(83, 230);
            numericUpDown32.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numericUpDown32.Minimum = new decimal(new int[] { 1000, 0, 0, int.MinValue });
            numericUpDown32.Name = "numericUpDown32";
            numericUpDown32.Size = new Size(71, 23);
            numericUpDown32.TabIndex = 13;
            // 
            // numericUpDown22
            // 
            numericUpDown22.DecimalPlaces = 5;
            numericUpDown22.Enabled = false;
            numericUpDown22.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numericUpDown22.Location = new Point(83, 201);
            numericUpDown22.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numericUpDown22.Minimum = new decimal(new int[] { 1000, 0, 0, int.MinValue });
            numericUpDown22.Name = "numericUpDown22";
            numericUpDown22.Size = new Size(71, 23);
            numericUpDown22.TabIndex = 12;
            numericUpDown22.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numericUpDown31
            // 
            numericUpDown31.DecimalPlaces = 5;
            numericUpDown31.Enabled = false;
            numericUpDown31.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numericUpDown31.Location = new Point(6, 230);
            numericUpDown31.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numericUpDown31.Minimum = new decimal(new int[] { 1000, 0, 0, int.MinValue });
            numericUpDown31.Name = "numericUpDown31";
            numericUpDown31.Size = new Size(71, 23);
            numericUpDown31.TabIndex = 11;
            // 
            // numericUpDown21
            // 
            numericUpDown21.DecimalPlaces = 5;
            numericUpDown21.Enabled = false;
            numericUpDown21.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numericUpDown21.Location = new Point(6, 201);
            numericUpDown21.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numericUpDown21.Minimum = new decimal(new int[] { 1000, 0, 0, int.MinValue });
            numericUpDown21.Name = "numericUpDown21";
            numericUpDown21.Size = new Size(71, 23);
            numericUpDown21.TabIndex = 8;
            // 
            // numericUpDown13
            // 
            numericUpDown13.DecimalPlaces = 5;
            numericUpDown13.Enabled = false;
            numericUpDown13.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numericUpDown13.Location = new Point(160, 172);
            numericUpDown13.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numericUpDown13.Minimum = new decimal(new int[] { 1000, 0, 0, int.MinValue });
            numericUpDown13.Name = "numericUpDown13";
            numericUpDown13.Size = new Size(76, 23);
            numericUpDown13.TabIndex = 10;
            // 
            // numericUpDown12
            // 
            numericUpDown12.DecimalPlaces = 5;
            numericUpDown12.Enabled = false;
            numericUpDown12.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numericUpDown12.Location = new Point(83, 172);
            numericUpDown12.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numericUpDown12.Minimum = new decimal(new int[] { 1000, 0, 0, int.MinValue });
            numericUpDown12.Name = "numericUpDown12";
            numericUpDown12.Size = new Size(71, 23);
            numericUpDown12.TabIndex = 9;
            // 
            // numericUpDown11
            // 
            numericUpDown11.DecimalPlaces = 5;
            numericUpDown11.Enabled = false;
            numericUpDown11.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numericUpDown11.Location = new Point(6, 172);
            numericUpDown11.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numericUpDown11.Minimum = new decimal(new int[] { 1000, 0, 0, int.MinValue });
            numericUpDown11.Name = "numericUpDown11";
            numericUpDown11.Size = new Size(71, 23);
            numericUpDown11.TabIndex = 8;
            numericUpDown11.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // radioButtonOwn
            // 
            radioButtonOwn.AutoSize = true;
            radioButtonOwn.Location = new Point(6, 147);
            radioButtonOwn.Name = "radioButtonOwn";
            radioButtonOwn.Size = new Size(63, 19);
            radioButtonOwn.TabIndex = 5;
            radioButtonOwn.TabStop = true;
            radioButtonOwn.Text = "Własny";
            radioButtonOwn.UseVisualStyleBackColor = true;
            radioButtonOwn.CheckedChanged += radioButtonOwn_CheckedChanged;
            // 
            // radioButtonLaplace
            // 
            radioButtonLaplace.AutoSize = true;
            radioButtonLaplace.Location = new Point(6, 122);
            radioButtonLaplace.Name = "radioButtonLaplace";
            radioButtonLaplace.Size = new Size(78, 19);
            radioButtonLaplace.TabIndex = 4;
            radioButtonLaplace.TabStop = true;
            radioButtonLaplace.Text = "Krawędzie";
            radioButtonLaplace.UseVisualStyleBackColor = true;
            radioButtonLaplace.CheckedChanged += radioButtonLaplace_CheckedChanged;
            // 
            // radioButtonFlat
            // 
            radioButtonFlat.AutoSize = true;
            radioButtonFlat.Location = new Point(6, 97);
            radioButtonFlat.Name = "radioButtonFlat";
            radioButtonFlat.Size = new Size(92, 19);
            radioButtonFlat.TabIndex = 3;
            radioButtonFlat.TabStop = true;
            radioButtonFlat.Text = "Płaskorzeźba";
            radioButtonFlat.UseVisualStyleBackColor = true;
            radioButtonFlat.CheckedChanged += radioButtonFlat_CheckedChanged;
            // 
            // radioButtonSharpen
            // 
            radioButtonSharpen.AutoSize = true;
            radioButtonSharpen.Location = new Point(6, 72);
            radioButtonSharpen.Name = "radioButtonSharpen";
            radioButtonSharpen.Size = new Size(87, 19);
            radioButtonSharpen.TabIndex = 2;
            radioButtonSharpen.TabStop = true;
            radioButtonSharpen.Text = "wyostrzenie";
            radioButtonSharpen.UseVisualStyleBackColor = true;
            radioButtonSharpen.CheckedChanged += radioButtonSharpen_CheckedChanged;
            // 
            // radioButtonBlurr
            // 
            radioButtonBlurr.AutoSize = true;
            radioButtonBlurr.Location = new Point(6, 47);
            radioButtonBlurr.Name = "radioButtonBlurr";
            radioButtonBlurr.Size = new Size(76, 19);
            radioButtonBlurr.TabIndex = 1;
            radioButtonBlurr.TabStop = true;
            radioButtonBlurr.Text = "Rozmycie";
            radioButtonBlurr.UseVisualStyleBackColor = true;
            radioButtonBlurr.CheckedChanged += radioButtonBlurr_CheckedChanged;
            // 
            // radioButtonIdentity
            // 
            radioButtonIdentity.AutoSize = true;
            radioButtonIdentity.Location = new Point(6, 22);
            radioButtonIdentity.Name = "radioButtonIdentity";
            radioButtonIdentity.Size = new Size(94, 19);
            radioButtonIdentity.TabIndex = 0;
            radioButtonIdentity.TabStop = true;
            radioButtonIdentity.Text = "Identyczność";
            radioButtonIdentity.UseVisualStyleBackColor = true;
            radioButtonIdentity.CheckedChanged += radioButtonIdentity_CheckedChanged;
            // 
            // button1
            // 
            button1.Location = new Point(823, 525);
            button1.Name = "button1";
            button1.Size = new Size(223, 36);
            button1.TabIndex = 8;
            button1.Text = "Zastosuj";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // buttonPhotoLoad
            // 
            buttonPhotoLoad.Location = new Point(601, 455);
            buttonPhotoLoad.Name = "buttonPhotoLoad";
            buttonPhotoLoad.Size = new Size(200, 39);
            buttonPhotoLoad.TabIndex = 9;
            buttonPhotoLoad.Text = "Wczytaj Zdjęcie";
            buttonPhotoLoad.UseVisualStyleBackColor = true;
            buttonPhotoLoad.Click += buttonPhotoLoad_Click;
            // 
            // panel2
            // 
            panel2.AutoScroll = true;
            panel2.Controls.Add(pictureBox1);
            panel2.Location = new Point(9, 7);
            panel2.Name = "panel2";
            panel2.Size = new Size(569, 537);
            panel2.TabIndex = 11;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1064, 573);
            Controls.Add(panel2);
            Controls.Add(buttonPhotoLoad);
            Controls.Add(button1);
            Controls.Add(groupBoxFilter);
            Controls.Add(groupBox1);
            Controls.Add(pictureBox4);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load_1;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            groupBoxFilter.ResumeLayout(false);
            groupBoxFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDowndivisor).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownOffSet).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown33).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown23).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown32).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown22).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown31).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown21).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown13).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown12).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown11).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private GroupBox groupBox1;
        private GroupBox groupBoxFilter;
        private Button buttonClean;
        private TrackBar trackBar1;
        private RadioButton radioButtonFullImage;
        private RadioButton radioButtonBrush;
        private RadioButton radioButtonOwn;
        private RadioButton radioButtonLaplace;
        private RadioButton radioButtonFlat;
        private RadioButton radioButtonSharpen;
        private RadioButton radioButtonBlurr;
        private RadioButton radioButtonIdentity;
        private NumericUpDown numericUpDown11;
        private NumericUpDown numericUpDown22;
        private NumericUpDown numericUpDown31;
        private NumericUpDown numericUpDown21;
        private NumericUpDown numericUpDown13;
        private NumericUpDown numericUpDown12;
        private Label label2;
        private Label label1;
        private NumericUpDown numericUpDowndivisor;
        private NumericUpDown numericUpDownOffSet;
        private NumericUpDown numericUpDown33;
        private NumericUpDown numericUpDown23;
        private NumericUpDown numericUpDown32;
        private CheckBox checkBoxAutoDivisor;
        private Button button1;
        private Button buttonPhotoLoad;
        private Panel panel2;
        private Label label3;
    }
}
