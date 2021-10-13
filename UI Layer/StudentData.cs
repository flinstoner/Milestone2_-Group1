using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Milestone2__Group1.UI_Layer;

namespace Milestone2__Group1.UI_Layer
{
    public partial class StudentData : Form
    {
        DataHandler_Layer.DataHandler dataHandler = new DataHandler_Layer.DataHandler();
        public StudentData()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void StudentData_Load(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            new RegForm().Close();
            new LogForm().Close();
            
        }

        private void cmbMCodes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnView_Click(object sender, EventArgs e)
        {
            txtStNumber.Clear();
            txtName.Clear();
            txtSurname.Clear();
            txtPhone.Clear();
            txtStno.Clear();
            txtDOB.Clear();
            dataGridView1.DataSource = dataHandler.GetStudents();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                int stno = Convert.ToInt32(txtStNumber.Text);
                dataGridView1.DataSource = dataHandler.StudentSearch(stno);
                DataTable dataTable = dataHandler.StudentSearch(stno);

                foreach (DataRow row in dataTable.Rows)
                {
                    txtName.Text = row["StudentName"].ToString();
                    txtSurname.Text = row["StudentSurname"].ToString();
                    txtPhone.Text = row["StudentPhone"].ToString();
                    txtStno.Text = row["StudentNumber"].ToString();
                    txtDOB.Text = row["StudentDOB"].ToString();
                }
            }
            catch
            {
                MessageBox.Show("Something Went Wrong. Please ensure a number is inserted into the Student number field.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int stno = Convert.ToInt32(txtStNumber.Text);
                dataHandler.DeleteStudent(stno);
                MessageBox.Show("Student Deleted successfully");
                dataGridView1.DataSource = dataHandler.GetStudents();
            }
            catch
            {
                MessageBox.Show("Something Went Wrong. Please ensure a number is inserted into the Student number field.");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
           
            try
            {
                string name = txtName.Text;
                string surname = txtSurname.Text;
                string gender = cmbGender.Text;
                string DOB = txtDOB.Text;
                string module = cmbMCodes.Text;
                string phone = txtPhone.Text;
                int studentnumber = Convert.ToInt32(txtStno.Text);
                dataHandler.UpdateStudent(name, surname, gender, DOB, studentnumber, phone, module);
                MessageBox.Show("Student succefully updated");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                //MessageBox.Show("Something went wrong, please ensure that your student number is filled in");
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text;
                string surname = txtSurname.Text;
                string gender = cmbGender.Text;
                string DOB = txtDOB.Text;
                string module = cmbMCodes.Text;
                string phone = txtPhone.Text;

                dataHandler.InsertStudent(name, surname, gender, DOB, phone, module);
                //dataHandler.InsertStudent(name, surname, gender, DOB, phone, module);
                MessageBox.Show("Student succefully updated");
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                MessageBox.Show("Something went wrong, please ensure that your student number is filled in");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            new Modules().Show();
        }
    }
}
