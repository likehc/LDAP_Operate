using System;
using System.DirectoryServices;
using System.Windows.Forms;
using LDAP;

namespace Main
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdHerlp.GetDirectoryEntry("LDAP://192.168.88.10", "administrator", "!qaz2wsx");

            AdHerlp.DeleteUser("yhc1");
            //bool b = AdHerlp.UserExists("yhc12345");
            bool b1 = AdHerlp.OuExists("hello1");
            AdHerlp.CreateOu("world");
            //object user = AdHerlp.GetUserDNByName("yhc12345");

            //AdHerlp.AddUserToGroup("yhc123456", "wwww");
            AdHerlp.CreateNewUser("yhc1", "163.com", "test");
            //AdHerlp.change("Administrator", "!qaz2wsx", "heheyhc1234..");
            //AdHerlp.AddGroup("wwww");
            //AdHerlp.GetAll();
            AdHerlp.getAllPeople();
        }

        private void conn_btn_Click(object sender, EventArgs e)
        {
            try
            {
                string ldap = "LDAP://"+domain_host_txt.Text.Trim();
                string user = user_txt.Text.Trim();
                string pwd = passwd_txt.Text.Trim();
                //AdHerlp.GetDirectoryEntry("LDAP://192.168.88.10", "administrator", "!qaz2wsx");
                AdHerlp.GetDirectoryEntry(ldap, user, pwd);
                MessageBox.Show("连接成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            


        }

        private void createUser_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(AdHerlp.domainName))
            {
                MessageBox.Show("请配置连接");
                return;
            }
            string ou = ou_txt.Text.Trim();
            string user = addUser_txt.Text.Trim();
            int start = int.Parse(addStart_txt.Text.Trim());
            int end = int.Parse(addEnd_txt.Text.Trim());
            string deafultPwd = deafulePass_txt.Text.Trim();
            
            

            AdHerlp.CreateOu(ou);
            for (int i = start; i < end; i++)
            {
                AdHerlp.CreateNewUser(user + i, deafultPwd, ou);
            }

        }
    }
}
