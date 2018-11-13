using Tesla.Utils;
using Tesla.Model;
using System;
using System.Collections.Generic;

namespace Tesla.App
{
    /// <summary>
    /// 用户App
    /// </summary>
    public class UserApp
    {
        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="pagerInfo"></param>
        /// <returns></returns>
        public IList<SysUser> GetList(PagerInfo pagerInfo)
        {
            return DBHelper.GetPageList<SysUser>(pagerInfo);
        }

        /// <summary>
        /// 根据主键获取实体
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public SysUser GetForm(string keyValue)
        {
            string sql = "select * from sys_user where F_Id=@Id";
            return DBHelper.GetOne<SysUser>(sql, new { Id = keyValue });
        }

        /// <summary>
        /// 删除指定实体
        /// </summary>
        /// <param name="keyValue"></param>
        public void DeleteForm(string keyValue)
        {
            //删除用户
            string sql = "delete from sys_user where F_Id=@Id;";

            //删除用户登录信息
            sql += "delete from sys_userlogon where F_UserId=@Id;";
            DBHelper.ExcuteTransaction(sql, new { Id = keyValue });
        }

        /// <summary>
        /// 更新/新增实体
        /// </summary>
        /// <param name="user"></param>
        /// <param name="userLogOn"></param>
        /// <param name="keyValue"></param>
        public void SubmitForm(SysUser user, SysUserLogOn userLogOn, string keyValue)
        {
            bool isAdd = string.IsNullOrEmpty(keyValue);
            string sql;
            if (!isAdd)
            {
                sql = "update sys_user set F_Account=@F_Account, F_RealName=@F_RealName, F_NickName=@F_NickName, "
                    + "F_HeadIcon=@F_HeadIcon, F_Gender=@F_Gender, F_Birthday=@F_Birthday, "
                    + "F_MobilePhone=@F_MobilePhone, F_Email=@F_Email, F_WeChat=@F_WeChat, "
                    + "F_ManagerId=@F_ManagerId, F_SecurityLevel=@F_SecurityLevel, F_Signature=@F_Signature, "
                    + "F_OrganizeId=@F_OrganizeId, F_DepartmentId=@F_DepartmentId, F_RoleId=@F_RoleId, "
                    + "F_DutyId=@F_DutyId, F_IsAdministrator=@F_IsAdministrator, F_SortCode=@F_SortCode, "
                    + "F_EnabledMark=@F_EnabledMark, F_Description=@F_Description, "
                    + "F_LastModifyTime=@F_LastModifyTime, F_LastModifyUserId=@F_LastModifyUserId "
                    + "where F_Id=@F_Id";
                user.Modify(keyValue);
                DBHelper.Execute(sql, user);
            }
            else
            {
                user.Create();

                userLogOn.F_Id = user.F_Id;
                userLogOn.F_UserId = user.F_Id;
                userLogOn.F_UserSecretkey = Md5Helper.Md5(PublicFunction.CreateNo(), 16).ToLower();
                userLogOn.F_UserPassword = Md5Helper.Md5(DESHelper.Encrypt(Md5Helper.Md5(userLogOn.F_UserPassword, 32).ToLower(), userLogOn.F_UserSecretkey).ToLower(), 32).ToLower();

                sql = "insert into sys_user (F_Id, F_Account, F_RealName, F_NickName, F_HeadIcon, "
                    + "F_Gender, F_Birthday, F_MobilePhone, F_Email, F_WeChat, F_ManagerId, F_SecurityLevel, "
                    + "F_Signature, F_OrganizeId, F_DepartmentId, F_RoleId, F_DutyId, F_IsAdministrator, "
                    + "F_SortCode, F_EnabledMark, F_Description, F_CreatorTime, F_CreatorUserId) values (@F_Id, @F_Account, @F_RealName, @F_NickName, @F_HeadIcon, "
                    + "@F_Gender, @F_Birthday, @F_MobilePhone, @F_Email, @F_WeChat, @F_ManagerId, @F_SecurityLevel, "
                    + "@F_Signature, @F_OrganizeId, @F_DepartmentId, @F_RoleId, @F_DutyId, @F_IsAdministrator, "
                    + "@F_SortCode, @F_EnabledMark, @F_Description, @F_CreatorTime, @F_CreatorUserId)";
                DBHelper.Execute(sql, user);

                sql = "insert into sys_userlogon (F_Id, F_UserId, F_UserPassword, F_UserSecretkey) "
                    + "values (@F_Id, @F_UserId, @F_UserPassword, @F_UserSecretkey)";
                DBHelper.Execute(sql, userLogOn);
            }
        }

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="model"></param>
        public void UpdateForm(SysUser model)
        {
            string sql = "update sys_user set F_Account=@F_Account, F_RealName=@F_RealName, F_NickName=@F_NickName, "
                    + "F_HeadIcon=@F_HeadIcon, F_Gender=@F_Gender, F_Birthday=@F_Birthday, "
                    + "F_MobilePhone=@F_MobilePhone, F_Email=@F_Email, F_WeChat=@F_WeChat, "
                    + "F_ManagerId=@F_ManagerId, F_SecurityLevel=@F_SecurityLevel, F_Signature@F_Signature, "
                    + "F_OrganizeId=@F_OrganizeId, F_DepartmentId=@F_DepartmentId, F_RoleId=@F_RoleId, "
                    + "F_DutyId=@F_DutyId, F_IsAdministrator=@F_IsAdministrator, F_SortCode=@F_SortCode, "
                    + "F_EnabledMark=@F_EnabledMark, F_Description=@F_Description, "
                    + "F_LastModifyTime=@F_LastModifyTime, F_LastModifyUserId=@F_LastModifyUserId "
                    + "where F_Id=@F_Id";
            model.Modify(model.F_Id);
            DBHelper.Execute(sql, model);
        }

