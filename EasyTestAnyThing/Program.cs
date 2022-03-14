using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace EasyTestAnyThing
{
    public class Rich88BetRecord
    {
        [JsonProperty("record_id")] public string RecordId { get; set; }

        [JsonProperty("created_at")] public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")] public DateTime UpdatedAt { get; set; }

        [JsonProperty("game_code")] public string GameCode { get; set; }

        [JsonProperty("account")] public string Account { get; set; }

        [JsonProperty("bet_status")] public long BetStatus { get; set; }

        [JsonProperty("base_bet")] public decimal BaseBet { get; set; }

        [JsonProperty("bet")] public decimal Bet { get; set; }

        [JsonProperty("bet_valid")] public decimal BetValid { get; set; }

        [JsonProperty("profit")] public decimal Profit { get; set; }

        [JsonProperty("tax")] public decimal Tax { get; set; }

        [JsonProperty("balance")] public decimal Balance { get; set; }

        [JsonProperty("bonus")] public decimal Bonus { get; set; }

        [JsonProperty("result")] public string Result { get; set; }

        [JsonProperty("round_id")] public string RoundId { get; set; }

        [JsonProperty("round_start_at")] public DateTime RoundStartAt { get; set; }

        [JsonProperty("round_end_at")] public DateTime RoundEndAt { get; set; }

        [JsonProperty("currency")] public string Currency { get; set; }

        [JsonProperty("category")] public string Category { get; set; }

        public class Program
        {
            private static void Main()
            {
                //var list = new List<string>();
                //var type = typeof(Rich88BetRecord);
                //foreach (var index in type.GetProperties())
                //{
                //    list.Add($"public {index.PropertyType.ToString().Replace("System.","").ToLower()} {index.Name} " + "{get; set;}"); 
                //}
                //list.ForEach(f => Console.WriteLine(f));
                //Console.ReadKey();
                
                var x = new EasyTestAnyThing.DoNotNewObjectInLoop.WhyNotNewObjectInLoop();
                x.Start(true);

                Console.ReadKey();
            }

            /* TODO_List
            Add Thread Safe C# Example
            Learn How to use Fun Action
            Flurl 套件熟悉(串Url)
    
            [✓] Console 導入 Mvc架構 可由 PostMan 打入Api
            Add Filter      Example
    
            Try Add Db
            Add Repository  Example
            Mapping
                one to one
                one to many
                many to many
    
             */
        }
    }
}