using System.Collections.Generic;

namespace EasyTestAnyThing.CSharpReflection.FakeDb
{
    public class ConnFakeDb
    {
        public ApiDomainThing DbTable => new ApiDomainThing();
    }

    public class ApiDomainThing
    {
        //模擬Db內資料
        public ApiDomainThing()
        {
            Datas = new List<Data> 
            { 
                new Data { Key = "Domain", Value = "http://google.com", Description = "網域" }, 
                new Data { Key = "Token", Value = "ABCDE123456", Description = "Token" },
                new Data { Key = "Currency", Value = "USD", Description = "貨幣" },
                new Data { Key = "Language", Value = "en-us", Description = "語言" },
            };
        }
        public List<Data> Datas { get; set; }
    }

    public class Data 
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
    }
}