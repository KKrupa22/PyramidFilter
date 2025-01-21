namespace JaProjektGUI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            Czas = new Label();
            CzasText = new Label();
            numericUpDown1 = new NumericUpDown();
            Watki = new Label();
            comboBox1 = new ComboBox();
            Biblioteka = new Label();
            Start = new Button();
            splitContainer1 = new SplitContainer();
            sourcePath = new TextBox();
            openFile = new Button();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            openFileDialog = new OpenFileDialog();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(Czas);
            groupBox1.Controls.Add(CzasText);
            groupBox1.Controls.Add(numericUpDown1);
            groupBox1.Controls.Add(Watki);
            groupBox1.Controls.Add(comboBox1);
            groupBox1.Controls.Add(Biblioteka);
            groupBox1.Controls.Add(Start);
            groupBox1.Location = new Point(12, 338);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(776, 100);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";
            // 
            // Czas
            // 
            Czas.Location = new Point(616, 39);
            Czas.Name = "Czas";
            Czas.Size = new Size(99, 28);
            Czas.TabIndex = 8;
            Czas.Text = "-----";
            Czas.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // CzasText
            // 
            CzasText.Location = new Point(522, 39);
            CzasText.Name = "CzasText";
            CzasText.Size = new Size(97, 28);
            CzasText.TabIndex = 7;
            CzasText.Text = "Czas wykonania:";
            CzasText.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(139, 60);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(100, 23);
            numericUpDown1.TabIndex = 6;
            // 
            // Watki
            // 
            Watki.Location = new Point(6, 58);
            Watki.Name = "Watki";
            Watki.Size = new Size(127, 23);
            Watki.TabIndex = 5;
            Watki.Text = "Wybierz ilość wątków:";
            Watki.TextAlign = ContentAlignment.MiddleCenter;
            Watki.Click += label1_Click_1;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "C", "ASM" });
            comboBox1.Location = new Point(139, 24);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(100, 23);
            comboBox1.TabIndex = 4;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // Biblioteka
            // 
            Biblioteka.Location = new Point(18, 24);
            Biblioteka.Name = "Biblioteka";
            Biblioteka.Size = new Size(115, 23);
            Biblioteka.TabIndex = 2;
            Biblioteka.Text = "Wybierz biblioteke:";
            Biblioteka.TextAlign = ContentAlignment.MiddleCenter;
            Biblioteka.Click += label1_Click;
            // 
            // Start
            // 
            Start.Location = new Point(313, 13);
            Start.Name = "Start";
            Start.Size = new Size(147, 81);
            Start.TabIndex = 1;
            Start.Text = "Start";
            Start.UseVisualStyleBackColor = true;
            Start.Click += Start_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Location = new Point(12, 12);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(sourcePath);
            splitContainer1.Panel1.Controls.Add(openFile);
            splitContainer1.Panel1.Controls.Add(pictureBox1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(pictureBox2);
            splitContainer1.Size = new Size(776, 320);
            splitContainer1.SplitterDistance = 384;
            splitContainer1.TabIndex = 1;
            // 
            // sourcePath
            // 
            sourcePath.Location = new Point(110, 293);
            sourcePath.Name = "sourcePath";
            sourcePath.Size = new Size(271, 23);
            sourcePath.TabIndex = 2;
            sourcePath.TextChanged += sourcePath_TextChanged;
            // 
            // openFile
            // 
            openFile.Location = new Point(6, 291);
            openFile.Name = "openFile";
            openFile.Size = new Size(98, 26);
            openFile.TabIndex = 1;
            openFile.Text = "Otwórz plik";
            openFile.UseVisualStyleBackColor = true;
            openFile.Click += openFile_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.ActiveBorder;
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(378, 284);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            pictureBox1.DragDrop += pictureBox1_DragDrop;
            pictureBox1.DragEnter += pictureBox1_DragEnter;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = SystemColors.ActiveBorder;
            pictureBox2.Location = new Point(3, 3);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(385, 284);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // openFileDialog
            // 
            openFileDialog.FileName = "openFileDialog";
            openFileDialog.FileOk += openFileDialog_FileOk;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(798, 447);
            Controls.Add(splitContainer1);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label Biblioteka;
        private Button Start;
        private SplitContainer splitContainer1;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private ComboBox comboBox1;
        private Label Watki;
        private Label Czas;
        private Label CzasText;
        private NumericUpDown numericUpDown1;
        private Button openFile;
        private TextBox sourcePath;
        private OpenFileDialog openFileDialog;

        private Bitmap sourceBmp;
        private Bitmap destBmp;
        private int threadsNumb = 1;
    }
}
