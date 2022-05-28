using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyTestAnyThing.Training.MSClass.Locker;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace EasyTestAnyThingTest.Training.MSClass
{
    public class LockerWalletTests
    {
        private readonly ITestOutputHelper _outputHelper;

        private readonly decimal AssertTotalMoneyWillBe = 85m;

        private List<decimal> AddMoneyList => new List<decimal> { 5, 10, 13, 12, 15, 20, 3, 2, 5 };

        public LockerWalletTests(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
            Wallet.ResetBalance();
        }

        [Fact]
        public void Balance_Not_Wrong_When_Lock()
        {
            Wallet.LockerOnOff = true;

            MockManyUserSameTimeCallApi();

            Wallet.GetBalance().Should().Be(AssertTotalMoneyWillBe);
        }

        [Fact]
        public void Balance_Wrong_When_No_Lock()
        {
            var errorTime = 0;
            foreach (var i in Enumerable.Range(1,10))
            { 
                Wallet.LockerOnOff = false;

                MockManyUserSameTimeCallApi();

                if (Wallet.GetBalance() != AssertTotalMoneyWillBe)
                {
                    errorTime++;
                }

                Wallet.ResetBalance();
                _outputHelper.WriteLine($"---------------Round:{i}---------------");
            }
            errorTime.Should().NotBe(0);
            _outputHelper.WriteLine($"ErrorTime: {errorTime}");
        }

        private void MockManyUserSameTimeCallApi()
        {
            var tasks = AddMoneyList.Select(MockInsertMoneyApi).ToList();
            Task.WhenAll(tasks).GetAwaiter().GetResult();
        }

        private Task MockInsertMoneyApi(decimal amount)
        {
            return Task.Run(() =>
            {
                _outputHelper.WriteLine(Wallet.InsertBalance(amount));
            });
        }
    }
}