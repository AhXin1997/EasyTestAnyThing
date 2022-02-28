using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyTestAnyThing.MSClass
{
    public class ReverseChar
    {
        /*
         使用 C# 中的協助程式方法在陣列上執行作業
         ehT kciuq nworb xof spmuj revo eht yzal god
        */

        public string ReverseCharMethod(string request) 
        {
            return string.Join(" ", request
                .Split(' ') // ["The" , "quick" .... ]
                .Select(x => new String(x.Reverse().ToArray())));

            //return request
            // .Split(' ') // ["The" , "quick" .... ]
            // .Select(x => new String(x.Reverse().ToArray()))
            // .Aggregate((a, b) => a + " " + b);
        }
    }
}
