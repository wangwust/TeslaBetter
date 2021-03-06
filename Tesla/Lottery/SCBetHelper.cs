﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesla.App;
using Tesla.Model;
using Tesla.Utils;

namespace Tesla
{
    /// <summary>
    /// SCBetHelper
    /// </summary>
    public class SCBetHelper
    {
        /// <summary>
        /// 投注
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static ApiResponse<BetResponse> Bet(BetParams param)
        {
            if (string.IsNullOrEmpty(param.IP))
            {
                return new ApiResponse<BetResponse> { code = -1, msg = "请求IP不能为空！" };
            }

            Dictionary<string, string> headerDic = new Dictionary<string, string>
            {
                { "Client-Type", param.ClientType },
                { "staffid", param.PlatformId },
                { "username", param.UserName },
                { "timestamp", DateTime.Now.ToTimestamp().ToString() },
                { "token", param.Token },
                { "x-forwarded-for", param.IP }
            };

            Dictionary<string, string> paramDic = new Dictionary<string, string>
            {
                { "data", param.BetInfo },
                { "PeriodNumber", param.Issue },
            };

            string result = HttpHelper.HttpPost(param.Api + "/order/bet/" + param.LotteryID, paramDic, headerDic, null);
            ApiResponse<BetResponse> reponse = result.ToEntity<ApiResponse<BetResponse>>();
            return reponse;
        }

        /// <summary>
        /// 获取期号
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static ApiResponse<LotteryInfoReponse> GetLotteryInfo(LotteryInfoParams param)
        {
            Dictionary<string, string> headerDic = new Dictionary<string, string>
            {
                { "Client-Type", param.ClientType },
                { "staffid", param.PlatformId },
                { "username", param.UserName },
                { "timestamp", DateTime.Now.ToTimestamp().ToString() },
                { "token", param.Token },
                { "X-Forwarded-For", param.IP},
            };

            string result = HttpHelper.HttpGet(param.Api + "/lottery/info/" + param.LotteryID, headerDic, null);
            ApiResponse<LotteryInfoReponse> reponse = result.ToEntity<ApiResponse<LotteryInfoReponse>>();
            return reponse;
        }

        /// <summary>
        /// 获取长龙
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static ApiResponse<LongQueueResponse> GetLongQueue(LongQueueParams param)
        {
            Dictionary<string, string> headerDic = new Dictionary<string, string>
            {
                { "Client-Type", param.ClientType },
                { "staffid", param.PlatformId },
                { "username", param.UserName },
                { "timestamp", DateTime.Now.ToTimestamp().ToString() },
                { "token", param.Token },
                { "X-Forwarded-For", param.IP},
            };

            string result = HttpHelper.HttpGet(param.Api + "/lottery/getLongQueue/" + param.LotteryID, headerDic, null);
            ApiResponse<LongQueueResponse> reponse = result.ToEntity<ApiResponse<LongQueueResponse>>();
            return reponse;
        }

        /// <summary>
        /// GetBetParams
        /// </summary>
        /// <param name="task"></param>
        /// <param name="longQueue"></param>
        /// <param name="lotteryId"></param>
        /// <param name="cateName"></param>
        /// <param name="totalMoney"></param>
        /// <returns></returns>
        public static BetParams GetBetParams(AppTask task, List<AppBetInfo> betInfoList, int lotteryId, ref decimal totalMoney, ref string cateName)
        {
            BetParams betParam = new BetParams();
            List<SCBetInfo> list = new List<SCBetInfo>();
            foreach (AppBetInfo model in betInfoList)
            {
                GamePlay gamePlay = GamePlayApp.GetPlay(model.PlayId, lotteryId);
                if (gamePlay == null)
                {
                    continue;
                }

                totalMoney += model.Money;
                cateName += gamePlay.Remark + ",";

                SCBetInfo betInfo = new SCBetInfo { money = model.Money, playId = model.PlayId };
                list.Add(betInfo);
            }

            if (list.Count > 0)
            {
                betParam.BetInfo = list.ToJson();
            }

            return betParam;
        }
    }
}
