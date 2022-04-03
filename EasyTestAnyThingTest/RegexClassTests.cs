using EasyTestAnyThing.RegularExpression;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace EasyTestAnyThingTest
{
    public class RegexClassTests
    {
        private readonly RegexClass _target;

        public RegexClassTests()
        {
            _target = new RegexClass();
        }

        [Fact]
        public void False_When_Request_Is_Not_Email() 
        {
            var request = "abcdefg";

            var actual = _target.VerifyIsEmail(request);

            actual.Should().BeEquivalentTo(new RegexResult 
            {
                Message = "",
                IsMatchRule = false,
            });
        }

        [Fact]
        public void True_When_Request_Is_Match_Email()
        {
            var request = "abcdefg@gmail.com";

            var actual = _target.VerifyIsEmail(request);

            actual.Should().BeEquivalentTo(new RegexResult
            {
                Message = "abcdefg@gmail.com",
                IsMatchRule = true,
            });
        }

        [Fact]
        public void False_When_Request_Is_Not_Decimal_Second_Place()
        {
            var request = 1.001m;

            var actual = _target.VerifyDecimalSecondPlace(request);

            actual.Should().BeEquivalentTo(new RegexResult
            {
                Message = "",
                IsMatchRule = false,
            });
        }

        [Fact]
        public void False_When_Request_Is_Decimal_Second_Place()
        {
            var request = 1.01m;

            var actual = _target.VerifyDecimalSecondPlace(request);

            actual.Should().BeEquivalentTo(new RegexResult
            {
                Message = 1.01m.ToString(),
                IsMatchRule = true,
            });
        }
    }
}
