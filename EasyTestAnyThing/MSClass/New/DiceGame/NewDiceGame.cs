using System.Collections.Generic;
using System.Linq;

namespace EasyTestAnyThing.MSClass.New.DiceGame
{
    /*
        2022/03/01
        在 C# 中使用 if-elseif-else 陳述式在程式碼中加入決策邏輯

        如果您擲出的任兩個骰子產生相同的值，即會因為擲出兩倍而得到兩點獎勵。
        如果您擲出的三顆骰子全都產生相同的值，則會因為擲出三倍而得到六點獎勵。
        如果這三顆骰子擲出的總和加上任何獎勵點數為 15 或以上，您就贏得此遊戲。 否則，您就輸了。
    */


    //架構重整
    public class NewDiceGame
    {
        public static void Start()
        {
            new NewDiceGame(new DiceService(), new MessageCenter()).Game();
        }

        private readonly IDiceService _diceService;
        private readonly IMessageCenter _messageCenter;

        public NewDiceGame(IDiceService diceService, IMessageCenter messageCenter)
        {
            _diceService = diceService;
            _messageCenter = messageCenter;
        }

        public void Game()
        {
            var diceBox = _diceService.RandDice();

            var totalPoint = SumDiceAndGivePoint(diceBox);

            var winOrLose = WinOrLose(totalPoint);

            _messageCenter.SendMessage(diceBox);
            _messageCenter.SendMessage(totalPoint,winOrLose);
        }

        //規則 拉變數
        private int SumDiceAndGivePoint(List<int> diceBox)
        {
            switch (diceBox.Distinct().Count())
            {
                case 2:
                    return diceBox.Sum() + 2;

                case 1:
                    return diceBox.Sum() + 6;

                default:
                    return diceBox.Sum();
            }
        }

        private bool WinOrLose(int totalPoint)
        {
            return totalPoint >= 15;
        }
    }


}