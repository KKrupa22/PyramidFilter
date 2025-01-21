using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Threading;

namespace JaProjekt
{
    class Program
    {

        [DllImport(@"D:\Studia\JA\Projekt\JaProjekt\x64\Debug\JaASM.dll")]
        static extern int PyramidASM(IntPtr ptr, IntPtr tempPtr, int width, int height, int startY, int endY);
        [DllImport(@"D:\Studia\JA\Projekt\JaProjekt\x64\Debug\JaC.dll")]
        static extern void PyramidC(IntPtr ptr, IntPtr tempPtr, int width, int height, int startY, int endY);
        static void Main(string[] args)
        {

            Bitmap img = new Bitmap("D:\\Studia\\JA\\Projekt\\JaProjekt\\big.png");
            int width = img.Width;
            int height = img.Height;
            Bitmap temp = new Bitmap(width, height);
            int threadsNumb = 1;
            int chunkHeight = height / threadsNumb;
            BitmapData imgData = img.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            IntPtr ptr = imgData.Scan0;
            BitmapData tempData = temp.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            IntPtr tempPtr = tempData.Scan0;

            Thread[] threads = new Thread[threadsNumb];
            Stopwatch time = new Stopwatch();
            time.Start();

            for(int i = 0; i < threadsNumb; i++)
            {
                int startY = i * chunkHeight;
                int endY = 0;
                if(startY == 0 || startY == 1)
                {
                    startY = 2;
                }
                if(i == threadsNumb - 1)
                {
                    endY = height;
                }
                else
                {
                    endY = (i + 1) * chunkHeight;
                }
                Console.WriteLine($"Thread {i}: startX = {startY}, endX = {endY}");
                threads[i] = new Thread(() => PyramidASM(ptr, tempPtr, width, height, startY, endY));
                threads[i].Start();
            }

            foreach(Thread thread in threads)
            {
                thread.Join();
            }

            time.Stop();
            img.UnlockBits(imgData);
            temp.UnlockBits(tempData);
            temp.Save("D:\\Studia\\JA\\Projekt\\JaProjekt\\pyramidBig1.png");
            Console.WriteLine("Pyramid filter applied, time: " + time.ElapsedMilliseconds + " ms.");

        }
    }
}
