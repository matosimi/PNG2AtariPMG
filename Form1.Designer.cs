namespace Png2gr5
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
            buttonLoad = new Button();
            pictureBox1 = new PictureBox();
            openFileDialog1 = new OpenFileDialog();
            listViewColors = new ListView();
            columnHeaderColorText = new ColumnHeader();
            columnHeaderColor = new ColumnHeader();
            columnHeaderBits = new ColumnHeader();
            columnHeaderLum = new ColumnHeader();
            listBoxPixelBits = new ListBox();
            buttonSave = new Button();
            saveFileDialog1 = new SaveFileDialog();
            labelFormat = new Label();
            buttonSortColors = new Button();
            numericUpDownSliceWidth = new NumericUpDown();
            trackBarFrames = new TrackBar();
            pictureBox2 = new PictureBox();
            checkBoxLeftAlign = new CheckBox();
            richTextBox1 = new RichTextBox();
            buttonGenerateText = new Button();
            checkBoxOptim = new CheckBox();
            splitContainer1 = new SplitContainer();
            label2 = new Label();
            numericUpDownRightCut = new NumericUpDown();
            numericUpDownLeftCut = new NumericUpDown();
            label1 = new Label();
            checkBoxAutoCut = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownSliceWidth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarFrames).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownRightCut).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownLeftCut).BeginInit();
            SuspendLayout();
            // 
            // buttonLoad
            // 
            buttonLoad.Location = new Point(3, 9);
            buttonLoad.Name = "buttonLoad";
            buttonLoad.Size = new Size(75, 23);
            buttonLoad.TabIndex = 0;
            buttonLoad.Text = "Load PNG";
            buttonLoad.UseVisualStyleBackColor = true;
            buttonLoad.Click += ButtonLoad_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(3, 38);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(320, 192);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // listViewColors
            // 
            listViewColors.Columns.AddRange(new ColumnHeader[] { columnHeaderColorText, columnHeaderColor, columnHeaderBits, columnHeaderLum });
            listViewColors.Location = new Point(329, 38);
            listViewColors.Name = "listViewColors";
            listViewColors.Size = new Size(392, 392);
            listViewColors.TabIndex = 2;
            listViewColors.UseCompatibleStateImageBehavior = false;
            listViewColors.View = View.Details;
            // 
            // columnHeaderColorText
            // 
            columnHeaderColorText.Text = "Color Text";
            columnHeaderColorText.Width = 140;
            // 
            // columnHeaderColor
            // 
            columnHeaderColor.Text = "Color";
            columnHeaderColor.Width = 50;
            // 
            // columnHeaderBits
            // 
            columnHeaderBits.Text = "Bits";
            // 
            // columnHeaderLum
            // 
            columnHeaderLum.Text = "Lum";
            // 
            // listBoxPixelBits
            // 
            listBoxPixelBits.FormattingEnabled = true;
            listBoxPixelBits.ItemHeight = 15;
            listBoxPixelBits.Items.AddRange(new object[] { "00", "01", "10", "11" });
            listBoxPixelBits.Location = new Point(727, 38);
            listBoxPixelBits.Name = "listBoxPixelBits";
            listBoxPixelBits.Size = new Size(33, 79);
            listBoxPixelBits.TabIndex = 3;
            listBoxPixelBits.MouseDoubleClick += ListBoxPixelBits_MouseDoubleClick;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(3, 236);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(117, 23);
            buttonSave.TabIndex = 4;
            buttonSave.Text = "Save PMGdata as";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += ButtonSave_Click;
            // 
            // labelFormat
            // 
            labelFormat.AutoSize = true;
            labelFormat.Location = new Point(84, 13);
            labelFormat.Name = "labelFormat";
            labelFormat.Size = new Size(48, 15);
            labelFormat.TabIndex = 8;
            labelFormat.Text = "Format:";
            // 
            // buttonSortColors
            // 
            buttonSortColors.Location = new Point(329, 9);
            buttonSortColors.Name = "buttonSortColors";
            buttonSortColors.Size = new Size(75, 23);
            buttonSortColors.TabIndex = 9;
            buttonSortColors.Text = "Sort colors";
            buttonSortColors.UseVisualStyleBackColor = true;
            buttonSortColors.Click += ButtonSortColors_Click;
            // 
            // numericUpDownSliceWidth
            // 
            numericUpDownSliceWidth.Location = new Point(727, 140);
            numericUpDownSliceWidth.Maximum = new decimal(new int[] { 24, 0, 0, 0 });
            numericUpDownSliceWidth.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownSliceWidth.Name = "numericUpDownSliceWidth";
            numericUpDownSliceWidth.Size = new Size(110, 23);
            numericUpDownSliceWidth.TabIndex = 10;
            numericUpDownSliceWidth.UpDownAlign = LeftRightAlignment.Left;
            numericUpDownSliceWidth.Value = new decimal(new int[] { 8, 0, 0, 0 });
            numericUpDownSliceWidth.ValueChanged += NumericUpDownSliceWidth_ValueChanged;
            // 
            // trackBarFrames
            // 
            trackBarFrames.Enabled = false;
            trackBarFrames.Location = new Point(723, 236);
            trackBarFrames.Name = "trackBarFrames";
            trackBarFrames.Size = new Size(104, 45);
            trackBarFrames.TabIndex = 11;
            trackBarFrames.Scroll += TrackBarFrames_Scroll;
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new Point(727, 267);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(100, 109);
            pictureBox2.TabIndex = 12;
            pictureBox2.TabStop = false;
            // 
            // checkBoxLeftAlign
            // 
            checkBoxLeftAlign.AutoSize = true;
            checkBoxLeftAlign.Checked = true;
            checkBoxLeftAlign.CheckState = CheckState.Checked;
            checkBoxLeftAlign.Location = new Point(161, 239);
            checkBoxLeftAlign.Margin = new Padding(2);
            checkBoxLeftAlign.Name = "checkBoxLeftAlign";
            checkBoxLeftAlign.Size = new Size(77, 19);
            checkBoxLeftAlign.TabIndex = 13;
            checkBoxLeftAlign.Text = "Left Align";
            checkBoxLeftAlign.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            richTextBox1.Dock = DockStyle.Fill;
            richTextBox1.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point);
            richTextBox1.Location = new Point(0, 0);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(882, 155);
            richTextBox1.TabIndex = 14;
            richTextBox1.Text = "";
            // 
            // buttonGenerateText
            // 
            buttonGenerateText.Location = new Point(3, 414);
            buttonGenerateText.Name = "buttonGenerateText";
            buttonGenerateText.Size = new Size(162, 23);
            buttonGenerateText.TabIndex = 15;
            buttonGenerateText.Text = "Generate text output";
            buttonGenerateText.UseVisualStyleBackColor = true;
            buttonGenerateText.Click += ButtonGenerateText_Click;
            // 
            // checkBoxOptim
            // 
            checkBoxOptim.AutoSize = true;
            checkBoxOptim.Checked = true;
            checkBoxOptim.CheckState = CheckState.Checked;
            checkBoxOptim.Location = new Point(3, 389);
            checkBoxOptim.Name = "checkBoxOptim";
            checkBoxOptim.Size = new Size(188, 19);
            checkBoxOptim.TabIndex = 16;
            checkBoxOptim.Text = "Optimize leading/trailing zeros";
            checkBoxOptim.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(checkBoxAutoCut);
            splitContainer1.Panel1.Controls.Add(label2);
            splitContainer1.Panel1.Controls.Add(numericUpDownRightCut);
            splitContainer1.Panel1.Controls.Add(numericUpDownLeftCut);
            splitContainer1.Panel1.Controls.Add(label1);
            splitContainer1.Panel1.Controls.Add(pictureBox1);
            splitContainer1.Panel1.Controls.Add(pictureBox2);
            splitContainer1.Panel1.Controls.Add(trackBarFrames);
            splitContainer1.Panel1.Controls.Add(checkBoxOptim);
            splitContainer1.Panel1.Controls.Add(numericUpDownSliceWidth);
            splitContainer1.Panel1.Controls.Add(buttonLoad);
            splitContainer1.Panel1.Controls.Add(buttonGenerateText);
            splitContainer1.Panel1.Controls.Add(labelFormat);
            splitContainer1.Panel1.Controls.Add(checkBoxLeftAlign);
            splitContainer1.Panel1.Controls.Add(listViewColors);
            splitContainer1.Panel1.Controls.Add(listBoxPixelBits);
            splitContainer1.Panel1.Controls.Add(buttonSortColors);
            splitContainer1.Panel1.Controls.Add(buttonSave);
            splitContainer1.Panel1MinSize = 450;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(richTextBox1);
            splitContainer1.Size = new Size(882, 609);
            splitContainer1.SplitterDistance = 450;
            splitContainer1.TabIndex = 17;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(723, 192);
            label2.Name = "label2";
            label2.Size = new Size(111, 15);
            label2.TabIndex = 20;
            label2.Text = "Cut from Left/Right";
            // 
            // numericUpDownRightCut
            // 
            numericUpDownRightCut.Location = new Point(783, 210);
            numericUpDownRightCut.Maximum = new decimal(new int[] { 24, 0, 0, 0 });
            numericUpDownRightCut.Name = "numericUpDownRightCut";
            numericUpDownRightCut.Size = new Size(50, 23);
            numericUpDownRightCut.TabIndex = 19;
            numericUpDownRightCut.ValueChanged += NumericUpDownRightCut_ValueChanged;
            // 
            // numericUpDownLeftCut
            // 
            numericUpDownLeftCut.Location = new Point(727, 210);
            numericUpDownLeftCut.Maximum = new decimal(new int[] { 24, 0, 0, 0 });
            numericUpDownLeftCut.Name = "numericUpDownLeftCut";
            numericUpDownLeftCut.Size = new Size(50, 23);
            numericUpDownLeftCut.TabIndex = 18;
            numericUpDownLeftCut.UpDownAlign = LeftRightAlignment.Left;
            numericUpDownLeftCut.ValueChanged += NumericUpDownLeftCut_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(723, 122);
            label1.Name = "label1";
            label1.Size = new Size(91, 15);
            label1.TabIndex = 17;
            label1.Text = "Total slice width";
            // 
            // checkBoxAutoCut
            // 
            checkBoxAutoCut.AutoSize = true;
            checkBoxAutoCut.Checked = true;
            checkBoxAutoCut.CheckState = CheckState.Checked;
            checkBoxAutoCut.Location = new Point(727, 168);
            checkBoxAutoCut.Margin = new Padding(2);
            checkBoxAutoCut.Name = "checkBoxAutoCut";
            checkBoxAutoCut.Size = new Size(74, 19);
            checkBoxAutoCut.TabIndex = 21;
            checkBoxAutoCut.Text = "Auto Cut";
            checkBoxAutoCut.UseVisualStyleBackColor = true;
            checkBoxAutoCut.CheckedChanged += CheckBoxAutoCut_CheckedChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(882, 609);
            Controls.Add(splitContainer1);
            Name = "Form1";
            Text = "PNG to Atari PMG by MatoSimi 23.6.2023";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownSliceWidth).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarFrames).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numericUpDownRightCut).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownLeftCut).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button buttonLoad;
        private PictureBox pictureBox1;
        private OpenFileDialog openFileDialog1;
        private ListView listViewColors;
        private ColumnHeader columnHeaderColorText;
        private ColumnHeader columnHeaderColor;
        private ColumnHeader columnHeaderBits;
        private ListBox listBoxPixelBits;
        private Button buttonSave;
        private SaveFileDialog saveFileDialog1;
        private Label labelFormat;
        private Button buttonSortColors;
        private ColumnHeader columnHeaderLum;
        private NumericUpDown numericUpDownSliceWidth;
        private TrackBar trackBarFrames;
        private PictureBox pictureBox2;
        private CheckBox checkBoxLeftAlign;
        private RichTextBox richTextBox1;
        private Button buttonGenerateText;
        private CheckBox checkBoxOptim;
        private SplitContainer splitContainer1;
        private Label label2;
        private NumericUpDown numericUpDownRightCut;
        private NumericUpDown numericUpDownLeftCut;
        private Label label1;
        private CheckBox checkBoxAutoCut;
    }
}