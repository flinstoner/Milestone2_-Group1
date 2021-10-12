using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Milestone2__Group1.UI_Layer
{
    public partial class RegForm : Form
    {
        public RegForm()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            //new UI_Layer.LogForm().Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtNum.Text == "" || txtDoB.Text == "" || cmbGen.Text == "" || txtxNr.Text == "" || cmbMC.Text == "" )
            {
                MessageBox.Show("All fields must be filled before registry.");
            }
            else if (txtPass.Text != txtCPass.Text)
            {
                MessageBox.Show("Passwords do not match!"); 
                txtCPass.Focus();
            }
        }

        private void txtNum_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
