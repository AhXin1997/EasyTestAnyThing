namespace EasyTestAnyThing.MSClass.New.SumStringNum
{
    public class SumStringNumClass
    {
        public SumStringNumRespones StartMethod(string[] request)
        {
            var str = string.Empty;
            var num = 0m;

            foreach (var item in request)
            {
                if (decimal.TryParse(item, out var tempNum))
                {
                    num += tempNum;
                }
                else
                {
                    str += item;
                }
            }

            return new SumStringNumRespones()
            {
                Message = str,
                Total = num
            };
        }
    }
}