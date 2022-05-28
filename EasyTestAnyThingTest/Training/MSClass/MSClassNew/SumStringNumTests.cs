using EasyTestAnyThing.Training.MSClass.SumStringNum;
using FluentAssertions;
using Xunit;

namespace EasyTestAnyThingTest.Training.MSClass.MSClassNew
{
    /*
     * string[] values = { "12.3", "45", "ABC", "11", "DEF" };
     * 使 C# 中的轉型和轉換技術轉換資料類型
     * 規則 1：如果值為英數字元，請串連該值以形成訊息
     * 規則 2：如果值為數值，請將其新增至總計
     * 規則 3：請確定結果符合下列輸出：
     * Message: ABCDEF
     * Total: 68.3
     */

    public class SumStringNumTests
    {
        private readonly SumStringNumClass _target;

        public SumStringNumTests()
        {
            _target = new SumStringNumClass();
        }

        [Fact]
        public void Sum_When_Request_Is_Num()
        {
            string[] values = { "12.3", "45", "ABC", "11", "DEF" };

            var actual = _target.StartMethod(values);

            actual.Should().BeEquivalentTo(new SumStringNumResponse() 
            {
                Message = "ABCDEF",
                Total = 68.3m,
            });
        }
    }
}