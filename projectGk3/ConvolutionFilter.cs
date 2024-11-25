using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectGk3
{
    internal class ConvolutionFilter
    {
       public static float[,] BlurFilter = new float[,]
       {
            { 1f / 9, 1f / 9, 1f / 9 },
            { 1f / 9, 1f / 9, 1f / 9 },
            { 1f / 9, 1f / 9, 1f / 9 }
       };
        public static float[,] SharpenFilter = new float[,]
      {
            { -1f, -1f, -1f},
            { -1f, 9f, -1f },
            { -1f,  -1f, -1f }
      };
        public static float[,] FlatenFilter = new float[,]
    {
            { -1f, -1f, 0f},
            { -1f, 1f, 1f },
            { 0f,  1f, 1f }
    };
        public static float[,] LaplaceFilter = new float[,]
    {
            { 0f, -1f, 0f},
            { -1f, 4f, -1f },
            { 0f,  -1f, 0f }
    };
        public static float[,] IdentityFilter = new float[,]
  {
            { 0f, 0f, 0f},
            { 0f, 1f, 0f },
            { 0f,  0f, 0f }
  };
        public static Bitmap ApplyConvolutionFilter(Bitmap image, float[,] kernel,float OffSet,float divider)
        {
            int width = image.Width;
            int height = image.Height;
            Bitmap outputImage = new Bitmap(width, height);

            int kernelWidth = kernel.GetLength(0);
            int kernelHeight = kernel.GetLength(1);
            int kernelOffsetX = kernelWidth / 2;
            int kernelOffsetY = kernelHeight / 2;

            for (int x = kernelOffsetX; x < width - kernelOffsetX; x++)
            {
                for (int y = kernelOffsetY; y < height - kernelOffsetY; y++)
                {
                    float r = 0, g = 0, b = 0;

                    for (int i = 0; i < kernelWidth; i++)
                    {
                        for (int j = 0; j < kernelHeight; j++)
                        {
                            int px = x + i - kernelOffsetX;
                            int py = y + j - kernelOffsetY;

                            Color pixel = image.GetPixel(px, py);
                            float kernelValue = kernel[i, j];

                            r += pixel.R * kernelValue;
                            g += pixel.G * kernelValue;
                            b += pixel.B * kernelValue;
                        }
                    }
                    if ( divider > 0)
                    {
                        r /= divider;
                        g /= divider;
                        b /= divider;
                    }
                    else if (  divider == 0)
                    {
                        float sum = 0;
                        for (int i = 0; i < kernelWidth; i++)
                        {
                            for (int j = 0; j < kernelHeight; j++)
                            {
                                
                                float kernelValue = kernel[i, j];
                                sum += kernelValue;
                            }
                        }
                        r /= sum;
                        g /= sum;
                        b /= sum;
                    }
                    r += OffSet;
                    g += OffSet;
                    b += OffSet;
                    r = Math.Min(255, Math.Max(0, r)); // Clamp to valid pixel range
                    g = Math.Min(255, Math.Max(0, g));
                    b = Math.Min(255, Math.Max(0, b));

                    outputImage.SetPixel(x, y, Color.FromArgb((int)r, (int)g, (int)b));
                }
            }

            return outputImage;
        }
    }
}
