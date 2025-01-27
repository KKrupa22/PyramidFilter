using System.Diagnostics;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace JaProjektGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void openFile_Click(object sender, EventArgs e)
        {
            String workingDirectoryTemp = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            openFileDialog.InitialDirectory = workingDirectoryTemp;
            openFileDialog.ShowDialog(this);
        }

        private void sourcePath_TextChanged(object sender, EventArgs e)
        {

        }

        private void openFileDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sourceBmp = new Bitmap(openFileDialog.FileName);
            sourcePath.Text = openFileDialog.FileName;
            pictureBox1.Image = sourceBmp;
            if (sourceBmp != null)
            {
                Start.Enabled = true;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_DragDrop(object sender, DragEventArgs e)
        {
            var data = e.Data.GetData(DataFormats.FileDrop);
            if (data != null)
            {
                var fileNames = data as string[];
                if (fileNames.Length > 0)
                {
                    sourceBmp = new Bitmap(fileNames[0]);
                    sourcePath.Text = fileNames[0];
                    pictureBox1.Image = sourceBmp;
                }
                if (sourceBmp != null)
                {
                    Start.Enabled = true;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.AllowDrop = true;
        }

        private void pictureBox1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void label1_Click_3(object sender, EventArgs e)
        {

        }

        private void Start_Click(object sender, EventArgs e)
        {
            int width = sourceBmp.Width;
            int height = sourceBmp.Height;
            destBmp = new Bitmap(width, height);
            threadsNumb = (int)numericUpDown1.Value;
            int chunkHeight = height / threadsNumb;
            BitmapData imgData = sourceBmp.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            IntPtr ptr = imgData.Scan0;
            BitmapData tempData = destBmp.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            IntPtr tempPtr = tempData.Scan0;

            Thread[] threads = new Thread[threadsNumb];
            Stopwatch time = new Stopwatch();
            time.Start();

            if (comboBox1.SelectedIndex == 0)
            {
                for (int i = 0; i < threadsNumb; i++)
                {
                    int startY = i * chunkHeight;
                    int endY = 0;
                    if (startY == 0 || startY == 1)
                    {
                        startY = 2;
                    }
                    if (i == threadsNumb - 1)
                    {
                        endY = height;
                    }
                    else
                    {
                        endY = (i + 1) * chunkHeight;
                    }
                    threads[i] = new Thread(() => Program.PyramidC(ptr, tempPtr, width, height, startY, endY));
                    threads[i].Start();
                }

                foreach (Thread thread in threads)
                {
                    thread.Join();
                }

                time.Stop();
            }

            else if (comboBox1.SelectedIndex == 1)
            {
                for (int i = 0; i < threadsNumb; i++)
                {
                    int startY = i * chunkHeight;
                    int endY = 0;
                    if (startY == 0 || startY == 1)
                    {
                        startY = 2;
                    }
                    if (i == threadsNumb - 1)
                    {
                        endY = height;
                    }
                    else
                    {
                        endY = (i + 1) * chunkHeight;
                    }
                    threads[i] = new Thread(() => Program.PyramidASM(ptr, tempPtr, width, height, startY, endY));
                    threads[i].Start();
                }

                foreach (Thread thread in threads)
                {
                    thread.Join();
                }

                time.Stop();
            }
            sourceBmp.UnlockBits(imgData);
            destBmp.UnlockBits(tempData);
            pictureBox2.Image = destBmp;
            Czas.Text = time.ElapsedMilliseconds + " ms";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void saveFile_Click(object sender, EventArgs e)
        {
            if (destBmp != null)
            {
                String workingDirectoryTemp = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                saveFileDialog.InitialDirectory = workingDirectoryTemp;
                saveFileDialog.FileName = Path.GetFileNameWithoutExtension(sourcePath.Text) + "Pyramid.png";
                saveFileDialog.ShowDialog(this);
            }
        }

        private void saveFileDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            destBmp.Save(saveFileDialog.FileName, ImageFormat.Png);
        }
    }
}
