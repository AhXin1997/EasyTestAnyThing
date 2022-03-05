using System.Collections.Generic;
using System.Linq;

namespace EasyTestAnyThing.MSClass.New.WordStartWithB
{
    /*
     * 2022/03/05
     * 使用 C# 中的陣列及 foreach 陳述式來儲存及逐一查看資料序列
     * 如果假訂單識別碼是以 "B" 開頭，則將訂單識別碼列印至輸出。
     */

    public class WordStartWithB
    {
        public List<string> Start(List<string> orderNumber)
        {
            var list = new List<string>();
            foreach (var word in orderNumber)
            {
                if (word.StartsWith("B"))
                {
                    list.Add(word);
                }
            }
            return list;
            return orderNumber.Where(s => s.StartsWith("B")).ToList();
        }
    }
}