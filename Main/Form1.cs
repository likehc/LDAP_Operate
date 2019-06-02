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
            //bool b = AdHerlp.UserExists("yhchehe");

            //object user = AdHerlp.GetUserDNByName("yhchehe");

            //AdHerlp.AddGroupMember("join", "yhc");
            AdHerlp.CreateNewUser("yhc1234", "yhc1234", "yhc1234", "463259624@qq.com", "join");
            //AdHerlp.change("Administrator", "!qaz2wsx", "heheyhc1234..");

        }
    }
}
