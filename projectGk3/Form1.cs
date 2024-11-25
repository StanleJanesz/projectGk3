namespace projectGk3
{
    public partial class Form1 : Form
    {
        public Bitmap Photo { get; set; }
        public Bitmap PhotoAfter { get; set; }
        public Bitmap HistogramR { get; set; }
        public Bitmap HistogramG { get; set; }
        public Bitmap HistogramB { get; set; }
        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            float[,] Filter = new float[,]
            {
            { (float)numericUpDown11.Value, (float)numericUpDown12.Value, (float)numericUpDown13.Value},
            { (float)numericUpDown21.Value, (float)numericUpDown22.Value, (float)numericUpDown23.Value},
            { (float)numericUpDown31.Value, (float)numericUpDown32.Value, (float)numericUpDown33.Value}
            };
            float OffSet = (float)numericUpDownOffSet.Value;
            float divisor;
            if (checkBoxAutoDivisor.Checked )
                 divisor = 0;
            else
                 divisor = (float)numericUpDowndivisor.Value;
            float offSet = (float)numericUpDownOffSet.Value;   
            PhotoAfter = ConvolutionFilter.ApplyConvolutionFilter(Photo, Filter, offSet, divisor);
            pictureBox1.Image = PhotoAfter;
            CreateHistograms(PhotoAfter);
        }

        private void buttonPhotoLoad_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Image files|*.bmp;*.jpg;*.gif;*.png;*.tif|All files|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Photo = new Bitmap(openFileDialog.FileName, true);
                }
            }
            pictureBox1.Image = Photo;
            CreateHistograms(Photo);
        }
        void CreateHistograms(Bitmap photo)
        {
            Bitmap[] histograms = Histogram.GenerateHistogram(photo);
            HistogramR = histograms[0];
            HistogramG = histograms[1];
            HistogramB = histograms[2];
            pictureBox2.Image = ScaleImage(HistogramR, pictureBox2.Width, pictureBox2.Height);
            pictureBox3.Image = ScaleImage(HistogramG, pictureBox2.Width, pictureBox2.Height);
            pictureBox4.Image = ScaleImage(HistogramB, pictureBox2.Width, pictureBox2.Height);
        }
        public Bitmap ScaleImage(Bitmap bmp, int maxWidth, int maxHeight)
        {
            var ratioX = (double)maxWidth / bmp.Width;
            var ratioY = (double)maxHeight / bmp.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(bmp.Width * ratio);
            var newHeight = (int)(bmp.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);

            using (var graphics = Graphics.FromImage(newImage))
                graphics.DrawImage(bmp, 0, 0, newWidth, newHeight);

            return newImage;
        }
        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioButtonBlurr_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonBlurr.Checked)
            {
                PhotoAfter = ConvolutionFilter.ApplyConvolutionFilter(Photo, ConvolutionFilter.BlurFilter, 0,-1);
                pictureBox1.Image = PhotoAfter;
                CreateHistograms(PhotoAfter);
            }
        }

        private void buttonClean_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Photo;
        }

        private void radioButtonSharpen_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonSharpen.Checked)
            {
                PhotoAfter = ConvolutionFilter.ApplyConvolutionFilter(Photo, ConvolutionFilter.SharpenFilter, 0, -1);
                pictureBox1.Image = PhotoAfter;
                CreateHistograms(PhotoAfter);
            }
        }

        private void radioButtonFlat_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonFlat.Checked)
            {
                PhotoAfter = ConvolutionFilter.ApplyConvolutionFilter(Photo, ConvolutionFilter.FlatenFilter, 0, -1);
                pictureBox1.Image = PhotoAfter;
                CreateHistograms(PhotoAfter);
            }
        }

        private void radioButtonLaplace_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonLaplace.Checked)
            {
                PhotoAfter = ConvolutionFilter.ApplyConvolutionFilter(Photo, ConvolutionFilter.LaplaceFilter, 0, -1);
                pictureBox1.Image = PhotoAfter;
                CreateHistograms(PhotoAfter);
            }
        }

        private void radioButtonIdentity_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonIdentity.Checked)
            {
                PhotoAfter = ConvolutionFilter.ApplyConvolutionFilter(Photo, ConvolutionFilter.IdentityFilter, 0,-1);
                pictureBox1.Image = PhotoAfter;
                CreateHistograms(PhotoAfter);
            }
        }

        private void radioButtonOwn_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonOwn.Checked)
            {
                EnableOwn(true);
            }
            else
            {
                EnableOwn(false) ;
            }
        }
        public void EnableOwn(bool state)
        {
            numericUpDown31.Enabled = state;
            numericUpDown32.Enabled = state;
            numericUpDown33.Enabled = state;
            numericUpDown21.Enabled = state;
            numericUpDown22.Enabled = state;
            numericUpDown23.Enabled = state;
            numericUpDown11.Enabled = state;
            numericUpDown12.Enabled = state;
            numericUpDown13.Enabled = state;
            checkBoxAutoDivisor.Enabled = state;
            checkBoxAutoDivisor.Checked = true;
            numericUpDownOffSet.Enabled = state;
        }
        private void checkBoxAutoDivisor_CheckedChanged(object sender, EventArgs e)
        {
            if ( checkBoxAutoDivisor.Checked)
            {
                numericUpDowndivisor.Enabled = false;
            }
            else
               {
                numericUpDowndivisor.Enabled = true;
            }
        }
    }
}

