using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace Lynx
{
    public partial class LynxForm : Form
    {
        Bitmap Img;
        Graphics gr;
        Color paintingColor1 = Color.Black;
        Color paintingColor2 = Color.White;
        Point sP = new Point(0, 0);
        Point eP = new Point(0, 0);
        Pen mPen;
        Brush mBrush;
        Rectangle rec = new Rectangle();
        PictureBox picState = new PictureBox();
        PictureBox picTemp = new PictureBox();
        Button[] ccButtons = new Button[16];
        Font mFont = new Font("Microsoft Sans Serif", 12);
        tools selectedTool;
        public string fileName = "Untitled";
        public string statePath = Directory.GetCurrentDirectory() + @"\History\";
        public byte r = 0;
        public byte g = 0;
        public byte b = 0;
        public int toolSize = 0;
        public int historyCount = 0;
        bool checkText = false;
        bool chooseColor = false;
        bool draw = false;
        bool isFileChanged = false;
        int x, y, x1, y1 = 0;
        public int[] ccColors = new int[16];

        public LynxForm()
        {
            InitializeComponent();
            CcButtonsFiller();
            CustomColorFiller();
            Directory.CreateDirectory(statePath);
        }
        //Fills array with the custom color buttons from the UI
        public void CcButtonsFiller()
        {
            ccButtons[0] = btnCc1;
            ccButtons[1] = btnCc2;
            ccButtons[2] = btnCc3;
            ccButtons[3] = btnCc4;
            ccButtons[4] = btnCc5;
            ccButtons[5] = btnCc6;
            ccButtons[6] = btnCc7;
            ccButtons[7] = btnCc8;
            ccButtons[8] = btnCc9;
            ccButtons[9] = btnCc10;
            ccButtons[10] = btnCc11;
            ccButtons[11] = btnCc12;
            ccButtons[12] = btnCc13;
            ccButtons[13] = btnCc14;
            ccButtons[14] = btnCc15;
            ccButtons[15] = btnCc16;
        }
        // Fills colorDialog custom colors with UI buttons' back color:
        public void CustomColorFiller()
        {
            for (int i = 0; i < ccButtons.Length; i++)
            {
                ccColors[i] = ColorTranslator.ToWin32(ccButtons[i].BackColor);
            }
            colorDialog1.CustomColors = ccColors;
        }
        // Appllies the selected painting color to UI
        private void ColorApplying()
        {
            if (radioCw1.Checked)
            {
                picCw1.BackColor = paintingColor1;
                trackBarR.Value = paintingColor1.R;
                trackBarG.Value = paintingColor1.G;
                trackBarB.Value = paintingColor1.B;
                txtR.Text = trackBarR.Value.ToString();
                txtG.Text = trackBarG.Value.ToString();
                txtB.Text = trackBarB.Value.ToString();
                btnToolsTopFillColor.BackColor = paintingColor1;
            }
            if (radioCw2.Checked)
            {
                picCw2.BackColor = paintingColor2;
                trackBarR.Value = paintingColor2.R;
                trackBarG.Value = paintingColor2.G;
                trackBarB.Value = paintingColor2.B;
                txtR.Text = trackBarR.Value.ToString();
                txtG.Text = trackBarG.Value.ToString();
                txtB.Text = trackBarB.Value.ToString();
                btnToolsTopFillColor.BackColor = paintingColor2;
            }
        }
        // Fills Img with white color and clones Canvas size
        public Bitmap ImgFillingWhite(Bitmap i)
        {
            i = new Bitmap(picCanvas.ClientSize.Width, picCanvas.ClientSize.Height, PixelFormat.Format32bppArgb);
            using (Graphics gr = Graphics.FromImage(i))
            {
                using (mBrush = new SolidBrush(Color.White))
                {
                    gr.FillRectangle(mBrush, 0, 0, i.Width, i.Height);
                }
            }
            Img = i;
            return i;
        }
        // clears history by deleting all files in history folder 
        public void DeleteHistory()
        {
            picState.Dispose();
            DirectoryInfo dir = new DirectoryInfo(statePath);
            foreach (FileInfo file in dir.GetFiles())
            {
                file.Delete();
            }
            historyCount = 0;
        }

        private void LynxForm_Load(object sender, EventArgs e)
        {
            Img = new Bitmap(picCanvas.Image);
            DeleteHistory();
            ImgFillingWhite(Img);
            AddState(Img);
            btnToolsLeftBrush.PerformClick();
            fileName = "Untitled.jpeg";
            StBarFileName.Text = fileName;
            txtFontSize.Text = mFont.Size.ToString();
            isFileChanged = false;
        }

        public enum tools
        {
            ColorPick, TextTool, Brush, Eraser, LineTool, Rectangle, Ellipse, FillTool
        }

        // New File:
        private void menuFileNew_Click(object sender, EventArgs e)
        {
            if (isFileChanged)
            {
                var result = MessageBox.Show("You have made changes on the file.\nDo you want to save these changes?", "Lynx", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    menuFileSaveAs.PerformClick();
                }
            }
            using (NewFileForm nff = new NewFileForm())
            {
                if (nff.ShowDialog() == DialogResult.OK)
                {
                    DeleteHistory();
                    fileName = nff.fName + ".jpg";
                    StBarFileName.Text = fileName;
                    picCanvas.ImageLocation = null;
                    picCanvas.BackColor = Color.White;
                    picCanvas.Height = nff.cHeight;
                    picCanvas.Width = nff.cWidth;
                    picCanvas.Invalidate();
                    ImgFillingWhite(Img);
                    AddState(Img);
                    isFileChanged = false;
                }
            }
        }
        // New file tools top Icon activated
        private void toolsTopNewFile_Click(object sender, EventArgs e)
        {
            menuFileNew.PerformClick();
        }
        // load a file:
        private void menuFileOpen_Click(object sender, EventArgs e)
        {
            if (isFileChanged)
            {
                var result = MessageBox.Show("You have made changes on the file.\nDo you want to save these changes?", "Lynx", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    menuFileSaveAs.PerformClick();
                }
            }
            using (OpenFileDialog opnFile = new OpenFileDialog())
            {
                opnFile.FileName = string.Empty;
                opnFile.Title = "Open File";
                opnFile.Filter = "JPEG | *.jpg; *.jpeg | GIF | *.gif | BMP | *.bmp | PNG | *.png | TIFF | *.tif; *.tiff | ALL FILES (*.*)| *.*";
                opnFile.Multiselect = false;
                if (opnFile.ShowDialog() == DialogResult.OK)
                {
                    DeleteHistory();
                    fileName = opnFile.FileName;
                    isFileChanged = false;
                    picTemp.ImageLocation = fileName;
                    picTemp.Load();
                    picCanvas.Image = picTemp.Image;
                    StBarFileName.Text = fileName;
                    Img = new Bitmap(picCanvas.Image);
                    AddState(Img);
                }
            }
        }
        // Save:
        private void menuFileSave_Click(object sender, EventArgs e)
        {
            if (isFileChanged == false)
            {
                menuFileSaveAs.PerformClick();
            }
            else
            {
                using (SaveFileDialog sv = new SaveFileDialog())
                {
                    sv.FileName = fileName;
                    if (Directory.Exists(fileName))
                    {
                        picTemp.Dispose();
                        File.Delete(fileName);
                        Img.Save(fileName);
                    }
                    else
                    {
                        picTemp.Dispose();
                        File.Delete(fileName);
                        Img.Save(fileName);
                    }
                    picTemp.ImageLocation = fileName;
                    picTemp.Load();
                    picCanvas.Image = picTemp.Image;
                    StBarFileName.Text = fileName;
                    Img = new Bitmap(picCanvas.Image);
                    isFileChanged = false;
                }
            }
        }
        // save Icon Tools Top clicked
        private void toolsTopSave_Click(object sender, EventArgs e)
        {
            menuFileSave.PerformClick();
        }
        // Save as:
        private void menuFileSaveAs_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog svAs = new SaveFileDialog())
            {
                svAs.FileName = fileName;
                svAs.Title = "Save as..";
                svAs.Filter = "JPEG | *.jpg; *.jpeg | GIF | *.gif | BMP | *.bmp | PNG | *.png | TIFF | *.tif; *.tiff | ALL FILES (*.*)| *.*";
                if (svAs.ShowDialog() == DialogResult.OK)
                {
                    Img.Save(svAs.FileName);
                    fileName = svAs.FileName;
                    StBarFileName.Text = fileName;
                    isFileChanged = false;
                }
            }
        }
        // Menu Exit:
        private void menuFileExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        // Exit via X button & clossing event
        private void LynxForm_Closing(object sender, FormClosingEventArgs e)
        {
            if (isFileChanged)
            {
                var result = MessageBox.Show("You have made changes on the file.\nDo you want to save these changes?", "Lynx", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    menuFileSaveAs.PerformClick();
                    Img.Dispose();
                    DeleteHistory();
                    picCanvas.Dispose();
                    Application.Exit();
                }
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
                else if (result == DialogResult.No)
                {
                    isFileChanged = false;
                    Img.Dispose();
                    DeleteHistory();
                    picCanvas.Dispose();
                    Application.Exit();
                }
                else
                {
                    Img.Dispose();
                    DeleteHistory();
                    picCanvas.Dispose();
                    Application.Exit();
                }
            }
        }

        private void menuEditClear_Click(object sender, EventArgs e)
        {
            ImgFillingWhite(Img);
            picCanvas.Invalidate();
        }

        private void menuTypeFont_Click(object sender, EventArgs e)
        {
            showFontDialog.PerformClick();
        }
        // Adds History image State
        public void AddState(Bitmap i)
        {
            try
            {
                historyCount++;
                if (historyCount == 10)
                {
                    DeleteHistory();
                    historyCount = 0;
                }
                using (SaveFileDialog sv = new SaveFileDialog())
                {
                    DirectoryInfo dir = new DirectoryInfo(statePath);
                    dir.Create();
                    sv.FileName = statePath + historyCount.ToString() + ".bmp";
                    i.Save(sv.FileName, ImageFormat.Bmp);
                }
            }
            catch (System.Runtime.InteropServices.ExternalException)
            {
                MessageBox.Show("Oops, something went wrong", "Lynx", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
   
        // Undo
        private void menuEditUndo_Click(object sender, EventArgs e)
        {
            menuEditBackward.PerformClick();
        }
        // Step Backward Menu (ctrl + z)
        private void menuEditBackward_Click(object sender, EventArgs e)
        {
            try
            {
                historyCount--;
                if (historyCount < 0)
                {
                    historyCount = 0;
                }
                else
                {
                    picState.ImageLocation = statePath + historyCount.ToString() + ".bmp";
                    picState.Load();
                    picCanvas.Image = picState.Image;
                    Img = new Bitmap(picCanvas.Image);
                }
            }
            catch (FileNotFoundException)
            {
            }
        }
        // Tools Top step backward icon 
        private void toolsTopBackward_Click(object sender, EventArgs e)
        {
            menuEditBackward.PerformClick();
        }
        // Step Forward Menu
        private void menuEditForward_Click(object sender, EventArgs e)
        {
            try
            {
                historyCount++;
                if (historyCount > 10)
                {
                    historyCount = 10;
                }
                else
                {
                    picState.ImageLocation = statePath + historyCount.ToString() + ".bmp";
                    picState.Load();
                    picCanvas.Image = picState.Image;
                    Img = new Bitmap(picCanvas.Image);
                }
            }
            catch (FileNotFoundException)
            {

            }
        }
        // Tools Top step forward icon
        private void toolsTopForwards_Click(object sender, EventArgs e)
        {
            menuEditForward.PerformClick();
        }
        // About Lynx form:
        private void menuHelpAbout_Click(object sender, EventArgs e)
        {
            using (AboutLynx abLynx = new AboutLynx())
            {
                abLynx.ShowDialog();
            }
        }
        // painting event 
        private void paintingOnCanvas(object sender, PaintEventArgs e)
        {
            gr = Graphics.FromImage(Img);
            e.Graphics.DrawImage(Img, 0, 0, Img.Width, Img.Height);
            if (radioCw1.Checked)
            {
                mBrush = new SolidBrush(paintingColor1);
                mPen = new Pen(mBrush, float.Parse(txtToolsTopSizebox.Text));
            }
            if (radioCw2.Checked)
            {
                mBrush = new SolidBrush(paintingColor2);
                mPen = new Pen(mBrush, float.Parse(txtToolsTopSizebox.Text));
            }
            switch (selectedTool)
            {
                // Line tool
                case tools.LineTool:
                    {
                        if (draw)
                        {
                            gr.DrawLine(new Pen(mBrush, float.Parse(txtToolsTopSizebox.Text)), sP, eP);
                            isFileChanged = true;
                        }
                        break;
                    }
                // Rectangle
                case tools.Rectangle:
                    {
                        if (draw)
                        {
                            rec.X = x1;
                            rec.Y = y1;
                            rec.Height = int.Parse(txtToolsTopHeight.Text);
                            rec.Width = int.Parse(txtToolsTopWidth.Text);
                            gr.DrawRectangle(mPen, rec);
                            if (radioCw1.Checked)
                            {
                                gr.FillRectangle(new SolidBrush(paintingColor2), rec);
                            }
                            else
                            {
                                gr.FillRectangle(new SolidBrush(paintingColor1), rec);
                            }
                            isFileChanged = true;
                        }
                        break;
                    }
                // Ellipse
                case tools.Ellipse:
                    {
                        if (draw)
                        {
                            rec.X = x1;
                            rec.Y = y1;
                            rec.Height = int.Parse(txtToolsTopHeight.Text);
                            rec.Width = int.Parse(txtToolsTopWidth.Text);
                            gr.DrawEllipse(mPen, rec);
                            if (radioCw1.Checked)
                            {
                                gr.FillEllipse(new SolidBrush(paintingColor2), rec);
                            }
                            else
                            {
                                gr.FillEllipse(new SolidBrush(paintingColor1), rec);
                            }
                            isFileChanged = true;
                        }
                        break;
                    }
                // Text
                case tools.TextTool:
                    {
                        if (draw)
                        {
                            string txt = txtFontInput.Text;
                            gr.DrawString(txt, mFont, mBrush, sP);
                            isFileChanged = true;
                        }

                        break;
                    }
                // Fill tool
                case tools.FillTool:
                    {
                        if (draw)
                        {
                            gr.FillRectangle(mBrush, 0, 0, Img.Width, Img.Height);
                            isFileChanged = true;
                        }
                        break;
                    }
            }
            Invalidate();
            mPen.Dispose();
            mBrush.Dispose();
            gr.Dispose();
        }
        // Mouse button holded down on Canvas surface
        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                x1 = e.X;
                y1 = e.Y;
                sP = e.Location;
                draw = true;
            }
        }
        // Mouse button is release on Canvas surface
        private void Canvas_MouseUp(object sender, MouseEventArgs e)
        {
            eP = e.Location;
            draw = false;
            if (selectedTool == tools.ColorPick)
            {
                // Color Pick don't add History State
            }
            else
            {
                AddState(Img);
            }
        }
        // the mouse moves in the canvas
        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            stBarCoord.Text = "X: " + e.X.ToString() + " Y: " + e.Y.ToString();
            if (draw)
            {
                x = e.X;
                y = e.Y;
                gr = Graphics.FromImage(Img);
                {
                    if (radioCw1.Checked)
                    {
                        mBrush = new SolidBrush(paintingColor1);
                        mPen = new Pen(mBrush, float.Parse(txtToolsTopSizebox.Text));
                    }
                    if (radioCw2.Checked)
                    {
                        mBrush = new SolidBrush(paintingColor2);
                        mPen = new Pen(mBrush, float.Parse(txtToolsTopSizebox.Text));
                    }
                    switch (selectedTool)
                    {
                        // Color Pick
                        case tools.ColorPick:
                            {
                                if (draw && e.Button == MouseButtons.Left)
                                {
                                    try
                                    {
                                        Bitmap clrPick = (Bitmap)Img.Clone();
                                        if (radioCw1.Checked)
                                        {
                                            paintingColor1 = clrPick.GetPixel(x, y);
                                            txtToolsTopClrPick.Text = "R: " + paintingColor1.R.ToString() + " G: " + paintingColor1.B.ToString() + " B: " + paintingColor1.B.ToString();
                                            btnToolsTopColorPick.BackColor = paintingColor1;
                                        }
                                        if (radioCw2.Checked)
                                        {
                                            paintingColor2 = clrPick.GetPixel(x, y);
                                            txtToolsTopClrPick.Text = "R: " + paintingColor2.R.ToString() + " G: " + paintingColor2.B.ToString() + " B: " + paintingColor2.B.ToString();
                                            btnToolsTopColorPick.BackColor = paintingColor2;
                                        }
                                        ColorApplying();
                                        clrPick.Dispose();
                                    }
                                    catch (ArgumentOutOfRangeException)
                                    {
                                        MessageBox.Show("Color value out of Canvas!", "Lynx", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                break;
                            }
                        // Brush
                        case tools.Brush:
                            {
                                gr.FillEllipse(mBrush, x, y, float.Parse(txtToolsTopSizebox.Text), float.Parse(txtToolsTopSizebox.Text));
                                isFileChanged = true;
                                break;
                            }
                        // Eraser
                        case tools.Eraser:
                            {
                                gr.FillEllipse(new SolidBrush(paintingColor2), x, y, float.Parse(txtToolsTopSizebox.Text), float.Parse(txtToolsTopSizebox.Text));
                                isFileChanged = true;
                                break;
                            }
                    }
                }
                mPen.Dispose();
                mBrush.Dispose();
                gr.Dispose();
                picCanvas.Image = Img;
                picCanvas.Invalidate();// redraw Canvas ( so the painted part is shown when resizing the window )
            }
        }
        // Color Wheel control:

        private void ColorWheel_MouseDown(object sender, MouseEventArgs e)
        {
            chooseColor = true;
            Cursor = Cursors.Hand;
        }

        private void ColorWheel_MouseUp(object sender, MouseEventArgs e)
        {
            chooseColor = false;
            Cursor = Cursors.Default;
        }

        private void ColorWheel_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (chooseColor == true && e.Button == MouseButtons.Left)
                {
                    Bitmap bmpChooseL = (Bitmap)picColorWheel.Image.Clone();
                    if (radioCw1.Checked)
                    {
                        paintingColor1 = bmpChooseL.GetPixel(e.X, e.Y);
                    }
                    if (radioCw2.Checked)
                    {
                        paintingColor2 = bmpChooseL.GetPixel(e.X, e.Y);
                    }
                    ColorApplying();
                    bmpChooseL.Dispose();
                }
                if (chooseColor == true && e.Button == MouseButtons.Right)
                {
                    Bitmap bmpChooseR = (Bitmap)picColorWheel.Image.Clone();
                    if (radioCw1.Checked)
                    {
                        paintingColor2 = bmpChooseR.GetPixel(e.X, e.Y);
                        picCw2.BackColor = paintingColor2;
                        trackBarR.Value = paintingColor2.R;
                        trackBarG.Value = paintingColor2.G;
                        trackBarB.Value = paintingColor2.B;
                        txtR.Text = trackBarR.Value.ToString();
                        txtG.Text = trackBarG.Value.ToString();
                        txtB.Text = trackBarB.Value.ToString();
                    }
                    if (radioCw2.Checked)
                    {
                        paintingColor1 = bmpChooseR.GetPixel(e.X, e.Y);
                        picCw1.BackColor = paintingColor1;
                        trackBarR.Value = paintingColor1.R;
                        trackBarG.Value = paintingColor1.G;
                        trackBarB.Value = paintingColor1.B;
                        txtR.Text = trackBarR.Value.ToString();
                        txtG.Text = trackBarG.Value.ToString();
                        txtB.Text = trackBarB.Value.ToString();
                    }
                    bmpChooseR.Dispose();
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Color value out of Color Wheel!", "Lynx", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Color Bars sliding - color select
        private void ChangeColor(object sender, EventArgs e)
        {
            if (radioCw1.Checked)
            {
                paintingColor1 = Color.FromArgb(trackBarR.Value, trackBarG.Value, trackBarB.Value);
                picCw1.BackColor = paintingColor1;
                txtR.Text = trackBarR.Value.ToString();
                txtG.Text = trackBarG.Value.ToString();
                txtB.Text = trackBarB.Value.ToString();
                btnToolsTopFillColor.BackColor = paintingColor1;
            }
            else if (radioCw2.Checked)
            {
                paintingColor2 = Color.FromArgb(trackBarR.Value, trackBarG.Value, trackBarB.Value);
                picCw2.BackColor = paintingColor2;
                txtR.Text = trackBarR.Value.ToString();
                txtG.Text = trackBarG.Value.ToString();
                txtB.Text = trackBarB.Value.ToString();
                btnToolsTopFillColor.BackColor = paintingColor2;
            }
        }

        // Enter color value in RGB Text Boxes:
        private void EnterColorInputRGB(object sender, EventArgs e)
        {
            if (radioCw1.Checked)
            {
                paintingColor1 = Color.FromArgb(r, g, b);
                picCw1.BackColor = paintingColor1;
                trackBarR.Value = paintingColor1.R;
                trackBarG.Value = paintingColor1.G;
                trackBarB.Value = paintingColor1.B;
            }
            if (radioCw2.Checked)
            {
                paintingColor2 = Color.FromArgb(r, g, b);
                picCw2.BackColor = paintingColor2;
                trackBarR.Value = paintingColor2.R;
                trackBarG.Value = paintingColor2.G;
                trackBarB.Value = paintingColor2.B;
            }
        }
        // Radio color 1 selected
        private void radioCw_1_CheckedChanged(object sender, EventArgs e)
        {
            ColorApplying();
        }
        // Radio color 2 selected
        private void radioCw_2_CheckedChanged(object sender, EventArgs e)
        {
            ColorApplying();
        }
        // Locks / unlocks left toolbar
        private void toolsLeftLock_Click(object sender, EventArgs e)
        {
            if (btnToolsLeftLock.Checked)
            {
                tlbToolsLeft.GripStyle = ToolStripGripStyle.Visible;
                btnToolsLeftLock.Image = Lynx.Properties.Resources.Unlocked;
            }
            else
            {
                tlbToolsLeft.GripStyle = ToolStripGripStyle.Hidden;
                btnToolsLeftLock.Image = Lynx.Properties.Resources.Locked;
            }
        }
        //Color pick selected from left toolbar
        private void toolsLeftColorPick_Click(object sender, EventArgs e)
        {
            selectedTool = tools.ColorPick;
            btnToolsTopMode.Image = Lynx.Properties.Resources.Droplet;
            btnToolsTopMode.ToolTipText = "Color Picker";
            lblToolsTopHeight.Visible = false;
            txtToolsTopHeight.Visible = false;
            lblToolsTopWidth.Visible = false;
            txtToolsTopWidth.Visible = false;
            btnToolsTopColorPick.Visible = true;
            txtToolsTopClrPick.Visible = true;
            lblToolsTopSize.Visible = false;
            txtToolsTopSizebox.Visible = false;
            lblToolsTopMetrix.Visible = false;
            btnToolsTopPlus.Visible = false;
            btnToolsTopMinus.Visible = false;
            btnToolsTopFillColor.Visible = false;
            btnToolsTopFillColor.ToolTipText = "Fill Color";
        }
        // Text tool selected from left toolbar
        private void toolsLeftText_Click(object sender, EventArgs e)
        {
            selectedTool = tools.TextTool;
            btnToolsTopMode.Image = Lynx.Properties.Resources.text;
            btnToolsTopMode.ToolTipText = "Text Tool";
            lblToolsTopHeight.Visible = false;
            txtToolsTopHeight.Visible = false;
            lblToolsTopWidth.Visible = false;
            txtToolsTopWidth.Visible = false;
            txtToolsTopClrPick.Visible = false;
            lblToolsTopSize.Visible = false;
            txtToolsTopSizebox.Visible = false;
            lblToolsTopMetrix.Visible = false;
            btnToolsTopPlus.Visible = false;
            btnToolsTopMinus.Visible = false;
            btnToolsTopColorPick.Visible = false;
            btnToolsTopFillColor.Visible = true;
            btnToolsTopFillColor.ToolTipText = "Letter Color";
            if (radioCw1.Checked)
            {
                btnToolsTopFillColor.BackColor = paintingColor1;
            }
        }
        //Brush selected from left toolbar
        private void toolsLeftBrush_Click(object sender, EventArgs e)
        {
            selectedTool = tools.Brush;
            btnToolsTopMode.Image = Lynx.Properties.Resources.Brush;
            btnToolsTopMode.ToolTipText = "Brush";
            lblToolsTopHeight.Visible = false;
            txtToolsTopHeight.Visible = false;
            lblToolsTopWidth.Visible = false;
            txtToolsTopWidth.Visible = false;
            lblToolsTopSize.Visible = true;
            txtToolsTopSizebox.Visible = true;
            lblToolsTopMetrix.Visible = true;
            btnToolsTopPlus.Visible = true;
            btnToolsTopMinus.Visible = true;
            txtToolsTopClrPick.Visible = false;
            btnToolsTopColorPick.Visible = false;
            btnToolsTopFillColor.Visible = false;
            txtToolsTopSizebox.Text = "12";
        }
        // Eraser selected from left toolbar
        private void toolsLeftEraser_Click(object sender, EventArgs e)
        {
            selectedTool = tools.Eraser;
            btnToolsTopMode.Image = Lynx.Properties.Resources.Eraser;
            btnToolsTopMode.ToolTipText = "Eraser";
            lblToolsTopHeight.Visible = false;
            txtToolsTopHeight.Visible = false;
            lblToolsTopWidth.Visible = false;
            txtToolsTopWidth.Visible = false;
            lblToolsTopSize.Visible = true;
            txtToolsTopSizebox.Visible = true;
            lblToolsTopMetrix.Visible = true;
            btnToolsTopPlus.Visible = true;
            btnToolsTopMinus.Visible = true;
            txtToolsTopClrPick.Visible = false;
            btnToolsTopColorPick.Visible = false;
            btnToolsTopFillColor.Visible = false;
            txtToolsTopSizebox.Text = "30";
        }
        // Line Tool selected from left toolbar
        private void toolsLeftLine_Click(object sender, EventArgs e)
        {
            selectedTool = tools.LineTool;
            btnToolsTopMode.Image = Lynx.Properties.Resources.line;
            btnToolsTopMode.ToolTipText = "Line Tool";
            lblToolsTopHeight.Visible = false;
            txtToolsTopHeight.Visible = false;
            lblToolsTopWidth.Visible = false;
            txtToolsTopWidth.Visible = false;
            lblToolsTopSize.Visible = true;
            txtToolsTopSizebox.Visible = true;
            lblToolsTopMetrix.Visible = true;
            btnToolsTopPlus.Visible = true;
            btnToolsTopMinus.Visible = true;
            txtToolsTopClrPick.Visible = false;
            btnToolsTopColorPick.Visible = false;
            btnToolsTopFillColor.Visible = false;
            txtToolsTopSizebox.Text = "2";
        }
        // Recntagle tool selected from toolbar
        private void toolsLeftRectangle_Click(object sender, EventArgs e)
        {
            selectedTool = tools.Rectangle;
            btnToolsTopMode.Image = Lynx.Properties.Resources.Rectangle;
            btnToolsTopMode.ToolTipText = "Rectangle";
            lblToolsTopHeight.Visible = true;
            txtToolsTopHeight.Visible = true;
            lblToolsTopWidth.Visible = true;
            txtToolsTopWidth.Visible = true;
            lblToolsTopSize.Visible = true;
            txtToolsTopSizebox.Visible = true;
            lblToolsTopMetrix.Visible = true;
            btnToolsTopPlus.Visible = true;
            btnToolsTopMinus.Visible = true;
            txtToolsTopClrPick.Visible = false;
            btnToolsTopColorPick.Visible = false;
            btnToolsTopFillColor.Visible = false;
            txtToolsTopSizebox.Text = "2";
        }
        // Ellipse tool selected from toolbar
        private void toolsLeftEllipse_Click(object sender, EventArgs e)
        {
            selectedTool = tools.Ellipse;
            btnToolsTopMode.Image = Lynx.Properties.Resources.circleFull;
            btnToolsTopMode.ToolTipText = "Ellipse";
            lblToolsTopHeight.Visible = true;
            txtToolsTopHeight.Visible = true;
            lblToolsTopWidth.Visible = true;
            txtToolsTopWidth.Visible = true;
            lblToolsTopSize.Visible = true;
            txtToolsTopSizebox.Visible = true;
            lblToolsTopMetrix.Visible = true;
            btnToolsTopPlus.Visible = true;
            btnToolsTopMinus.Visible = true;
            txtToolsTopClrPick.Visible = false;
            btnToolsTopColorPick.Visible = false;
            btnToolsTopFillColor.Visible = false;
            txtToolsTopSizebox.Text = "2";
        }
        // Fill tool selected from toolbar
        private void toolsLeftFill_Click(object sender, EventArgs e)
        {
            selectedTool = tools.FillTool;
            btnToolsTopMode.Image = Lynx.Properties.Resources.tools2;
            btnToolsTopMode.ToolTipText = "Fill Tool";
            lblToolsTopHeight.Visible = false;
            txtToolsTopHeight.Visible = false;
            lblToolsTopWidth.Visible = false;
            txtToolsTopWidth.Visible = false;
            lblToolsTopSize.Visible = false;
            txtToolsTopSizebox.Visible = false;
            lblToolsTopMetrix.Visible = false;
            btnToolsTopPlus.Visible = false;
            btnToolsTopMinus.Visible = false;
            txtToolsTopClrPick.Visible = false;
            btnToolsTopColorPick.Visible = false;
            btnToolsTopFillColor.Visible = true;
            btnToolsTopFillColor.ToolTipText = "Fill Color";
            if (radioCw1.Checked)
            {
                btnToolsTopFillColor.BackColor = paintingColor1;
            }
            else if (radioCw2.Checked)
            {
                btnToolsTopFillColor.BackColor = paintingColor2;
            }
        }
        // Top Toolbar size set - Plus pressed down
        private void toolsTopPlus_MouseDown(object sender, MouseEventArgs e)
        {
            do
            {
                if (toolSize == 100)
                {
                    break;
                }
                toolSize++;
                txtToolsTopSizebox.Text = toolSize.ToString();
            } while (toolSize <= 1 || toolSize >= 100 && e.Button == MouseButtons.Left);
        }
        // Top Toolbar size set - Minus pressed down
        private void toolsTopMinus_MouseDown(object sender, MouseEventArgs e)
        {
            do
            {
                if (toolSize == 1)
                {
                    break;
                }
                toolSize--;
                txtToolsTopSizebox.Text = toolSize.ToString();
            } while (toolSize <= 1 || toolSize >= 100 && e.Button == MouseButtons.Left);
        }
        // Custom Colors clear button
        public void CustomColorClear(object sender, EventArgs e)
        {
            foreach (Button btn in ccButtons)
            {
                btn.BackColor = Color.White;
            }
            CustomColorFiller();
        }
        // Menu View status bar
        private void menuViewStatusBar_Click(object sender, EventArgs e)
        {
            if (menuViewStatusBar.Checked)
            {
                lynxStBar.Visible = true;
            }
            else
            {
                lynxStBar.Visible = false;
            }
        }
        // Applies custom colors buttons back color to main painting colors (all buttons event)
        private void ccButtonClick(object sender, EventArgs e)
        {
            if (radioCw1.Checked)
            {
                paintingColor1 = ((Button)sender).BackColor;
            }
            else if (radioCw2.Checked)
            {
                paintingColor2 = ((Button)sender).BackColor;
            }
            ColorApplying();
        }
        // Color Dialog button ( Color dialog custom colors added to UI buttons' back color ):
        public void showColorDialog_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog1 = new ColorDialog())
            {
                colorDialog1.FullOpen = true;
                colorDialog1.CustomColors = ccColors;
                if (colorDialog1.ShowDialog() == DialogResult.OK)
                {
                    for (int i = 0; i < ccColors.Length; i++)
                    {
                        ccColors[i] = colorDialog1.CustomColors[i];
                        ccButtons[i].BackColor = ColorTranslator.FromWin32(ccColors[i]);
                    }
                    if (radioCw1.Checked)
                    {
                        paintingColor1 = colorDialog1.Color;
                    }
                    if (radioCw2.Checked)
                    {
                        paintingColor2 = colorDialog1.Color;
                    }
                    ColorApplying();
                }
            }
        }
        // Font dialog button clicked in right toolbar
        private void showFontDialog_Click(object sender, EventArgs e)
        {
            using (FontDialog fontDg = new FontDialog())
            {
                if (fontDg.ShowDialog() == DialogResult.OK)
                {
                    mFont = fontDg.Font;
                    lblFontName.Text = mFont.Name.ToString();
                    lblFontName.Font = mFont;
                    lblFontName.AutoSize = false;
                    txtFontSize.Text = mFont.Size.ToString();
                }
            }
        }

        //Validations goes here:

        // Input for color text boxes validation
        private void RBGtextChange(object sender, EventArgs e)
        {
            try
            {
                r = byte.Parse(txtR.Text);
                g = byte.Parse(txtG.Text);
                b = byte.Parse(txtB.Text);
            }
            catch (OverflowException)
            {
                MessageBox.Show("Invalid RGB input! \nEntered value must be from 0 to 255.", "Lynx", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (radioCw1.Checked)
                {
                    txtR.Text = picCw1.BackColor.R.ToString();
                    txtG.Text = picCw1.BackColor.G.ToString();
                    txtB.Text = picCw1.BackColor.B.ToString();
                }
                else
                {
                    txtR.Text = picCw2.BackColor.R.ToString();
                    txtG.Text = picCw2.BackColor.G.ToString();
                    txtB.Text = picCw2.BackColor.B.ToString();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid RGB input! \nEntered value must be from 0 to 255.", "Lynx", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (radioCw1.Checked)
                {
                    txtR.Text = picCw1.BackColor.R.ToString();
                    txtG.Text = picCw1.BackColor.G.ToString();
                    txtB.Text = picCw1.BackColor.B.ToString();
                }
                else
                {
                    txtR.Text = picCw2.BackColor.R.ToString();
                    txtG.Text = picCw2.BackColor.G.ToString();
                    txtB.Text = picCw2.BackColor.B.ToString();
                }

            }
        }

        private void txtTopSizeboxValidating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            checkText = int.TryParse(txtToolsTopSizebox.Text.ToString(), out toolSize);
            if (checkText == false || toolSize <= 0 || toolSize > 100)
            {
                MessageBox.Show("Invalid integer input!\nThe size for the tool must be from 1 px to 100 px.", "Lynx", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtToolsTopSizebox.Text = "12";
            }
        }

        private void txtFontSizeValidating(object sender, EventArgs e)
        {
            float fSize = 0;
            checkText = float.TryParse(txtFontSize.Text.ToString(), out fSize);
            if (checkText == false || fSize <= 0 || fSize > 100)
            {
                MessageBox.Show("Invalid float input!\nThe size for the tool must be from 1 px to 100 px.", "Lynx", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFontSize.Text = mFont.Size.ToString();
            }
            else
            {
                Font nFont = new Font(mFont.FontFamily, fSize);
                mFont = nFont;
                lblFontName.Text = mFont.Name.ToString();
                lblFontName.Font = mFont;
                lblFontName.AutoSize = false;
            }
        }

        private void txtToolsTopHeightValidating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            int Hsize = 0;
            checkText = int.TryParse(txtToolsTopHeight.Text, out Hsize);
            if (checkText == false || Hsize <= 0 || Hsize > 1000)
            {
                MessageBox.Show("Invalid integer input!\nThe size for the Height must be from 1 px to 1000 px.", "Lynx", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtToolsTopHeight.Text = "100";
            }
        }

        private void txtToolsTopWidthValidating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            int Wsize = 0;
            checkText = int.TryParse(txtToolsTopWidth.Text, out Wsize);
            if (checkText == false || Wsize <= 0 || Wsize > 1000)
            {
                MessageBox.Show("Invalid integer input!\nThe size for the Width must be from 1 px to 1000 px.", "Lynx", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtToolsTopWidth.Text = "100";
            }
        }
    }
}
