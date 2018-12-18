using System;
using System.Collections.Generic;
using System.Linq;
using Tesla.Model;

namespace Tesla.App
{
    /// <summary>
    /// BetInfoApp
    /// </summary>
    public static class BetInfoApp
    {
        /// <summary>
        /// 取列表
        /// </summary>
        /// <param name="lotteryId"></param>
        /// <returns></returns>
        public static List<AppBetInfo> GetList(int lotteryId)
        {
            string sql = $"select * from app_betinfo where LotteryID = {lotteryId} and State = 1";
            return DBHelper.GetList<AppBetInfo>(sql).ToList();
        }

        /// <summary>
        /// 取列表
        /// </summary>
        /// <returns></returns>
        public static List<AppBetInfo> GetList2(int lotteryId)
        {
            string sql = $"select * from app_betinfo where LotteryID = {lotteryId} order by ID desc";
            return DBHelper.GetList<AppBetInfo>(sql).ToList();
        }

        /// <summary>
        /// 取实体
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public static AppBetInfo GetOne(int keyValue)
        {
            string sql = $"select * from app_betinfo where ID = {keyValue} ";
            return DBHelper.GetOne<AppBetInfo>(sql);
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int Add(AppBetInfo model)
        {
            string sql = "insert into app_betinfo(CreateTime, LotteryID, Money, PlayId)"
                       + "values(now(), @LotteryID, @Money, @PlayId)";
            return DBHelper.Execute(sql, model);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int Update(AppBetInfo model)
        {
            string sql = "update app_betinfo set UpdateTime=now(), Money=@Money, PlayId=@PlayId where ID=@ID";
            return DBHelper.Execute(sql, model);
        }

        /// <summary>
        /// 更新状态
        /// </summary>
        /// <param name="id"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public static int UpdateState(int id, int state)
        {
            string sql = "update app_betinfo set UpdateTime=now(), State=@State where ID=@ID";
            return DBHelper.Execute(sql, new { State = state, ID = id });
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public static int Delete(int keyValue)
        {
            string sql = "delete from app_betinfo where ID=@ID";
            return DBHelper.Execute(sql, new { ID = keyValue });
        }
    }
}
