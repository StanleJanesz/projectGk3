using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectGk3
{
    internal class Histogram
    {
        public static Bitmap[] GenerateHistogram(Bitmap bitmap)
        {
            Bitmap[] result= new Bitmap[3];
            result[0] = new Bitmap(256, 256) ;
            result[1] = new Bitmap(256, 256) ;
            result[2] = new Bitmap(256, 256) ;
            int[] tabR = new int[256];
            int[] tabG = new int[256];
            int[] tabB = new int[256];
            int  maxR = 0;

            for (int i = 0;i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    Color c = bitmap.GetPixel(i, j);
                    if (!(c.R == 0 && c.G == 0 && c.B == 0))
                    {
                        if (++tabR[c.R] > maxR) maxR = tabR[c.R];
                        if (++tabG[c.G] > maxR) maxR = tabG[c.G];
                        if (++tabB[c.B] > maxR) maxR = tabB[c.B];
                    }
                }
            }
            for (int i = 0; i < 5; i ++)
            {
                Pen pen = new Pen(Color.FromArgb(0, 0, 0));
                for ( int j =  0; j < 3; j ++)
                {
                    Graphics g = Graphics.FromImage(result[j]);
                    g.DrawLine(pen, 51 * i, 0, 51 * i, 255);
                    g.DrawLine(pen, 0, 51 * i, 255, 51 * i);
                }
               


            }
            for (int i = 0; i < 256; i++)
            {
                Pen pen = new Pen(Color.FromArgb(255, 0, 0));
                Graphics g = Graphics.FromImage(result[0]);
                g.DrawLine(pen, i, 255, i, 255 - (float)tabR[i]/(float)maxR * 255);

                pen = new Pen(Color.FromArgb(0, 255, 0));
                g = Graphics.FromImage(result[1]);
                g.DrawLine(pen, i, 255, i, 255 - (float)tabG[i] / (float)maxR * 255);

                pen = new Pen(Color.FromArgb(0, 0, 255));
                g = Graphics.FromImage(result[2]);
                g.DrawLine(pen, i, 255, i, 255 - (float)tabB[i] / (float)maxR * 255);
            }
                return result;
        }

    }
}
