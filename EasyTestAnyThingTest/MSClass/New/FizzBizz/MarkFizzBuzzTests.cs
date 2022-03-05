using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FluentAssertions;
using EasyTestAnyThing.MSClass.New.FizzBizz;

namespace EasyTestAnyThingTest.MSClass.New.FizzBizz
{
    public class MarkFizzBuzzTests
    {
        private readonly MarkFizzBuzz _target;

        public MarkFizzBuzzTests() 
        {
            _target = new MarkFizzBuzz();
        }
        [Fact]
        public void test() 
        {
            var list = new List<int> { 1, 2, 3, 4, 5,15};
            _target.MarkFizzBuzzMethod(list).Should().BeEquivalentTo(new List<string> 
            { 
                "1","2","3 Fizz","4","5 Buzz","15 FizzBuzz"
            });
        }
    }
}
