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
            Item = new Dictionary<string, string>
            {
                { "Domain", "http://google.com" },
                { "Token", "ABCDE123456" },
                { "Currency","USD"},
                { "Language","en-us"}
            };
        }

        public Dictionary<string, string> Item { get; set; }
    }
}