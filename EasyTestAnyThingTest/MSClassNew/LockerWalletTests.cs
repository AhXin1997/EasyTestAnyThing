using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyTestAnyThing.MSClassNew.Locker;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace EasyTestAnyThingTest.MSClassNew
{
    public class LockerWalletTests
    {
        private readonly ITestOutputHelper _outputHelper;

        private readonly decimal AssertTotalMoneyWillBe = 85m;

        private List<decimal> AddMoneyList => new List<decimal> { 5, 10, 13, 12, 15, 20, 3, 2, 5 };

        public LockerWalletTests(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
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
            Wallet.LockerOnOff = false;

            MockManyUserSameTimeCallApi();

            Wallet.GetBalance().Should().NotBe(AssertTotalMoneyWillBe);
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