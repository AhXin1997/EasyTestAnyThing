using System.Linq;

namespace EasyTestAnyThing.MSClass
{
    public class StringSumAndNumSum
    {
        /*
           使 C# 中的轉型和轉換技術轉換資料類型
           StringSumAndNumSum
           規則 1：如果值為英數字元，請串連該值以形成訊息
           規則 2：如果值為數值，請將其新增至總計
           規則 3：請確定結果符合下列輸出：
         */

        public string StringSumAndNumSumMethod(string[] resource)
        {
            string[] values = resource;
            decimal num = 0;
            string str = "";

            foreach (var index in values.ToList())
            {
                if (decimal.TryParse(index, out decimal value))
                {
                    num += value;
                }
                else
                {
                    str += index;
                }
            }

            return "Message:" + str + "\n" + "Total:" + num;
        }
    }
}