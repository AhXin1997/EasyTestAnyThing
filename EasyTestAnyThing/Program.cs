using EasyTestAnyThing.Tool;
using EasyTestAnyThing.Tool.Enum;
using System;
using EasyTestAnyThing.WebServer;
using Newtonsoft.Json;

namespace EasyTestAnyThing
{
    public class Program
    {
        private class Km
        {
            /// <summary>
            /// QM内部投注辨识码
            /// 唯一键值
            /// 长度:36字符
            /// </summary>
            [JsonProperty("ugsbetid")]
            public string UgsBetId { get; set; }

            /// <summary>
            /// 来自游戏供应商的交易或投注辨识码
            /// 最大长度:50字符
            /// </summary>
            [JsonProperty("txid")]
            public string Txid { get; set; }

            /// <summary>
            /// 外部的投注辨识码(来自游戏供应商)
            /// 最大长度:64字符
            /// </summary>
            [JsonProperty("betid")]
            public string BetId { get; set; }

            /// <summary>
            /// 记录在QM服务器的投注时间，包括时区偏移量，如2014-09-25T07:07:31+00:00。
            /// </summary>
            [JsonProperty("beton")]
            public DateTime BetTime { get; set; }

            /// <summary>
            /// 投注关闭的时间，如2014-09-25T07:07:31+00:00。
            /// </summary>
            [JsonProperty("betclosedon")]
            public DateTime BetCloseTime { get; set; }

            /// <summary>
            /// 投注更新的时间，如2014-09-25T07:07:31+00:00。
            /// </summary>
            [JsonProperty("betupdatedon")]
            public DateTime BetUpdateTime { get; set; }

            /// <summary>
            /// 游戏供应商处理动作的时间戳，如2014-09-25T07:07:31+00:00。
            /// </summary>
            [JsonProperty("timestamp")]
            public DateTime TimeStamp { get; set; }

            /// <summary>
            /// 游戏交易执行回合(round)时的游戏供应商辨识码。
            /// 最大长度:50字符
            /// </summary>
            [JsonProperty("roundid")]
            public string RoundId { get; set; }

            /// <summary>
            /// 游戏回合状态，为下列其中之一:Open/Closed
            /// 最大长度:10字符
            /// </summary>
            [JsonProperty("roundstatus")]
            public string RoundStatus { get; set; }

            /// <summary>
            /// 玩家专属辨识代码
            /// 最大长度:50字符
            /// </summary>
            [JsonProperty("userid")]
            public string UserId { get; set; }

            /// <summary>
            /// 玩家的显示名称。
            /// 最大长度:50字符
            /// </summary>
            [JsonProperty("username")]
            public string UserName { get; set; }

            /// <summary>
            /// 投注的总金额。此值为负数。代表玩家从账户扣掉的金额。
            /// </summary>
            [JsonProperty("riskamt")]
            public decimal RiskAmount { get; set; }

            /// <summary>
            /// 投注赢的金额。若玩家赢因此账户加钱，此值为正数。若没有输赢则为0。
            /// </summary>
            [JsonProperty("winamt")]
            public decimal WinAmount { get; set; }

            /// <summary>
            /// 投注的净总金额。
            /// </summary>
            [JsonProperty("winloss")]
            public decimal WinLoss { get; set; }

            /// <summary>
            /// 投注交易前玩家的余额。
            /// </summary>
            [JsonProperty("beforebal")]
            public decimal BeforeBalance { get; set; }

            /// <summary>
            /// 投注交易后玩家的余额。
            /// </summary>
            [JsonProperty("postbal")]
            public decimal PostBalance { get; set; }

            /// <summary>
            /// 玩家于QM系统使用的货币
            /// 长度:3字符
            /// </summary>
            [JsonProperty("cur")]
            public string Currency { get; set; }

            /// <summary>
            /// 游戏供应商的名称
            /// 最大长度:50字符
            /// </summary>
            [JsonProperty("gameprovider")]
            public string GameProvider { get; set; }

            /// <summary>
            /// 游戏供应商代码
            /// 最大长度:50字符
            /// </summary>
            [JsonProperty("gameprovidercode")]
            public string GameProviderCode { get; set; }

            /// <summary>
            /// 游戏名称
            /// 最大长度:50字符
            /// </summary>
            [JsonProperty("gamename")]
            public string GameName { get; set; }

            /// <summary>
            /// 游戏供应商的专属游戏辨识代码
            /// 最大长度:50字符
            /// </summary>
            [JsonProperty("gameid")]
            public string GameId { get; set; }

            /// <summary>
            /// 游戏平台的类型。请参阅附录L。
            /// 0 Desktop
            /// 1 Mobile
            /// 最大长度:50字符
            /// </summary>
            [JsonProperty("platformtype")]
            public string PlatformType { get; set; }

            /// <summary>
            /// 玩家IP地址
            /// 最大长度: 40字符
            /// </summary>
            [JsonProperty("ipaddress")]
            public string IpadDress { get; set; }

            /// <summary>
            /// 下注類型
            /// 永远是“PlaceBet”
            /// 最大长度:30字符
            /// </summary>
            [JsonProperty("bettype")]
            public string BetType { get; set; }

            /// <summary>
            /// 游戏供应商所定义的游戏类别
            /// 此值可能回传一个Json字符串
            /// 请参照附录O
            /// 最大长度:200字符
            /// </summary>
            [JsonProperty("playtype")]
            public string PlayType { get; set; }

            /// <summary>
            /// 用来辨识转账的玩家为真实玩家或测试玩家。
            /// 1代表真实玩家
            /// 2代表营运商测试玩家
            /// 4.代表QM测试玩家
            /// </summary>
            [JsonProperty("playertype")]
            public int PlayerType { get; set; }

            /// <summary>
            /// 回合中所有投注的流水额。此值为正数。
            /// </summary>
            [JsonProperty("turnover")]
            public decimal Turnover { get; set; }

            /// <summary>
            /// 回合中所有投注的有效投注总金额。
            /// </summary>
            [JsonProperty("validbet")]
            public decimal ValidBet { get; set; }
        }

        private static void Main()
        {
            //[Tool]
            typeof(Km).EasyOutputMessageMethod(EasyOutputMessageMethod.ToCreateSqlParameter);

            //[WebServer]
            ServerStart.Server(false);

            Console.ReadKey();
        }

        /* TODO_List
         * Add Thread Safe C# Example
         * Learn How to use Fun Action
         * Flurl 套件熟悉(串Url)
         * Autofac
         * Mediator
         *
         * [✓] Console 導入 Mvc架構 可由 PostMan 打入Api
         * Add Filter      Example
         *
         * Try Add Db
         * Add Repository  Example
         * Mapping
         *     one to one
         *     one to many
         *     many to many
         *
         *
         */
    }
}