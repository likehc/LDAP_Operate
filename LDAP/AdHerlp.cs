using System;
using System.CodeDom;
using System.ComponentModel;
using System.DirectoryServices;
using System.Text;

namespace LDAP
{
    public static class AdHerlp
    {
        private static DirectoryEntry de;
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
            deSearch.Filter = "(&(objectClass=*) (cn=" + adUser + "))";
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
      
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="adUser">用户名</param>
        /// <returns></returns>
        public static object GetUserDNByName(string adUser) 
        {
            DirectorySearcher userSearch = new DirectorySearcher();
            userSearch.SearchRoot = de;
            userSearch.Filter = "(SAMAccountName=" + adUser + ")";
            SearchResult user = userSearch.FindOne();
            if (user == null)
            {
                throw new Exception("请确认域用户是否正确");
            }
            return user.Properties["distinguishedname"][0];
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
                group = result.GetDirectoryEntry();
            }
            else {
                throw new Exception("请确认AD组列表是否正确");
            }
            return group;
        }


        /// <summary>
        /// 把用户加入到组内
        /// </summary>
        /// <param name="adGroup">组名</param>
        /// <param name="adUser">用户名</param>
        public static void AddUserToGroup(string adGroup, string adUser)
        {
            DirectoryEntry group = getGroupByName(adGroup);
            group.Username = de.Username;
            group.Properties["member"].Add(GetUserDNByName(adUser));
            group.CommitChanges();
        }

        public static void SetProperty(DirectoryEntry de, string PropertyName, string PropertyValue)
        {
            if (PropertyValue != null)
            {
                if (de.Properties.Contains(PropertyName))
                {
                    de.Properties[PropertyName][0] = PropertyValue;
                }
                else
                {
                    de.Properties[PropertyName].Add(PropertyValue);
                }
            }
        }
       
        public static void CreateNewUser(string employeeID, string name, string login, string email, string group)
        {
            DirectoryEntry ent = de;
            DirectoryEntry ou = ent.Children.Find("OU=test");
            DirectoryEntry usr = ou.Children.Add("CN=New User", "user");
            usr.CommitChanges();
            //string passwordProp = "new object []{" + "\"" + "163.com".ToLower() + "\"" + "}";
            usr.Properties["userAccountControl"].Value = 0x00010000; //0x00010000 = ADS_UF_DONT_EXPIRE_PASSWD

            usr.Invoke("SetPassword", new object[] { "12345Abcd#" });
            usr.Properties["samAccountName"].Value = "newuser";
            usr.CommitChanges();
            //DirectoryEntry ent = de;
            //DirectoryEntry ou = ent.Children.Find("OU=test");
            //DirectoryEntry userEntry = ou.Children.Add("BobUser", "User");
            //userEntry.Invoke("Put", new object[] { "Description", "User Description" });
            //userEntry.CommitChanges();
            //userEntry.Invoke("SetPassword", new object[] { "12345Abcd#" });
            //userEntry.CommitChanges();







            
     /*       DirectoryEntries users = de.Children;
            DirectoryEntry newuser = users.Add("CN=" + login, "user");
 
            /// 2. Set properties
            SetProperty(newuser, "employeeID", employeeID);
            SetProperty(newuser, "givenname", name);
            SetProperty(newuser, "SAMAccountName", login);
            SetProperty(newuser, "userPrincipalName", login);
            SetProperty(newuser, "mail", email);
            SetProperty(newuser, "userAccountControl", "0x00010000");  //永不过期
            SetProperty(newuser, "Description", "Create User By HrESS System");
 
            newuser.CommitChanges();

            // newuser.AuthenticationType = AuthenticationTypes.Secure;
            // object[] password = new object[] { "heheyhc1234.."};
            //object ret = newuser.Invoke("SetPassword", password);
            //newuser.CommitChanges();

            newuser.Close();*/
           
        }
        private static void EnableAccount(DirectoryEntry de)
        {
           

            ////UF_DONT_EXPIRE_PASSWD 0x10000
            //int exp = (int)de.Properties["userAccountControl"].Value;
            //de.Properties["userAccountControl"].Value = exp | 0x0001;
            //de.CommitChanges();
            ////UF_ACCOUNTDISABLE 0x0002
            //int val = (int)de.Properties["userAccountControl"].Value;
            //de.Properties["userAccountControl"].Value = val & ~0x0002;
            //de.CommitChanges();
        }

        public static void change(string adUser, string oldPwd, string newPwd)
        {
            DirectoryEntry ent = de;
            DirectoryEntry ou = ent.Children.Find("OU=test");


            DirectoryEntry user = ou.Children.Find(adUser);
            object[] password = new object[] { oldPwd, newPwd };
            object ret = user.Invoke("ChangePassword", password);

            //DirectoryEntry ent = de;
            //DirectoryEntry user = ent.Children.Find("OU=Users");
            ////DirectoryEntry user = ent.Children.Find(adUser, "OU=Users");
            //object[] password = new object[] { oldPwd, newPwd };
            //object ret = user.Invoke("ChangePassword", password);
            user.CommitChanges();
            user.Close();
        }
    

        /// <summary>
        /// 禁用一个帐号
        /// </summary>
        /// <param name="EmployeeID"></param>
        //public static void DisableAccount(string EmployeeID)
        //{
        //    DirectorySearcher ds = new DirectorySearcher(de);
        //    ds.Filter = "(&(objectCategory=Person)(objectClass=user)(employeeID=" + EmployeeID + "))";
        //    ds.SearchScope = SearchScope.Subtree;
        //    SearchResult results = ds.FindOne();

        //    if (results != null)
        //    {
        //        DirectoryEntry dey = de;
        //        int val = (int)dey.Properties["userAccountControl"].Value;
        //        dey.Properties["userAccountControl"].Value = val | 0x0002;
        //        dey.Properties["msExchHideFromAddressLists"].Value = "TRUE";
        //        dey.CommitChanges();
        //        dey.Close();
        //    }
        //}  

        /// <summary>
        /// 时间格式化
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        private static string ToADDateString(DateTime date)
        {
            string year = date.Year.ToString();
            int month = date.Month;
            int day = date.Day;
 
            StringBuilder sb = new StringBuilder();
            sb.Append(year);
            if (month < 10)
            {
                sb.Append("0");
            }
            sb.Append(month.ToString());
            if (day < 10)
            {
                sb.Append("0");
            }
            sb.Append(day.ToString());
            sb.Append("000000.0Z");
            return sb.ToString();
        }

    }
}