        /// <summary>
        /// 设置账户的状态
        /// </summary>
        /// <param name="user"></param>
        public void SetAccount(SysUser user)
        {
            string sql = "update sys_user set F_EnabledMark=@F_EnabledMark, "
                       + "F_LastModifyTime=@F_LastModifyTime, F_LastModifyUserId=@F_LastModifyUserId "
                       + "where F_Id=@F_Id";
            user.Modify(user.F_Id);
            DBHelper.Execute(sql, user);
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public SysUser CheckLogin(string username, string password)
        {
            string sql = "select * from sys_user where F_Account=@UserName";
            SysUser user = DBHelper.GetOne<SysUser>(sql, new { UserName = username });
            if (user != null)
            {
                if (user.F_EnabledMark)
                {
                    sql = "select * from sys_userlogon where F_Id=@Id";
                    SysUserLogOn userLogOn = DBHelper.GetOne<SysUserLogOn>(sql, new { Id = user.F_Id });
                    if (userLogOn != null)
                    {
                        string dbPassword = Md5Helper.Md5(DESHelper.Encrypt(password.ToLower(), userLogOn.F_UserSecretkey).ToLower(), 32).ToLower();
                        if (dbPassword == userLogOn.F_UserPassword)
                        {
                            DateTime time = new DateTime(1800, 1, 1);
                            userLogOn.F_PreviousVisitTime = userLogOn.F_LastVisitTime < time ? time : userLogOn.F_LastVisitTime.ToDate();

                            userLogOn.F_LastVisitTime = DateTime.Now;
                            userLogOn.F_LogOnCount = userLogOn.F_LogOnCount + 1;

                            sql = "update sys_userlogon set F_PreviousVisitTime=@F_PreviousVisitTime, "
                                + "F_LastVisitTime=@F_LastVisitTime, F_LogOnCount=@F_LogOnCount where F_Id=@F_Id";
                            DBHelper.Execute(sql, userLogOn);

                            return user;
                        }
                        else
                        {
                            throw new Exception("密码不正确，请重新输入");
                        }
                    }
                    else
                    {
                        throw new Exception("账户不存在，请重新输入");
                    }
                }
                else
                {
                    throw new Exception("账户被系统锁定,请联系管理员");
                }
            }
            else
            {
                throw new Exception("账户不存在，请重新输入");
            }
        }
    }
}
