using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class frmAdminMainMenu : Form
    {
        public frmAdminMainMenu()
        {
            InitializeComponent();
        }

        public delegate void SignedOut(object sender);

        public event SignedOut onSignedOut;

        protected virtual void SignedOutClicked()
        {
            SignedOut handler = onSignedOut;
            if (handler != null)
            {
                handler?.Invoke(this);
            }
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SignedOutClicked();
            this.Close();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }

}
