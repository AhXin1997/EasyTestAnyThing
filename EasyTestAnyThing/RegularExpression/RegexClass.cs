using System.Text.RegularExpressions;

namespace EasyTestAnyThing.RegularExpression
{
    public class RegexClass
    {
        public RegexResult VerifyIsEmail(string request)
        {
            var result = new Regex(@"^[\w]*@gmail.com$")
                .Match(request);

            return new RegexResult()
            {
                Message = result.Value,
                IsMatchRule = result.Success
            };        
        }

        public RegexResult VerifyDecimalSecondPlace(decimal amount)
        {
            var result = new Regex(@"^[\d](.[\d]{1,2})?$")
                .Match(amount.ToString());

            return new RegexResult()
            {
                Message = result.Value,
                IsMatchRule = result.Success
            };
        }
    }
}