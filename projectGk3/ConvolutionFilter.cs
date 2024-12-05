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
        public static Bitmap ProcessUsingLockbits(Bitmap processedBitmap, float[,] kernel, float OffSet, float divider)
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
            //Bitmap outputImage = new Bitmap(processedBitmap);
            //BitmapData bitmapData2 = outputImage.LockBits(new Rectangle(0, 0, outputImage.Width, outputImage.Height), ImageLockMode.ReadWrite, outputImage.PixelFormat);
            //int byteCount2 = bitmapData2.Stride * outputImage.Height;
            //byte[] pixels2 = new byte[byteCount2];
            //IntPtr ptrFirstPixel2 = bitmapData2.Scan0;
            //Marshal.Copy(ptrFirstPixel2, pixels2, 0, pixels2.Length);


            int kernelWidth = kernel.GetLength(0);
            int kernelHeight = kernel.GetLength(1);
            int kernelOffsetX = kernelWidth / 2;
            int kernelOffsetY = kernelHeight / 2;

            // for (int y = kernelOffsetY; y < heightInPixels - kernelOffsetY; y++)
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

                            //  Color pixel = image.GetPixel(px, py);
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
                    r = Math.Min(255, Math.Max(0, r)); // Clamp to valid pixel range
                    g = Math.Min(255, Math.Max(0, g));
                    b = Math.Min(255, Math.Max(0, b));

                    // calculate new pixel value
                    pixels2[currentLine + x] = (byte)b;
                    pixels2[currentLine + x + 1] = (byte)g;
                    pixels2[currentLine + x + 2] = (byte)r;
                }
            });

            // copy modified bytes back
            Marshal.Copy(pixels2, 0, ptrFirstPixel, pixels2.Length);
            processedBitmap.UnlockBits(bitmapData);
            return processedBitmap;
        }


        public static Bitmap ProcessUsingLockbitsBoolMap(Bitmap processedBitmap, float[,] kernel, float OffSet, float divider,bool[,] brushChange)
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
            //Bitmap outputImage = new Bitmap(processedBitmap);
            //BitmapData bitmapData2 = outputImage.LockBits(new Rectangle(0, 0, outputImage.Width, outputImage.Height), ImageLockMode.ReadWrite, outputImage.PixelFormat);
            //int byteCount2 = bitmapData2.Stride * outputImage.Height;
            //byte[] pixels2 = new byte[byteCount2];
            //IntPtr ptrFirstPixel2 = bitmapData2.Scan0;
            //Marshal.Copy(ptrFirstPixel2, pixels2, 0, pixels2.Length);


            int kernelWidth = kernel.GetLength(0);
            int kernelHeight = kernel.GetLength(1);
            int kernelOffsetX = kernelWidth / 2;
            int kernelOffsetY = kernelHeight / 2;

            //for (int y = kernelOffsetY; y < heightInPixels - kernelOffsetY; y++)
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

                                //  Color pixel = image.GetPixel(px, py);
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
                        r = Math.Min(255, Math.Max(0, r)); // Clamp to valid pixel range
                        g = Math.Min(255, Math.Max(0, g));
                        b = Math.Min(255, Math.Max(0, b));

                        // calculate new pixel value
                        pixels2[currentLine + x] = (byte)b;
                        pixels2[currentLine + x + 1] = (byte)g;
                        pixels2[currentLine + x + 2] = (byte)r;
                    }
                }
            });

            // copy modified bytes back
            Marshal.Copy(pixels2, 0, ptrFirstPixel, pixels2.Length);
            processedBitmap.UnlockBits(bitmapData);
            return processedBitmap;
        }
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
                        if (sum == 0) sum = 1;
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
        public static Bitmap ApplyConvolutionFilterCircle(Bitmap image, float[,] kernel, float OffSet, float divider,int pointX, int pointY, int radious)
        {
            int width = image.Width;
            int height = image.Height;
            Bitmap outputImage = new Bitmap(image);

            int kernelWidth = kernel.GetLength(0);
            int kernelHeight = kernel.GetLength(1);
            int kernelOffsetX = kernelWidth / 2;
            int kernelOffsetY = kernelHeight / 2;
            int radious2 = radious * radious;
            for (int x = Math.Max(kernelOffsetX, pointX - radious); x <Math.Min( width - kernelOffsetX,pointX+radious); x++)
            {
                for (int y = Math.Max(kernelOffsetY,pointY - radious); y <Math.Min( height - kernelOffsetY,pointY+radious); y++)
                {
                    float r = 0, g = 0, b = 0;
                    if ((x-pointX )*(x- pointX) + (y - pointY)*(y-pointY) <= radious2 )
                    {


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
                        r = Math.Min(255, Math.Max(0, r)); // Clamp to valid pixel range
                        g = Math.Min(255, Math.Max(0, g));
                        b = Math.Min(255, Math.Max(0, b));

                        outputImage.SetPixel(x, y, Color.FromArgb((int)r, (int)g, (int)b));
                    }
                    //else
                    //{
                    //    outputImage.SetPixel(x, y, Color.FromArgb((int)r, (int)g, (int)b));
                    //}
                }
            }

            return outputImage;
        }
    
}
}
