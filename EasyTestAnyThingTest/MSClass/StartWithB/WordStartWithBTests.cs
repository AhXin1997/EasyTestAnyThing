using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FluentAssertions;
using EasyTestAnyThing.MSClass.New.WordStartWithB;

namespace EasyTestAnyThingTest.MSClass.StartWithB
{
    public class WordStartWithBTests
    {
        private readonly WordStartWithB _target;

        public WordStartWithBTests() 
        {
            _target = new WordStartWithB();
        }

        [Fact]
        public void Success_Find_B_Word() 
        {
            //arange
            var strlist = new List<string> { "A123", "B456" , "C789" , "aBc" };

            _target.Start(strlist).Should().BeEquivalentTo(new List<string> { "B456"});
        }
    }
}
