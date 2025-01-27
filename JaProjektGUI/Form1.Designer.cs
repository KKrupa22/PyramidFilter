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
            saveFile = new Button();
            pictureBox2 = new PictureBox();
            openFileDialog = new OpenFileDialog();
            saveFileDialog = new SaveFileDialog();
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
            groupBox1.Location = new Point(17, 563);
            groupBox1.Margin = new Padding(4, 5, 4, 5);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 5, 4, 5);
            groupBox1.Size = new Size(1109, 167);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";
            // 
            // Czas
            // 
            Czas.Location = new Point(880, 65);
            Czas.Margin = new Padding(4, 0, 4, 0);
            Czas.Name = "Czas";
            Czas.Size = new Size(141, 47);
            Czas.TabIndex = 8;
            Czas.Text = "-----";
            Czas.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // CzasText
            // 
            CzasText.Location = new Point(746, 65);
            CzasText.Margin = new Padding(4, 0, 4, 0);
            CzasText.Name = "CzasText";
            CzasText.Size = new Size(139, 47);
            CzasText.TabIndex = 7;
            CzasText.Text = "Czas wykonania:";
            CzasText.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(199, 100);
            numericUpDown1.Margin = new Padding(4, 5, 4, 5);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(143, 31);
            numericUpDown1.TabIndex = 6;
            // 
            // Watki
            // 
            Watki.Location = new Point(9, 97);
            Watki.Margin = new Padding(4, 0, 4, 0);
            Watki.Name = "Watki";
            Watki.Size = new Size(181, 38);
            Watki.TabIndex = 5;
            Watki.Text = "Wybierz ilość wątków:";
            Watki.TextAlign = ContentAlignment.MiddleCenter;
            Watki.Click += label1_Click_1;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "C", "ASM" });
            comboBox1.Location = new Point(199, 40);
            comboBox1.Margin = new Padding(4, 5, 4, 5);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(141, 33);
            comboBox1.TabIndex = 4;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // Biblioteka
            // 
            Biblioteka.Location = new Point(26, 40);
            Biblioteka.Margin = new Padding(4, 0, 4, 0);
            Biblioteka.Name = "Biblioteka";
            Biblioteka.Size = new Size(164, 38);
            Biblioteka.TabIndex = 2;
            Biblioteka.Text = "Wybierz biblioteke:";
            Biblioteka.TextAlign = ContentAlignment.MiddleCenter;
            Biblioteka.Click += label1_Click;
            // 
            // Start
            // 
            Start.Location = new Point(447, 22);
            Start.Margin = new Padding(4, 5, 4, 5);
            Start.Name = "Start";
            Start.Size = new Size(210, 135);
            Start.TabIndex = 1;
            Start.Text = "Start";
            Start.UseVisualStyleBackColor = true;
            Start.Click += Start_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Location = new Point(17, 20);
            splitContainer1.Margin = new Padding(4, 5, 4, 5);
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
            splitContainer1.Panel2.Controls.Add(saveFile);
            splitContainer1.Panel2.Controls.Add(pictureBox2);
            splitContainer1.Size = new Size(1109, 533);
            splitContainer1.SplitterDistance = 548;
            splitContainer1.SplitterWidth = 6;
            splitContainer1.TabIndex = 1;
            // 
            // sourcePath
            // 
            sourcePath.Location = new Point(157, 488);
            sourcePath.Margin = new Padding(4, 5, 4, 5);
            sourcePath.Name = "sourcePath";
            sourcePath.Size = new Size(385, 31);
            sourcePath.TabIndex = 2;
            sourcePath.TextChanged += sourcePath_TextChanged;
            // 
            // openFile
            // 
            openFile.Location = new Point(9, 485);
            openFile.Margin = new Padding(4, 5, 4, 5);
            openFile.Name = "openFile";
            openFile.Size = new Size(140, 43);
            openFile.TabIndex = 1;
            openFile.Text = "Otwórz plik";
            openFile.UseVisualStyleBackColor = true;
            openFile.Click += openFile_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.ActiveBorder;
            pictureBox1.Location = new Point(4, 5);
            pictureBox1.Margin = new Padding(4, 5, 4, 5);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(540, 473);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            pictureBox1.DragDrop += pictureBox1_DragDrop;
            pictureBox1.DragEnter += pictureBox1_DragEnter;
            // 
            // saveFile
            // 
            saveFile.Location = new Point(180, 485);
            saveFile.Name = "saveFile";
            saveFile.Size = new Size(211, 43);
            saveFile.TabIndex = 1;
            saveFile.Text = "Zapisz plik";
            saveFile.UseVisualStyleBackColor = true;
            saveFile.Click += saveFile_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = SystemColors.ActiveBorder;
            pictureBox2.Location = new Point(4, 5);
            pictureBox2.Margin = new Padding(4, 5, 4, 5);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(550, 473);
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
            // saveFileDialog
            // 
            saveFileDialog.FileOk += saveFileDialog_FileOk;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1140, 745);
            Controls.Add(splitContainer1);
            Controls.Add(groupBox1);
            Margin = new Padding(4, 5, 4, 5);
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
        private Button saveFile;
        private SaveFileDialog saveFileDialog;
    }
}
