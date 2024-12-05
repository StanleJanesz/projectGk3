using System.Windows.Forms;

namespace projectGk3
{
    public partial class Form1 : Form
    {
        public Bitmap Photo { get; set; }
        public Bitmap PhotoAfter { get; set; }
        public Bitmap HistogramR { get; set; }
        public Bitmap HistogramG { get; set; }
        public Bitmap HistogramB { get; set; }
        float[,] Filter;
        public Form1()
        {

            InitializeComponent();
            Filter = new float[,]
               {
            { (float)numericUpDown11.Value, (float)numericUpDown12.Value, (float)numericUpDown13.Value},
            { (float)numericUpDown21.Value, (float)numericUpDown22.Value, (float)numericUpDown23.Value},
            { (float)numericUpDown31.Value, (float)numericUpDown32.Value, (float)numericUpDown33.Value}
               };
        }
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButtonOwn.Checked)
            {
                Filter = new float[,]
                   {
            { (float)numericUpDown11.Value, (float)numericUpDown12.Value, (float)numericUpDown13.Value},
            { (float)numericUpDown21.Value, (float)numericUpDown22.Value, (float)numericUpDown23.Value},
            { (float)numericUpDown31.Value, (float)numericUpDown32.Value, (float)numericUpDown33.Value}
                   };
            }
            float divisor;
            if (checkBoxAutoDivisor.Checked)
                divisor = 0;
            else
                divisor = (float)numericUpDowndivisor.Value;
            float offSet = (float)numericUpDownOffSet.Value;
            if (radioButtonFullImage.Checked)
            {

                PhotoAfter = ConvolutionFilter.ProcessUsingLockbits(PhotoAfter, Filter, offSet, divisor);
                // PhotoAfter = ConvolutionFilter.ApplyConvolutionFilter(PhotoAfter, Filter, offSet, divisor);
            }
            else if (radioButtonBrush.Checked)
            {

                PhotoAfter = ConvolutionFilter.ApplyConvolutionFilterCircle(PhotoAfter, Filter, offSet, divisor, mouseX, mouseY, trackBar1.Value / 2);
            }
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
            PhotoAfter =new Bitmap(Photo);
            pictureBox1.Image = PhotoAfter;
            brushColor = new bool[Photo.Width, Photo.Height];
            CreateHistograms(PhotoAfter);
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
        bool isStill = false;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (isStill) isStill = false;
            else isStill = true;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void radioButtonBlurr_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonBlurr.Checked)
            {
                Filter = ConvolutionFilter.BlurFilter;
            }
        }

        private void buttonClean_Click(object sender, EventArgs e)
        {
            PhotoAfter = new Bitmap(Photo);
            pictureBox1.Image = PhotoAfter;
            CreateHistograms(PhotoAfter);
        }

        private void radioButtonSharpen_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonSharpen.Checked)
            {
                Filter = ConvolutionFilter.SharpenFilter;
            }
        }

        private void radioButtonFlat_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonFlat.Checked)
            {
                Filter = ConvolutionFilter.FlatenFilter;
            }
        }

        private void radioButtonLaplace_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonLaplace.Checked)
            {
                Filter = ConvolutionFilter.LaplaceFilter;
            }
        }

        private void radioButtonIdentity_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonIdentity.Checked)
            {
                Filter = ConvolutionFilter.IdentityFilter;
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
                EnableOwn(false);
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
            //checkBoxAutoDivisor.Checked = true;
            numericUpDownOffSet.Enabled = true;
        }
        private void checkBoxAutoDivisor_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAutoDivisor.Checked)
            {
                numericUpDowndivisor.Value = 0;
                numericUpDowndivisor.Enabled = false;
            }
            else
            {
                numericUpDowndivisor.Enabled = true;
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label3.Text = trackBar1.Value.ToString();
        }
        int mouseX;
        int mouseY;
        bool follow = false;
        bool[,] brushColor;
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            isStill = false;
            if (!isStill)
            {
                mouseX = e.X;
                mouseY = e.Y;
            }
            if (follow)
            {
                int startX = Math.Max(0, mouseX - trackBar1.Value/2);
                int endX = Math.Min(PhotoAfter.Width, mouseX + trackBar1.Value/2);

                int startY = Math.Max(0, mouseY - trackBar1.Value/2);
                int endY = Math.Min(PhotoAfter.Height, mouseY + trackBar1.Value/2);
                int r2 = (trackBar1.Value / 2) * (trackBar1.Value / 2);
                Parallel.For(startX, endX, x =>
                {
                    for (int y = startY; y < endY; y++)
                    {
                        if ((y-mouseY)*(y - mouseY) + (x - mouseX)* (x - mouseX) < r2)
                        brushColor[x, y] = true;
                    }
                });
            }
            if (mouseX != null)
            {
                Bitmap bitmap = new Bitmap(PhotoAfter);
                Graphics g = Graphics.FromImage(bitmap);
                Pen blackPen = new Pen(Color.Black);
                g.DrawEllipse(blackPen, mouseX - trackBar1.Value / 2, mouseY - trackBar1.Value / 2, trackBar1.Value, trackBar1.Value);
                Pen whitePen = new Pen(Color.White);
                g.DrawEllipse(whitePen, mouseX - trackBar1.Value / 2, mouseY - trackBar1.Value / 2, trackBar1.Value + 1, trackBar1.Value + 1);
                pictureBox1.Image = bitmap;
            }
        }
        private void Form1_Load_1(object sender, EventArgs e)
        {
            Photo = new Bitmap("..\\..\\..\\photo.jpg", true);
            PhotoAfter = new Bitmap(Photo);
            pictureBox1.Image = PhotoAfter;
            brushColor = new bool[Photo.Width, Photo.Height];
            CreateHistograms(Photo);
            radioButtonIdentity.Checked = true;
            radioButtonIdentity_CheckedChanged(sender, e);
        }

        private void radioButtonBrush_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonBrush.Checked)
            {
                trackBar1.Enabled = true;
            }
            else
            {
                trackBar1.Enabled = false;
            }
        }
       
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if(radioButtonBrush.Checked)
                follow = true;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (radioButtonBrush.Checked)
            {
                if (radioButtonOwn.Checked)
                {
                    Filter = new float[,]
                       {
            { (float)numericUpDown11.Value, (float)numericUpDown12.Value, (float)numericUpDown13.Value},
            { (float)numericUpDown21.Value, (float)numericUpDown22.Value, (float)numericUpDown23.Value},
            { (float)numericUpDown31.Value, (float)numericUpDown32.Value, (float)numericUpDown33.Value}
                       };
                }
                float divisor;
                if (checkBoxAutoDivisor.Checked)
                    divisor = 0;
                else
                    divisor = (float)numericUpDowndivisor.Value;
                float offSet = (float)numericUpDownOffSet.Value;
                follow = false;
                
                PhotoAfter = ConvolutionFilter.ProcessUsingLockbitsBoolMap(PhotoAfter, Filter, offSet, divisor,brushColor);
                brushColor = new bool[Photo.Width, Photo.Height];
                pictureBox1.Image = PhotoAfter;
            CreateHistograms(PhotoAfter);
        }

        }
    }
}

