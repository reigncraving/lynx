using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Lynx
{
    public partial class NewFileForm : Form
    {
        public string fName = null;
        char[] invalidChar = new char[] { ':', '/', '*', '?', '"', ',', '<', '>' };
        public int cWidth = 0;
        public int cHeight = 0;
        bool checkWidth = false;
        bool checkHeight = false;

        public NewFileForm()
        {
            InitializeComponent();
        }
        private void NewFileForm_Load()
        {
            fName = txtFileName.Text;
            cWidth = int.Parse(txtCanvasWidth.Text);
            cHeight = int.Parse(txtCanvasHeight.Text);
        }

        private void newFileCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void newFileOk_Click(object sender, EventArgs e)
        {
            fName = txtFileName.Text;
            cWidth = int.Parse(txtCanvasWidth.Text);
            cHeight = int.Parse(txtCanvasHeight.Text);
            this.Close();
        }

        private void txtFileNameValidating(object sender, CancelEventArgs e)
        {
            fName = txtFileName.Text;
            foreach (char iChar in invalidChar)
            {
                if (fName.Contains(iChar))
                {
                    MessageBox.Show("File Name cannot contain the following characters:  / : * ? \" < > | ", "Lynx", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtFileName.Text = "Untitled";
                }
            }
        }

        private void txtCanvasWidthValidation(object sender, CancelEventArgs e)
        {
            checkWidth = int.TryParse(txtCanvasWidth.Text, out cWidth);
            if (checkWidth = false || cWidth <= 0 || cWidth > 4000)
            {
                MessageBox.Show("Invalid integer input!\nThe size of the Canvas must be from 1 px to 4000 px.", "Lynx", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCanvasWidth.Text = "800";
            }
        }

        private void txtCanvasHeightValidation(object sender, CancelEventArgs e)
        {
            checkHeight = int.TryParse(txtCanvasHeight.Text, out cHeight);
            if (checkHeight = false || cHeight <= 0 || cWidth > 4000)
            {
                MessageBox.Show("Invalid integer input!\nThe size of the Canvas must be from 1 px to 4000 px.", "Lynx", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCanvasHeight.Text = "600";
            }
        }
    }
}
