using System;
using System.DirectoryServices;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using LDAP;

namespace Main
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false; 
        }
        
        string directoryStr = System.Environment.CurrentDirectory;
        string filePath = Environment.CurrentDirectory + "\\config.xml";
        
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

        private void conn()
        {
            try
            {
                string ldap = "LDAP://" + domain_host_txt.Text.Trim();
                string user = user_txt.Text.Trim();
                string pwd = passwd_txt.Text.Trim();
                AdHerlp.GetDirectoryEntry(ldap, user, pwd);

                if (save_chk.Checked)
                {
                    EditXml(filePath, "ip", domain_host_txt.Text.Trim());
                    EditXml(filePath, "username", user);
                    EditXml(filePath, "passwd", pwd);
                }
                MessageBox.Show("连接成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

        private void conn_btn_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(new ThreadStart(conn));
            t.IsBackground = true;
            t.Start();
        }

        private void createUser_btn_Click(object sender, EventArgs e)
        {
            log_richtxt.Clear();
            try
            {
                //AddLog.Status.Fail
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

                bool ouExists = AdHerlp.OuExists(ou);
                if (ouExists)
                {
                    InsertLog("组织单元已存在，跳过创建。", AddLog.Status.None);
                    
                }
                else
                {
                    AdHerlp.CreateOu(ou);
                    InsertLog("创建 "+ ou+ "组织单元。", AddLog.Status.None);
                }

                InsertLog("开始创建用户...", AddLog.Status.None);
                for (int i = start; i <= end; i++)
                {
                    AdHerlp.CreateNewUser(user + i, deafultPwd, ou);
                    InsertLog("创建用户 [" + user + i + "] 创建成功！", AddLog.Status.Success);
                }
                InsertLog("所有用户创建完毕!!!!", AddLog.Status.None);
            }
            catch (Exception ex)
            {
                InsertLog(ex.ToString(), AddLog.Status.Fail);
            }
        }

        private void ReadConfig()
        {
            
            if (File.Exists(filePath))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filePath);
                XmlNodeList characterList = doc.SelectNodes("/Config/Character");
                foreach (XmlNode item in characterList)
                {

                    string character = item.Attributes["name"].Value;
                    if (!string.IsNullOrEmpty(character))
                    {
                        character = character.ToLower().Trim();
                    }
                    if (character == "checked")
                    {
                        string value = item.Attributes["value"].Value.ToLower().Trim();
                        if (value =="true")
                        {
                            save_chk.Checked = true;
                        }
                    }

                    if (character == "ip")
                    {
                        string value = item.Attributes["value"].Value.ToLower().Trim();
                        domain_host_txt.Text = value;
                    }
                    if (character == "username")
                    {
                        string value = item.Attributes["value"].Value.ToLower().Trim();
                        user_txt.Text = value;
                    }
                    if (character == "passwd")
                    {
                        string value = item.Attributes["value"].Value.ToLower().Trim();
                        passwd_txt.Text = value;
                    }
                }
            }
            else
            {
                MessageBox.Show("没有找到 config.xml 文件!");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = SYS_INFO.form_title;
            ReadConfig();
        }

        /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="status">状态 AddLog.Status</param>
        /// <param name="str">内容</param>
        private void InsertLog(string str, Enum status )// AddLog.Status.Fail
        {
            new AddLog(log_richtxt, status, str);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            AdHerlp.getAllPeople();
            //AdHerlp.GetAll();

            //DirectoryEntry de = new DirectoryEntry("LDAP://192.168.16.4", "administrator", "!qaz2wsx");//AuthenticationTypes.Secure
            //DirectoryEntry user = de.Children.Find("objectClass=yhc", "user");
            //user.DeleteTree();
            //de.Children.Add("CN=user1", "user");

        }

        private void EditXml(string filePath,string name, string value)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);
            XmlNodeList characterList = doc.SelectNodes("/Config/Character");
            foreach (XmlNode item in characterList)
            {
                if (item.Attributes["name"].Value.ToLower().Trim() == name)
                {
                    item.Attributes["value"].Value = value;
                    break;
                }
            }
            doc.Save(filePath);
        }
    }
}
