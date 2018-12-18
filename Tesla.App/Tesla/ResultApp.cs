using System.Collections.Generic;
using Tesla.Model;

namespace Tesla.App
{
    /// <summary>
    /// ResultApp
    /// </summary>
    public static class ResultApp
    {
        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static int Insert(List<AppResult> list)
        {
            string sql = "insert into app_result (CreateTime, LotteryID, Date, Rank, SingleCount, DoubleCount, BigCount, SmallCount, LongCount, HuCount) "
                       + "values(now(), @LotteryID, @Date, @Rank, @SingleCount, @DoubleCount, @BigCount, @SmallCount, @LongCount, @HuCount)";
            return DBHelper.Execute(sql, list);
        }
    }
}
