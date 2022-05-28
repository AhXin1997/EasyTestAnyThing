using System.Collections.Generic;
using EasyTestAnyThing.Training.CSharpReflection.Api.Model;

namespace EasyTestAnyThing.Training.CSharpReflection.Api
{
    public class NewApi
    {
        private readonly string _domain;
        private readonly string _token;
        private readonly string _currency;
        private readonly string _language;

        public NewApi(NewApiParameter parameter)
        {
            _domain = parameter.Domain;
            _token = parameter.Token;
            _currency = parameter.Currency;
            _language = parameter.Language;
        }

        public string GetGameUrl()
        {
            var respond = string.Empty;
            var list = new List<string> { _domain, _token, _language, _currency };
            list.ForEach(f => respond += f + "\n");

            return respond;
        }
    }
}