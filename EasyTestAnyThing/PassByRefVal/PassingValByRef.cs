namespace EasyTestAnyThing.PassByRefVal
{
    public static class PassingValByRef
    {
        /*
            Passing By Reference
            於 SquareIt 丟進去的值
            指向上面宣告的 n 物件記憶體位置
            所以在 SquareIt 對 x 做修改 外部的 n 值也會更動
         */

        private static void SquareIt(ref int x) //0x23 = *0x123
        // The parameter x is passed by reference.
        // Changes to x will affect the original value of x.
        {
            x *= x;
            System.Console.WriteLine("The value inside the method: {0}", x);
        }

        public static void Start()
        {
            int n = 5; //0x123
            System.Console.WriteLine("The value before calling the method: {0}", n);

            SquareIt(ref n);  // Passing the variable by reference.
            System.Console.WriteLine("The value after calling the method: {0}", n);
        }
    }

    /* Output:
        The value before calling the method: 5
        The value inside the method: 25
        The value after calling the method: 25
    */
}