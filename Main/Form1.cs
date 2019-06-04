using System;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.IO;
using System.Threading;
using System.Web.Hosting;
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

        private void conn()
        {
            try
            {
                string ldap = "LDAP://" + domain_host_txt.Text.Trim();
                string user = user_txt.Text.Trim();
                string pwd = passwd_txt.Text.Trim();
                string ou = ou_txt.Text.Trim();
                AdHerlp.GetDirectoryEntry(ldap, user, pwd);

                if (save_chk.Checked)
                {
                    EditXml(filePath, "ip", domain_host_txt.Text.Trim());
                    EditXml(filePath, "username", user);
                    EditXml(filePath, "passwd", pwd);
                    EditXml(filePath, "ou", ou);
                }
                InsertLog("连接成功！", AddLog.Status.None);
                
            }
            catch (Exception ex)
            {

                InsertLog(ex.ToString(), AddLog.Status.Fail);
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
                    MessageBox.Show("请配置连接","提示");
                    return;
                    //conn_btn_Click(null,null);

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
                    string newUser = user + i;
                    string userPath = AdHerlp.GetUserDNByName(newUser);
                    if (!string.IsNullOrEmpty(userPath) )
                    {
                        userPath = AdHerlp.FixUserPath(userPath);
                        AdHerlp.DeleteUser(newUser);
                        InsertLog("删除用户：" + userPath , AddLog.Status.None);
                    } 
                    
                    AdHerlp.CreateNewUser(newUser, deafultPwd, ou);
                    InsertLog("创建用户 [" + newUser + "] 创建成功！", AddLog.Status.Success);
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
                        string value = item.Attributes["value"].Value.Trim();
                        if (value =="true")
                        {
                            save_chk.Checked = true;
                        }
                    }

                    if (character == "ip")
                    {
                        string value = item.Attributes["value"].Value.Trim();
                        domain_host_txt.Text = value;
                    }
                    if (character == "username")
                    {
                        string value = item.Attributes["value"].Value.Trim();
                        user_txt.Text = value;
                    }
                    if (character == "passwd")
                    {
                        string value = item.Attributes["value"].Value.Trim();
                        passwd_txt.Text = value;
                    }
                    if (character == "ou")
                    {
                        string value = item.Attributes["value"].Value.Trim();
                        ou_txt.Text = value;
                    }
                }
            }
            else
            {
                //MessageBox.Show("没有找到 config.xml 文件!");
                FileStream fs1 = new FileStream(filePath, FileMode.Create, FileAccess.Write);//搜索创建写入文件 
                StreamWriter sw = new StreamWriter(fs1);

                sw.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
                sw.WriteLine("<Config>");
                sw.WriteLine("  <Character name=\"Checked1\" value=\"True\" />");
                sw.WriteLine("  <Character name=\"ip\" value=\"192.168.88.10\" />");
                sw.WriteLine("  <Character name=\"username\" value=\"administrator\" />");
                sw.WriteLine("  <Character name=\"passwd\" value=\"Helloworld123\" />");
                sw.WriteLine("  <Character name=\"ou\" value=\"OU\" />");
                sw.Write("</Config>");

                sw.Close();
                fs1.Close();
                MessageBox.Show("配置文件已生成，请重新运行程序！", "提示");
                System.Environment.Exit(0); 
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
        private string InsertLog(string str, Enum status )// AddLog.Status.Fail
        {
            AddLog log = new AddLog(log_richtxt, status, str);
            this.Text = log.log;
            return log.log;
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


        private void hideLog_btn_Click(object sender, EventArgs e)
        {
            if (hideLog_btn.Text == ">>>>>")
            {
                hideLog_btn.Text = "<<<<<";
                this.Width = this.Width-445;
            }
            else
            {
                hideLog_btn.Text = ">>>>>";
                this.Width = this.Width + 445;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //AdHerlp.GetUserDNByName("test1");
            //AdHerlp.DeleteUser("test1");
        /*    PrincipalContext ctx = new PrincipalContext(ContextType.Domain, "192.168.88.10", "Administrators","!qaz2wsx");

            // Create the GroupPrincipal object and set the diplay name property. 
            GroupPrincipal g = new GroupPrincipal(ctx);
            g.DisplayName = "Administrators";

            // Create a PrincipalSearcher object.     
            PrincipalSearcher ps = new PrincipalSearcher(g);

            // Searches for all groups named "Administrators".
            PrincipalSearchResult<Principal> results = ps.FindAll();*/
            PrincipalContext context = new PrincipalContext(ContextType.Domain, "192.168.88.10", @"administrator", @"!qaz2wsx");
            UserPrincipal user = new UserPrincipal(context);
            user.SetPassword("163.com");
            user.DisplayName = "heheyhc66";
            user.Name = "heheyhc66";
            user.UserCannotChangePassword = true;
            user.Save();
            //PrincipalContext ctx = new PrincipalContext(ContextType.Domain, "192.168.88.10", @"test\administrator", "!qaz2wsx");

        }
    }
}
