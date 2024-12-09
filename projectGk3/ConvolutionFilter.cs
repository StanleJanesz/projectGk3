using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.AxHost;

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
        public static Bitmap ApplyFilter(Bitmap processedBitmap, float[,] kernel, float OffSet, float divider)
        {
            BitmapData bitmapData = processedBitmap.LockBits(new Rectangle(0, 0, processedBitmap.Width, processedBitmap.Height), ImageLockMode.ReadWrite, processedBitmap.PixelFormat);

            int bytesPerPixel = Bitmap.GetPixelFormatSize(processedBitmap.PixelFormat) / 8;
            int byteCount = bitmapData.Stride * processedBitmap.Height;
            byte[] pixels = new byte[byteCount];
            IntPtr ptrFirstPixel = bitmapData.Scan0;
            Marshal.Copy(ptrFirstPixel, pixels, 0, pixels.Length);
            int heightInPixels = bitmapData.Height;
            int widthInBytes = bitmapData.Width * bytesPerPixel;
            byte[] pixels2 = (byte[])pixels.Clone();



            int kernelWidth = kernel.GetLength(0);
            int kernelHeight = kernel.GetLength(1);
            int kernelOffsetX = kernelWidth / 2;
            int kernelOffsetY = kernelHeight / 2;

            Parallel.For(kernelOffsetY, heightInPixels - kernelOffsetY, y =>
            {
                int currentLine = y * bitmapData.Stride;
                for (int x = kernelOffsetX * bytesPerPixel; x < widthInBytes - kernelOffsetX * bytesPerPixel; x = x + bytesPerPixel)
                {
                    float r = 0, g = 0, b = 0;

                    for (int i = 0; i < kernelWidth; i++)
                    {
                        for (int j = 0; j < kernelHeight; j++)
                        {
                            int px = x + (i - kernelOffsetX) * bytesPerPixel;
                            int py = y + j - kernelOffsetY;
                            int pline = py * bitmapData.Stride;
                            int oldBlue = pixels[pline + px];
                            int oldGreen = pixels[pline + px + 1];
                            int oldRed = pixels[pline + px + 2];

                            float kernelValue = kernel[i, j];

                            r += oldRed * kernelValue;
                            g += oldGreen * kernelValue;
                            b += oldBlue * kernelValue;
                        }
                    }
                    if (divider > 0)
                    {
                        r /= divider;
                        g /= divider;
                        b /= divider;
                    }
                    else if (divider == 0)
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
                        if (sum == 0) sum = 1;
                        r /= sum;
                        g /= sum;
                        b /= sum;
                    }
                    r += OffSet;
                    g += OffSet;
                    b += OffSet;
                    r = Math.Min(255, Math.Max(0, r)); 
                    g = Math.Min(255, Math.Max(0, g));
                    b = Math.Min(255, Math.Max(0, b));

                    pixels2[currentLine + x] = (byte)b;
                    pixels2[currentLine + x + 1] = (byte)g;
                    pixels2[currentLine + x + 2] = (byte)r;
                }
            });

            Marshal.Copy(pixels2, 0, ptrFirstPixel, pixels2.Length);
            processedBitmap.UnlockBits(bitmapData);
            return processedBitmap;
        }


        public static Bitmap ApplyFliterArea(Bitmap processedBitmap, float[,] kernel, float OffSet, float divider,bool[,] brushChange)
        {
            BitmapData bitmapData = processedBitmap.LockBits(new Rectangle(0, 0, processedBitmap.Width, processedBitmap.Height), ImageLockMode.ReadWrite, processedBitmap.PixelFormat);

            int bytesPerPixel = Bitmap.GetPixelFormatSize(processedBitmap.PixelFormat) / 8;
            int byteCount = bitmapData.Stride * processedBitmap.Height;
            byte[] pixels = new byte[byteCount];
            IntPtr ptrFirstPixel = bitmapData.Scan0;
            Marshal.Copy(ptrFirstPixel, pixels, 0, pixels.Length);
            int heightInPixels = bitmapData.Height;
            int widthInBytes = bitmapData.Width * bytesPerPixel;
            byte[] pixels2 = (byte[])pixels.Clone();


            int kernelWidth = kernel.GetLength(0);
            int kernelHeight = kernel.GetLength(1);
            int kernelOffsetX = kernelWidth / 2;
            int kernelOffsetY = kernelHeight / 2;

            Parallel.For(kernelOffsetY, heightInPixels - kernelOffsetY, y =>
            {
                int currentLine = y * bitmapData.Stride;
                for (int x = kernelOffsetX * bytesPerPixel; x < widthInBytes - kernelOffsetX * bytesPerPixel; x = x + bytesPerPixel)
                {

                    if (brushChange[x / bytesPerPixel, y])
                    {
                        float r = 0, g = 0, b = 0;
                        for (int i = 0; i < kernelWidth; i++)
                        {
                            for (int j = 0; j < kernelHeight; j++)
                            {
                                int px = x + (i - kernelOffsetX) * bytesPerPixel;
                                int py = y + j - kernelOffsetY;
                                int pline = py * bitmapData.Stride;
                                int oldBlue = pixels[pline + px];
                                int oldGreen = pixels[pline + px + 1];
                                int oldRed = pixels[pline + px + 2];

                                float kernelValue = kernel[i, j];

                                r += oldRed * kernelValue;
                                g += oldGreen * kernelValue;
                                b += oldBlue * kernelValue;
                            }
                        }
                        if (divider > 0)
                        {
                            r /= divider;
                            g /= divider;
                            b /= divider;
                        }
                        else if (divider == 0)
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
                            if (sum == 0) sum = 1;
                            r /= sum;
                            g /= sum;
                            b /= sum;
                        }
                        r += OffSet;
                        g += OffSet;
                        b += OffSet;
                        r = Math.Min(255, Math.Max(0, r)); 
                        g = Math.Min(255, Math.Max(0, g));
                        b = Math.Min(255, Math.Max(0, b));

                        pixels2[currentLine + x] = (byte)b;
                        pixels2[currentLine + x + 1] = (byte)g;
                        pixels2[currentLine + x + 2] = (byte)r;
                    }
                }
            });

            Marshal.Copy(pixels2, 0, ptrFirstPixel, pixels2.Length);
            processedBitmap.UnlockBits(bitmapData);
            return processedBitmap;
        }
        
    
}
}
