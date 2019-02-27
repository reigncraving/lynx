using System;
using System.Windows.Forms;

namespace Lynx
{
    public partial class AboutLynx : Form
    {
        public AboutLynx()
        {
            InitializeComponent();
        }

        private void aboutOk_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AboutLynx_Load(object sender, EventArgs e)
        {

        }
    }
}
