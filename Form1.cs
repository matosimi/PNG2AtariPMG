using System.Xml;

namespace Png2gr5
{
    public partial class Form1 : Form
    {
        private byte[] pmdata;
        private byte frameWidth;
        private byte frameHeight;
        private byte frameCount;
        private int[] xMove;

        public Form1()
        {
            InitializeComponent();
        }

        private void ButtonLoad_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "*.png file|*.png";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(openFileDialog1.FileName);
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                this.frameHeight = (byte)pictureBox1.Image.Height;
                listViewColors.Items.Clear();
                colorList.Clear();
                AnalyzePicture();
                labelFormat.Text = "Format: " + pictureBox1.Image.Width.ToString() + " x " + pictureBox1.Image.Height.ToString() + " x " + colorList.Count.ToString() + " colors";
                numericUpDownSliceWidth.Value = 5;
                NumericUpDownSliceWidth_ValueChanged(this, e);
            }
        }

        private List<Color> colorList = new List<Color>();

        private void AnalyzePicture()
        {
            Bitmap bm = new Bitmap(pictureBox1.Image);
            for (int y = 0; y < bm.Height; y++)
                for (int x = 0; x < bm.Width; x++)
                {
                    Color color = bm.GetPixel(x, y);
                    if (!colorList.Contains(color))
                        colorList.Add(color);
                }

            foreach (Color color in colorList)
            {
                var lvi = listViewColors.Items.Add(color.ToString(), color.ToString(), -1);
                lvi.UseItemStyleForSubItems = false;
                lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, "", color, color, listViewColors.Font));
                lvi.SubItems.Add("00");
            }
        }

        private void ListBoxPixelBits_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listViewColors.SelectedItems.Count > 0)
            {
                var lvi = listViewColors.SelectedItems[0];
                lvi.SubItems[2].Text = listBoxPixelBits.Text;
                if (trackBarFrames.Enabled) pmdata = GeneratePmData();
            }

        }

        private byte[] GeneratePmData()
        {
            byte[] output = new byte[0];
            if (checkBoxAutoCut.Checked)
            {
                output = GeneratePmDataXMove();
                if (output.Length == 2)
                {
                    MessageBox.Show($"Auto Cut failed, frame {output[1]} has data that overlaps the 8-pixel boundary: {output[0]}.");
                    return new byte[0];
                }

            }
            else
            {
                output = GeneratePmDataSimple();
            }
            return output;
        }

        private byte[] GeneratePmDataXMove()
        {
            this.frameWidth = (byte)numericUpDownSliceWidth.Value;
            this.frameCount = (byte)(trackBarFrames.Maximum + 1);
            Bitmap bm = new Bitmap(pictureBox1.Image);
            byte[] dataArray = new byte[bm.Height * frameCount * 2];
            this.xMove = new int[frameCount];

            for (int frame = 0; frame < frameCount; frame++)
            {
                // find valid pixel range for export
                // find left edge
                int leftEdge = -1;
                for (int x = 0; x < frameWidth; x++)
                {
                    for (int y = 0; y < bm.Height; y++)
                    {
                        Color color = bm.GetPixel((frame * frameWidth + x), y);
                        var index = listViewColors.Items.IndexOfKey(color.ToString());
                        string colorBits;
                        if (listViewColors.Items[index].SubItems.Count < 3)
                            colorBits = "00";
                        else
                            colorBits = listViewColors.Items[index].SubItems[2].Text;
                        if (colorBits != "00")
                        {
                            leftEdge = x;
                            xMove[frame] = leftEdge;
                            break;
                        }
                    }
                    if (leftEdge > -1)
                        break;
                }

                // find right edge => export width
                int exportWidth = -1;
                for (int x = frameWidth - 1; x >= 0; x--)
                {
                    for (int y = 0; y < bm.Height; y++)
                    {
                        Color color = bm.GetPixel((frame * frameWidth + x), y);
                        var index = listViewColors.Items.IndexOfKey(color.ToString());
                        string colorBits;
                        if (listViewColors.Items[index].SubItems.Count < 3)
                            colorBits = "00";
                        else
                            colorBits = listViewColors.Items[index].SubItems[2].Text;
                        if (colorBits != "00")
                        {
                            exportWidth = x - leftEdge + 1;
                            break;
                        }
                    }
                    if (exportWidth > 0)
                        break;
                }

                if (exportWidth > 8)
                    return new byte[] { (byte)exportWidth, (byte)frame };    //uh oh ugly

                for (int y = 0; y < bm.Height; y++)
                {
                    byte data = 0;
                    byte data2 = 0;
                    for (int x = leftEdge; x < leftEdge + exportWidth; x++)
                    {
                        data = (byte)(data << 1);
                        data2 = (byte)(data2 << 1);
                        Color color = bm.GetPixel((frame * frameWidth + x), y);
                        var index = listViewColors.Items.IndexOfKey(color.ToString());
                        string colorBits;
                        if (index == -1)
                            colorBits = "00";
                        else
                        {
                            if (listViewColors.Items[index].SubItems.Count < 3)
                                colorBits = "00";
                            else
                                colorBits = listViewColors.Items[index].SubItems[2].Text;
                        }
                        byte pixelBits = Convert.ToByte(colorBits.Substring(1, 1), 2);
                        data += pixelBits;
                        pixelBits = Convert.ToByte(colorBits.Substring(0, 1), 2);
                        data2 += pixelBits;
                    }

                    dataArray[y + frame * bm.Height] = data;
                    dataArray[y + (frameCount + frame) * bm.Height] = data2;
                }
            }
            return dataArray;
        }
        private byte[] GeneratePmDataSimple()
        {
            this.frameWidth = (byte)numericUpDownSliceWidth.Value;
            this.frameCount = (byte)(trackBarFrames.Maximum + 1);
            Bitmap bm = new Bitmap(pictureBox1.Image);
            byte[] dataArray = new byte[bm.Height * frameCount * 2];

            for (int frame = 0; frame < frameCount; frame++)
                for (int y = 0; y < bm.Height; y++)
                {
                    byte data = 0;
                    byte data2 = 0;
                    for (int x = 0; x < frameWidth; x++)
                    {
                        data = (byte)(data << 1);
                        data2 = (byte)(data2 << 1);
                        Color color = bm.GetPixel((frame * frameWidth + x), y);
                        var index = listViewColors.Items.IndexOfKey(color.ToString());
                        string colorBits;
                        if (index == -1)
                            colorBits = "00";
                        else
                        {
                            if (listViewColors.Items[index].SubItems.Count < 3)
                                colorBits = "00";
                            else
                                colorBits = listViewColors.Items[index].SubItems[2].Text;
                        }
                        byte pixelBits = Convert.ToByte(colorBits.Substring(1, 1), 2);
                        data += pixelBits;
                        pixelBits = Convert.ToByte(colorBits.Substring(0, 1), 2);
                        data2 += pixelBits;
                    }
                    if (checkBoxLeftAlign.Checked)
                    {
                        data = (byte)(data << (8 - frameWidth));
                        data2 = (byte)(data2 << (8 - frameWidth));
                    }
                    dataArray[y + frame * bm.Height] = data;
                    dataArray[y + (frameCount + frame) * bm.Height] = data2;
                }
            return dataArray;
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "raw data all frames p0, all frames p1 (*.dat/pmg)|*.dat;*.pmg|" +
                                     "SprEd format (*.spr)|*.spr";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (saveFileDialog1.FilterIndex == 1)
                {
                    File.WriteAllBytes(saveFileDialog1.FileName, pmdata);
                }
                else
                {
                    //SPRed export
                    byte[] spredHeader = new byte[] { 0x53, 0x70, 0x72, 0x21, 0, 0, 0, 5, 0, 2, /*mergemode*/0, 0, 0, 0, 0x02, 0, 0, frameCount, frameHeight };
                    byte[] spredColors = new byte[frameCount * 2];
                    spredColors[0] = 0x04;
                    spredColors[frameCount] = 0x08;
                    File.WriteAllBytes(saveFileDialog1.FileName, spredHeader.Concat(spredColors).Concat(pmdata).ToArray());
                }
            }
        }



        private void ButtonSortColors_Click(object sender, EventArgs e)
        {
            int itms = listViewColors.Items.Count;
            if (listViewColors.Items[0].SubItems.Count == 4) return;
            byte[] lum = new byte[itms];
            for (int i = 0; i < itms; i++)
            {
                lum[i] = (byte)(listViewColors.Items[i].SubItems[1].BackColor.GetBrightness() * 255);
                listViewColors.Items[i].SubItems.Add(lum[i].ToString());
            }
            bool change = true;
            while (change)
            {
                change = false;
                int max = 0, idx = 0;
                for (int i = 0; i < itms; i++)
                {
                    int val = int.Parse(listViewColors.Items[i].SubItems[3].Text);
                    if (val < 0) continue;
                    if (val > max)
                    {
                        max = val;
                        idx = i;
                        change = true;
                    }
                }
                if (change)
                {
                    var lvi = listViewColors.Items[idx];
                    listViewColors.Items[idx].Remove();
                    lvi.SubItems[3].Text = $"-{lvi.SubItems[3].Text}";
                    listViewColors.Items.Add(lvi);
                }
            }
        }

        private void ValidateSlice()
        {
            bool valid = pictureBox1.Image.Width % numericUpDownSliceWidth.Value == 0;
            //valid &= (numericUpDownSliceWidth.Value - numericUpDownLeftCut.Value - numericUpDownRightCut.Value > 0);
            //valid &= (numericUpDownSliceWidth.Value - numericUpDownLeftCut.Value - numericUpDownRightCut.Value <= 8);
            numericUpDownSliceWidth.ForeColor = valid ? SystemColors.WindowText : Color.Red;
            trackBarFrames.Enabled = valid;
            trackBarFrames.Maximum = (int)(pictureBox1.Image.Width / numericUpDownSliceWidth.Value) - 1;
            if (valid) TrackBarFrames_Scroll(this, null);
        }

        private void ValidateSlice2()
        {
            bool valid = true;// = pictureBox1.Image.Width % numericUpDownSliceWidth.Value == 0;
            valid &= (numericUpDownSliceWidth.Value - numericUpDownLeftCut.Value - numericUpDownRightCut.Value > 0);
            valid &= (numericUpDownSliceWidth.Value - numericUpDownLeftCut.Value - numericUpDownRightCut.Value <= 8);
            numericUpDownLeftCut.ForeColor = valid ? SystemColors.WindowText : Color.Red;
            numericUpDownRightCut.ForeColor = valid ? SystemColors.WindowText : Color.Red;
            //trackBarFrames.Enabled = valid;
            //trackBarFrames.Maximum = (int)(pictureBox1.Image.Width / numericUpDownSliceWidth.Value) - 1;
            if (valid) TrackBarFrames_Scroll(this, null);
        }

        private void NumericUpDownSliceWidth_ValueChanged(object sender, EventArgs e)
        {
            ValidateSlice();
        }
        private void NumericUpDownLeftCut_ValueChanged(object sender, EventArgs e)
        {
            ValidateSlice2();
        }
        private void NumericUpDownRightCut_ValueChanged(object sender, EventArgs e)
        {
            ValidateSlice2();
        }

        private void TrackBarFrames_Scroll(object sender, EventArgs e)
        {
            int frameWidth = (int)numericUpDownSliceWidth.Value;
            int cutFrameWidth = (int)numericUpDownSliceWidth.Value - (int)numericUpDownLeftCut.Value - (int)numericUpDownRightCut.Value;
            Bitmap frame = new Bitmap(frameWidth * 2, pictureBox1.Image.Height);
            Graphics g = Graphics.FromImage(frame);
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            g.DrawImage(pictureBox1.Image, new Rectangle(0, 0, cutFrameWidth * 2, frame.Height), new Rectangle(frameWidth * trackBarFrames.Value + (int)numericUpDownLeftCut.Value, 0, cutFrameWidth, pictureBox1.Image.Height), GraphicsUnit.Pixel);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.Image = frame;
            pmdata = GeneratePmData();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private enum Statuses { leading, content };
        private void ButtonGenerateText_Click(object sender, EventArgs e)
        {
            pmdata = GeneratePmData();
            if (pmdata.Length == 0)
                return;
            string text = $";frames:{frameCount}, height:{frameHeight}\n";

            if (xMove.Length > 0)   //autocut
            {
                text += "xmove\tdta 0,";
                for (int frame = 1; frame < frameCount; frame++)
                    text += $"{xMove[frame - 1] - xMove[frame]},";
                text = text.Remove(text.Length - 1, 1) + "\n";
            }
            bool optimize = checkBoxOptim.Checked;
            int size = xMove.Length;
            if (optimize)
            {
                string text2 = "\n;index table - frame address, count of leading 0, length of content; count of trailing 0\n";
                for (int player = 0; player < 2; player++)
                {
                    text2 += $"table{player}";
                    text += $";player {player} data\n";
                    for (int frame = 0; frame < frameCount; frame++)
                    {
                        text += $"p{player}f{frame:x}\tdta ";
                        int leadingZeros = 0;
                        int contentLength = 0;
                        int trailingZeros = 0;
                        Statuses status = Statuses.leading;
                        for (int y = 0; y < frameHeight; y++)
                        {
                            byte value = pmdata[frameHeight * (frame + player * frameCount) + y];
                            switch (status)
                            {
                                case Statuses.leading:
                                    if (value == 0)
                                    {
                                        leadingZeros++;
                                        continue;
                                    }
                                    else
                                    {
                                        status = Statuses.content;
                                        contentLength++;
                                        text += $"${value:x2},";
                                        size++;
                                    }
                                    break;

                                case Statuses.content:
                                    if (value == 0)
                                    {
                                        trailingZeros++;
                                    }
                                    else
                                    {
                                        contentLength += trailingZeros + 1;
                                        for (int i = 0; i < trailingZeros; i++) text += "$00,";
                                        text += $"${value:x2},";
                                        size++;
                                        trailingZeros = 0;
                                    }
                                    break;
                            }

                        }

                        text = text.Remove(text.Length - 1, 1);
                        text += $"\n";
                        text2 += $"\tdta a(p{player}f{frame:x}),{leadingZeros},{contentLength}\t;{trailingZeros}\n";
                        size += 4;
                    }
                }
                text += text2 + $";size incl.index tables: {size} bytes";
            }
            else
            {
                for (int player = 0; player < 2; player++)

                {
                    text += $";player {player} data\n";
                    for (int frame = 0; frame < frameCount; frame++)
                    {
                        text += $"\tdta ";
                        for (int y = 0; y < frameHeight; y++)
                        {
                            text += $"${pmdata[frameHeight * (frame + player * frameCount) + y]:x2},";
                            size++;
                        }
                        text = text.Remove(text.Length - 1, 1);
                        text += $"\t;frame {frame}\n";
                    }
                }
                text += $";size: {size} bytes";
            }
            richTextBox1.Text = text;
        }

        private void CheckBoxAutoCut_CheckedChanged(object sender, EventArgs e)
        {
            bool status = checkBoxAutoCut.Checked;
            numericUpDownLeftCut.Enabled = !status;
            numericUpDownRightCut.Enabled = !status;
        }
    }
}