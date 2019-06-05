using System;
using System.Data;
using System.DirectoryServices;
using System.Text;
using System.Web.Hosting;

namespace LDAP
{
    public static class AdHerlp
    {
        private static DirectoryEntry de;
        public static string domainName= String.Empty;

        private static void GetDomainName()
        {
            string DomainNameStr = de.Properties["distinguishedName"].Value.ToString();
            string[] DomainNameArr = DomainNameStr.Split(',');
            if (DomainNameArr.Length >=2)
            {
                domainName = String.Format("@{0}.{1}", DomainNameArr[0].ToLower().Replace("dc=", ""), DomainNameArr[1].ToLower().Replace("dc=", ""));
            }
            
        }
        /// <summary>
        /// 初始化连接
        /// </summary>
        /// <param name="adPath">域路径</param>
        /// <param name="adUser">用户名</param>
        /// <param name="adPwd">密码</param>
        /// <returns></returns>
        public static void GetDirectoryEntry(string adPath, string adUser, string adPwd)
        {
            de = new DirectoryEntry(adPath,adUser,adPwd);
            GetDomainName();

        }

        /// <summary>
        /// 判断用户是否存在
        /// </summary>
        /// <param name="adUser">用户名</param>
        /// <returns></returns>
        public static bool UserExists(string adUser)
        {
            DirectorySearcher deSearch = new DirectorySearcher();
            deSearch.SearchRoot = de;
            //deSearch.Filter = "(&(objectClass=*) (cn=" + adUser + "))";
            deSearch.Filter = "(SAMAccountName=" + adUser + ")";
            SearchResultCollection results = deSearch.FindAll();
            if (results.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static void SetPassword(DirectoryEntry adUser ,string adPwd)
        {
            adUser.AuthenticationType = AuthenticationTypes.Secure;
            object[] password = new object[] { adPwd };
            object ret = adUser.Invoke("SetPassword", password);
            adUser.CommitChanges();
            adUser.Close();
 
        }
      
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="adUser">用户名</param>
        /// <returns>空时为null，否则为object</returns>
        public static string GetUserDNByName(string adUser) 
        {
            DirectorySearcher searcher = new DirectorySearcher(de);
            searcher.Filter = String.Format("(&(objectClass=user)(samAccountName={0}))", adUser);
            SearchResult user = searcher.FindOne();
            if (user == null)
            {
                return null;
            }
            return user.Properties["distinguishedname"][0].ToString();
        }

      

        public static DirectoryEntry getGroupByName(string adGroup)
        {
            DirectorySearcher search = new DirectorySearcher();
            search.SearchRoot = de;
            search.Filter = "(&(cn=" + adGroup + ")(objectClass=group))";
            search.PropertiesToLoad.Add("objectClass");
            SearchResult result = search.FindOne();
            DirectoryEntry group;
            if (result != null)
            {
                @group = result.GetDirectoryEntry();
            }
            else {
                throw new Exception("请确认AD组列表是否正确");
            }
            return @group;
        }


        /// <summary>
        /// 把用户加入到组内
        /// </summary>
        /// <param name="adUser">用户名</param>
        /// /// <param name="adGroup">组名</param>
        public static void AddUserToGroup(string adUser,string adGroup)
        {
            DirectoryEntry group = getGroupByName(adGroup);
            @group.Username = de.Username;
            @group.Properties["member"].Add(GetUserDNByName(adUser));
            @group.CommitChanges();
            @group.Close();
        }

        public static bool CreateNewUser(string adUser, string adPwd, string adOu = "", bool noExpire =false)
        {
            try
            {
                DirectoryEntry usr;
                if (String.IsNullOrEmpty(adOu))
                {
                    usr = de.Children.Add("CN=" + adUser, "user");
                }
                else
                {
                    DirectoryEntry ou = de.Children.Find("OU=" + adOu);
                    usr = ou.Children.Add("CN=" + adUser, "user");
                }

                usr.Properties["sn"].Value = adUser;  //姓(L) 
                usr.Properties["displayName"].Value = adUser; //显示名称(S)
                usr.Properties["userPrincipalName"].Value = adUser + domainName;   //用户登录名(U)  
                usr.Properties["sAMAccountName"].Value = adUser;    //用户登录名2000以前版本

                //usr.Properties["givenName"].Value = "New User";
                //usr.Properties["initials"].Value = "Ms";   //英文缩写
                //usr.Properties["sn"].Value = "Name";
                //usr.Properties["displayName"].Value = "New User Name";
                //usr.Properties["description"].Value = "Vice President-Operation";
                //usr.Properties["physicalDeliveryOfficeName"].Value = "40/5802";
                //usr.Properties["telephoneNumber"].Value = "(425)222-9999";
                //usr.Properties["mail"].Value = "newuser@fabrikam.com";
                //usr.Properties["wWWHomePage"].Value = "http://www.fabrikam.com/newuser";
                //usr.Properties["otherTelephone"].AddRange(new
                //string[] { "(425)111-2222", "(206)222-5263" });
                //usr.Properties["url"].AddRange(new string[] { "http://newuser.fabrikam.com", "http://www.fabrikam.com/officers" });

                usr.CommitChanges();
                usr.Invoke("SetPassword", new object[] { adPwd });
                if (noExpire)
                {
                    usr.Properties["userAccountControl"].Value = 0x00010000;//永不过期  //512;//0x200; //0x200; //ADS_UF_NORMAL_ACCOUNT //10040
                }
                
                usr.CommitChanges();
                usr.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="adUser">用户名</param>
        /// <returns>成功删除返回true,否则为false</returns>
        public static bool DeleteUser(string adUser)
        {
            bool result = false;
            DirectorySearcher search = new DirectorySearcher(de);
            search.Filter = "(&(objectClass=user))";
            search.SearchScope = SearchScope.Subtree;
            using (HostingEnvironment.Impersonate())
            {
                SearchResultCollection SearchResults = search.FindAll();
                if (SearchResults.Count > 0)
                {
                    foreach (SearchResult sr in SearchResults)
                    {
                        DirectoryEntry GroupEntry = sr.GetDirectoryEntry();
                        if (GroupEntry.Properties.Contains("userPrincipalName"))
                        {
                            if (GroupEntry.Properties["displayName"][0].ToString() == adUser)
                            {
                                GroupEntry.DeleteTree();
                                result = true;
                                return result;
                            }
                        }
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 修改用户路径
        /// </summary>
        /// <param name="cnPath">用户的LDAP路径</param>
        /// <returns></returns>
        public static string FixUserPath(string cnPath)
        {
            StringBuilder sb = new StringBuilder();
            string user =String.Empty;
            string[] cnArr = cnPath.Split(',');
            for (var i = cnArr.Length - 1; i >= 0; i--)
            {
                string[] temp = cnArr[i].Split('=');
                if (temp[0].ToLower() == "cn")
                {
                    user = temp[1];
                }
                if (temp[0].ToLower() == "ou")
                {
                    sb.Append(temp[1] + "/");
                }
            }
            string result = domainName.Replace("@", "")+"/"+ sb.ToString()+user;
            return result;
        }

        private static void EnableAccount(DirectoryEntry de)
        {
           
        }

        public static void AddGroup(string adGroup)
        {
            DirectoryEntry group = de.Children.Add("CN=" + adGroup, "group");
            @group.Properties["samAccountName"].Value = adGroup;
            @group.CommitChanges();
            @group.Close();
        }

       
        /// <summary>
        /// 判断OU是否存在
        /// </summary>
        /// <param name="ouName">OU名称</param>
        /// <returns></returns>
        public static bool OuExists(string ouName)
        {
            bool result = false;
            DirectorySearcher subOUsearcher = new DirectorySearcher(de);
            subOUsearcher.SearchScope = SearchScope.OneLevel; // don't recurse down
            subOUsearcher.Filter = "(objectClass=organizationalUnit)";

            foreach (SearchResult subOU in subOUsearcher.FindAll())
            {
                string ouNameTemp = subOU.Properties["name"][0].ToString();
                if (ouNameTemp.ToLower() == ouName.ToLower())
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        /// <summary>
        /// 创建组织单元
        /// </summary>
        /// <param name="ouName">组织单元名称</param>
        public static void CreateOu(string ouName)
        {
            bool ouExists = OuExists(ouName);
            if (!ouExists)
            {
                DirectoryEntry ou = de.Children.Add("OU=" + ouName, "organizationalUnit");
                ou.CommitChanges();
                ou.Close();
            }
        }

        public static void GetAll()
        {
            DirectorySearcher subOUsearcher = new DirectorySearcher(de);
            subOUsearcher.SearchScope = SearchScope.OneLevel; // don't recurse down
            subOUsearcher.Filter = "(objectClass=organizationalUnit)";

            foreach (SearchResult subOU in subOUsearcher.FindAll())
            {
                // stick those Sub OU's into a list and then handle them
                string ouName = subOU.Properties["name"][0].ToString();
                var ou = subOU;
                DirectorySearcher userSearcher = new DirectorySearcher(de);
                userSearcher.SearchScope = SearchScope.OneLevel; // don't recurse down
                userSearcher.Filter = "(objectClass=user)";

                foreach (SearchResult user in userSearcher.FindAll())
                {
                    var s = user;
                    // stick those users into a list being built up
                }
            }

        }


        public static DataTable getAllPeople()
        {
            DataTable dt = new DataTable();
            DataColumn dc_accountName = new DataColumn("SN", typeof(string));
            DataColumn dc_mail = new DataColumn("displayName", typeof(string));
            DataColumn dc_fullName = new DataColumn("userPrincipalName", typeof(string));
            dt.Columns.Add(dc_fullName);
            dt.Columns.Add(dc_accountName);
            dt.Columns.Add(dc_mail);
            DirectorySearcher search = new DirectorySearcher(de);
            search.Filter = "(&(objectClass=user))";
            search.SearchScope = SearchScope.Subtree;
            //模拟用户登录(发布的时候不添加要报错)
            using (HostingEnvironment.Impersonate())
            {
                SearchResultCollection SearchResults = search.FindAll();
                if (SearchResults.Count > 0)
                {
                    foreach (SearchResult sr in SearchResults)
                    {
                        DirectoryEntry GroupEntry = sr.GetDirectoryEntry();
                        string accountName = String.Empty;
                        string fullName = String.Empty;
                        string mail = String.Empty;
                        DataRow dr = dt.NewRow();
                        //先获取邮件属性，如果邮件不是空，说明是要取的部门
                        if (GroupEntry.Properties.Contains("userPrincipalName"))
                        {
                            //usr.Properties["sn"].Value = adUser;  //姓(L) 
                            //usr.Properties["displayName"].Value = adUser; //显示名称(S)
                            //usr.Properties["userPrincipalName"].Value = adUser;   //用户登录名(U)  
                            //usr.Properties["sAMAccountName"].Value = adUser;    //用户登

                            mail = GroupEntry.Properties["userPrincipalName"][0].ToString();
                            dr["userPrincipalName"] = mail;
                            if (GroupEntry.Properties.Contains("displayName"))
                            {
                                accountName = GroupEntry.Properties["displayName"][0].ToString();
                                dr["displayName"] = accountName;
                            }
                            if (GroupEntry.Properties.Contains("userPrincipalName"))
                            {
                                fullName = GroupEntry.Properties["userPrincipalName"][0].ToString();
                                dr["userPrincipalName"] = fullName;
                            }
                            if (GroupEntry.Properties["displayName"][0].ToString() =="yhc")
                            {
                                GroupEntry.DeleteTree();
                            }
                            
                            dt.Rows.Add(dr);
                        }
                    }
                }
            }
            return dt;
        }
       
    }
}