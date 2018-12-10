﻿using Tesla.Model;

namespace Tesla.App
{
    /// <summary>
    /// GamePlayApp
    /// </summary>
    public class GamePlayApp
    {
        /// <summary>
        /// GetPlay
        /// </summary>
        /// <param name="remark"></param>
        /// <param name="lotteryId"></param>
        /// <returns></returns>
        public static GamePlay GetPlay(string remark, int lotteryId)
        {
            string sql = $"select * from app_game_play where LotteryID={lotteryId} and Remark='{remark}'";
            return DBHelper.GetOne<GamePlay>(sql);
        }

        /// <summary>
        /// SetLongQueue
        /// </summary>
        /// <param name="remark"></param>
        /// <param name="lotteryId"></param>
        /// <returns></returns>
        public static int SetLongQueue(string remark, int lotteryId)
        {
            string sql = $"update app_game_play set UpdateTime=now(), LongQueue=0 where LotteryID={lotteryId} and Remark!='{remark}';"
                       + $"update app_game_play set UpdateTime=now(), LongQueue=LongQueue + 1 where LotteryID={lotteryId} and Remark='{remark}'";
            return DBHelper.Execute(sql);
        }
    }
}