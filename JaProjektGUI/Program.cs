using System.Runtime.InteropServices;

namespace JaProjektGUI
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {

            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());

        }

        [DllImport("JaC.dll")]
        public static extern void PyramidC(IntPtr ptr, IntPtr tempPtr, int width, int height, int startY, int endY);

        [DllImport("JaASM.dll")]
        public static extern void PyramidASM(IntPtr ptr, IntPtr tempPtr, int width, int height, int startY, int endY);
    }

}