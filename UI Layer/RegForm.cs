using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Milestone2__Group1.BusinessLogic_Layer;

namespace Milestone2__Group1.UI_Layer
{
    public partial class RegForm : Form
    {
        FileHandler Users = new FileHandler();

        public RegForm()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            new LogForm().Show();
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
            if (Users.Register(txtName.Text, txtPass.Text) == "True")
            {
                MessageBox.Show("Regsitered Successfully");
            }
            else
            {
                MessageBox.Show("Registration Failed, Please enter correct details!");
            }
        }

        private void txtNum_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            new LogForm().Show();
            this.Close();
        }
    }
}
