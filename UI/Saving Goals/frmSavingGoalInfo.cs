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
    public partial class frmSavingGoalInfo : Form
    {
        private int _goalID;
        public frmSavingGoalInfo(int goalID)
        {
            InitializeComponent();
            this._goalID = goalID;
        }

        private void frmSavingGoalInfo_Load(object sender, EventArgs e)
        {
            btnClose.Focus();
            ctrlSavingGoalInfo1.FillData(_goalID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
