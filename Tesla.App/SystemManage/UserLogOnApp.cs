using Tesla.Utils;
using Tesla.Model;

namespace Tesla.App
{
    public class UserLogOnApp
    {
        /// <summary>
        /// 根据主键获取实体
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public SysUserLogOn GetForm(string keyValue)
        {
            string sql = "select * from sys_userlogon where F_Id=@Id";
            return DBHelper.GetOne<SysUserLogOn>(sql, new { Id = keyValue });
        }

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="model"></param>
        public void UpdateForm(SysUserLogOn model)
        {
            
        }

        /// <summary>
        /// 重置密码
        /// </summary>
        /// <param name="userPassword"></param>
        /// <param name="keyValue"></param>
        public void RevisePassword(string userPassword, string keyValue)
        {
            SysUserLogOn userLogOn = new SysUserLogOn();
            userLogOn.F_Id = keyValue;
            userLogOn.F_UserSecretkey = Md5Helper.Md5(PublicFunction.CreateNo(), 16).ToLower();
            userLogOn.F_UserPassword = Md5Helper.Md5(DESHelper.Encrypt(Md5Helper.Md5(userPassword, 32).ToLower(), userLogOn.F_UserSecretkey).ToLower(), 32).ToLower();

            string sql = "update sys_userlogon set F_UserSecretkey=@F_UserSecretkey, "
                       + "F_UserPassword=@F_UserPassword where F_Id=@F_Id";
            DBHelper.Execute(sql, userLogOn);
        }
    }
}
