using System.Collections.Generic;
using Tesla.Model;
using Tesla.Utils;

namespace Tesla.App
{
    /// <summary>
    /// 注单APP
    /// </summary>
    public static class BetOrderApp
    {
        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public static int Insert(BetOrder order)
        {
            string sql = "insert into app_betorder(CreateTime, CreateTimestamp, TaskId, TaskName, LotteryName, Issue, Number, SingleMoney, TotalMoney, Source, BeforeBalance, AfterBalance, UserName)"
                       + "values(@CreateTime, @CreateTimestamp, @TaskId, @TaskName, @LotteryName, @Issue, @Number, @SingleMoney, @TotalMoney, @Source, @BeforeBalance, @AfterBalance, @UserName)";
            return DBHelper.Execute(sql, order);
        }

        /// <summary>
        /// 取列表
        /// </summary>
        /// <param name="pagerInfo"></param>
        /// <returns></returns>
        public static List<BetOrder> GetList(PagerInfo pagerInfo)
        {
            return DBHelper.GetPageList<BetOrder>(pagerInfo);
        }
    }
}
