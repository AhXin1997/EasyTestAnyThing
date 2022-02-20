using Newtonsoft.Json;
using System;
using System.Linq;

namespace EasyTestAnyThing.Json
{
    public static class JsonDateTime
    {
        /*
         * 測試Json在序列化與反序列化過程中
         * 將字串轉成物件是否會改變甚麼
         */

        public static void JsonTest()
        {
            var request = new Request()
            {
                Name = "Ash",
                Money = "120.5",
                Birthday = "1997-12-12T09:15:30+00:00",
                //Time = new DateTime(2022, 02, 15, 09, 15, 30).ToString("yyyy-MM-ddThh:mm:sszzz")
            };

            var ObjectToJson = JsonConvert.SerializeObject(request);
            ObjectToJson.Replace("{","").Replace("}","").Insert(0,"序列化,")
                .Split(',')
                .ToList()
                .ForEach(f => Console.WriteLine(f));

            var jsonToObject = JsonConvert.DeserializeObject<Respond>(ObjectToJson);
            Console.WriteLine("反序列化\n" +
                 nameof(jsonToObject.Name) + " : " + jsonToObject.Name + "\n" +
                 nameof(jsonToObject.Money) + " : " + jsonToObject.Money + "\n" +
                 nameof(jsonToObject.Birthday) + " : " + jsonToObject.Birthday + "\n" 
                );
        }
    }

    public class Request
    {
        public string Name { get; set; }
        public string Money { get; set; }
        public string Birthday { get; set; }
    }

    public class Respond
    {
        public string Name { get; set; }
        public decimal Money { get; set; }
        public DateTime Birthday { get; set; }
    }
}