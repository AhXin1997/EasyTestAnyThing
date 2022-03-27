using EasyTestAnyThing.MSClass.New.Locker;
using FluentAssertions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace EasyTestAnyThingTest.MSClass.New.Locker
{
    public class LockerWalletTests
    {
        private readonly ITestOutputHelper OutputHelper;

        private readonly decimal AssertTotalMoneyWiilBe = 85m;

        private List<decimal> AddMoneyList => new List<decimal> { 5, 10, 13, 12, 15, 20, 3, 2, 5 };

        public LockerWalletTests(ITestOutputHelper outputHelper)
        {
            OutputHelper = outputHelper;
        }

        [Fact]
        public void Balance_Not_Wrong_When_Lock()
        {
            Wallet.LockerOnOff = true;

            MockManyUserSameTimeCallApi();

            Wallet.GetBalance().Should().Be(AssertTotalMoneyWiilBe);
        }

        [Fact]
        public void Balance_Wrong_When_No_Lock()
        {
            Wallet.LockerOnOff = false;

            MockManyUserSameTimeCallApi();

            Wallet.GetBalance().Should().NotBe(AssertTotalMoneyWiilBe);
        }

        private void MockManyUserSameTimeCallApi()
        {
            var tasks = new List<Task>();
            foreach (var item in AddMoneyList)
            {
                tasks.Add(MockInsertMoneyApi(item));
            }
            Task.WhenAll(tasks).GetAwaiter().GetResult();
        }

        private Task MockInsertMoneyApi(decimal amount)
        {
            return Task.Run(() =>
            {
                OutputHelper.WriteLine(Wallet.InsertBalance(amount));
            });
        }
    }
}