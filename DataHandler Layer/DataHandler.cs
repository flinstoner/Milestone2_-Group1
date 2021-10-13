using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Milestone2__Group1.DataHandler_Layer
{
    class DataHandler
    {
        string connect = @"Data Source=LENOVO\SQLEXPRESS;Initial Catalog=SchoolDbNew;Integrated Security=True";
        public DataTable GetStudents()
        {
            SqlConnection conn = new SqlConnection(connect);

            string fetchQuery = @"SELECT * FROM Students";

            SqlDataAdapter dataAdapter = new SqlDataAdapter(fetchQuery, conn);

            DataTable dataTable = new DataTable();

            dataAdapter.Fill(dataTable);

            return dataTable;
        }

        public DataTable StudentSearch(int StudentNumber)
        {
            SqlConnection conn = new SqlConnection(connect);

            string fetchQuery = $@"SELECT * FROM Students WHERE StudentNumber = {StudentNumber}";

            SqlDataAdapter dataAdapter = new SqlDataAdapter(fetchQuery, conn);

            DataTable dataTable = new DataTable();

            dataAdapter.Fill(dataTable);

            return dataTable;
        }

        public void DeleteStudent(int StudentNumber)
        {
            SqlConnection conn = new SqlConnection(connect);

            string DeleteQuery = $@"DELETE FROM Students WHERE StudentNumber = {StudentNumber}";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = DeleteQuery;
            cmd.Connection = conn;

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void UpdateStudent(string name,string surname,string gender,string DOB,int studennumber, string phonenumber,string module)
        {
            //SqlConnection conn = new SqlConnection(connect);
            //string updateString = @$"UPDATE Students SET StudentName = {name}, StudentSurname = {surname}, StudentDOB = {DOB}, StudentGender = {gender}, StudentPhone = {phonenumber}, StudentModules = {module} WHERE StudentNumber = {studennumber}";
            //SqlCommand command = new SqlCommand(updateString);
            //command.Connection = conn;
            //conn.Open();
            //command.ExecuteNonQuery();
            //conn.Close();

            using (SqlConnection conn = new SqlConnection(connect)) 
            {
                SqlCommand cmd = new SqlCommand("spUpdatreStudent", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StudentNumber", studennumber);
                cmd.Parameters.AddWithValue("@StudentName", name);
                cmd.Parameters.AddWithValue("@StudentSurname", surname);
                cmd.Parameters.AddWithValue("@StudentDOB", DOB);
                cmd.Parameters.AddWithValue("@StudentGender", gender);
                cmd.Parameters.AddWithValue("@StudentPhone", phonenumber);
                cmd.Parameters.AddWithValue("@StudentModules", module);

                conn.Open();
                cmd.ExecuteNonQuery();


            }
        }

        public void InsertStudent(string name, string surname, string gender, string DOB, string phonenumber, string module)
        {

            using(SqlConnection conn = new SqlConnection(connect))
            {
                SqlCommand cmd = new SqlCommand("spAddStudent", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StudentName", name);
                cmd.Parameters.AddWithValue("@Surname", surname);
                cmd.Parameters.AddWithValue("@StudentDOB", DOB);
                cmd.Parameters.AddWithValue("@StudentGender", gender);
                cmd.Parameters.AddWithValue("@StudentPhone", phonenumber);
                cmd.Parameters.AddWithValue("@StudentModules", module);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
