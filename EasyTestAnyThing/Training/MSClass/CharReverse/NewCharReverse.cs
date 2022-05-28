using System.Linq;

namespace EasyTestAnyThing.Training.MSClass.CharReverse
{
    public class NewCharReverse
    {
        /*
         * 使用 C# 中的協助程式方法在陣列上執行作業
         * The quick brown fox jumps over the lazy dog
         * To
         * ehT kciuq nworb xof spmuj revo eht yzal god
         */

        public string ReverseLogic(string str,char splitWith)
        {
            return string.Join(
                " ", 
                str.Split(splitWith).Select(s => string.Join(string.Empty, s.Reverse())));
        }
    }
}