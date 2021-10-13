using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Milestone2__Group1.BusinessLogic_Layer
{
    class FileHandler
    {
        //Define methods that will read and write to .txt file
        private string users = AppDomain.CurrentDomain.BaseDirectory + "DataCapturers.txt";

        public void checkFile()
        {
            if (!File.Exists(users))
            {
                StreamWriter file = File.CreateText(users);
                file.Close();
            }
        }
        //UserFile Validation
        public List<string> UserList()
        {
            using (TextReader file = File.OpenText(users))
            {
                return file.ReadToEnd().Split('\n').ToList();
            }
        }
        public bool login(string user, string pass)
        {
            checkFile();
            List<string> Users = UserList();
            string logins = user+','+pass+'\n';

            using (FileStream file = File.Open(users, FileMode.Open))
            {
                if (Users.Contains(logins))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        //Writing New Users to .txt file
        public string Register(string user, string pass)
        {
            checkFile();
            using (StreamWriter file = File.AppendText(users))
            {
                file.WriteLine(user+','+pass);
            }
            return "True";
        }
    }
}
