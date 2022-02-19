using EasyTestAnyThing.CSharpReflection.Api.Model;
using System.Collections.Generic;

namespace EasyTestAnyThing.CSharpReflection.Api
{
    public class NewApi
    {
        private readonly string _domin;
        private readonly string _Token;
        private readonly string _currency;
        private readonly string _language;

        public NewApi(NewApiParameter parameter)
        {
            _domin = parameter.Domain;
            _Token = parameter.Token;
            _currency = parameter.Currency;
            _language = parameter.Language;
        }

        public string GetGameUrl()
        {
            string respond = string.Empty;
            var list = new List<string> { _domin, _Token, _language, _currency };
            list.ForEach(f => respond += f + "\n");

            return respond;
        }
    }
}