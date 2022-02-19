using Newtonsoft.Json;
using System;

namespace EasyTestAnyThing.Json
{
    public static class JsonDateTime
    {
        /*
            測試Json在序列化與反序列化過程中
            將字串轉成物件是否會改變甚麼
         */

        public static void JsonTest()
        {
            var request = new Request()
            {
                Name = "Test01",
                Num = "1.5555555555",
                Time = "2022-02-15T09:15+00:00",
                //Time = new DateTime(2022, 02, 15, 09, 15, 30).ToString("yyyy-MM-ddThh:mm:sszzz")
            };

            var requestToJson = JsonConvert.SerializeObject(request);
            Console.WriteLine("序列化\n" + requestToJson);

            var respond = JsonConvert.DeserializeObject<Respond>(requestToJson);
            Console.WriteLine("反序列化\n" +
                 respond.Name + "\n" +
                 respond.Num  + "\n" +
                 respond.Time + "\n"
                );
        }
    }

    public class Request
    {
        public string Name { get; set; }
        public string Num { get; set; }
        public string Time { get; set; }
    }

    public class Respond
    {
        public string Name { get; set; }
        public decimal Num { get; set; }
        public DateTime Time { get; set; }
    }
}