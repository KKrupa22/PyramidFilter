using System.Runtime.InteropServices;

namespace JaProjektGUI
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {

            String workingDirectory = Directory.GetCurrentDirectory();
            workingDirectory = Directory.GetParent(workingDirectory).FullName;
            workingDirectory = Directory.GetParent(workingDirectory).FullName;
            workingDirectory = Directory.GetParent(workingDirectory).FullName;
            workingDirectory = Directory.GetParent(workingDirectory).FullName;
            workingDirectory += "\\JaProjekt\\x64\\Release";
            SetDllDirectory(workingDirectory);
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());

        }

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool SetDllDirectory(string lpPathName);

        [DllImport(@"JaC.dll")]
        public static extern void PyramidC(IntPtr ptr, IntPtr tempPtr, int width, int height, int startY, int endY);

        [DllImport(@"JaASM.dll")]
        public static extern void PyramidASM(IntPtr ptr, IntPtr tempPtr, int width, int height, int startY, int endY);
    }

}