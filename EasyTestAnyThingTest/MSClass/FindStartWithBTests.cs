using FluentAssertions;
using NSubstitute;
using System.Collections.Generic;
using Xunit;

namespace EasyTestAnyThing.MSClass.Tests
{
    public class FindStartWithBTests
    {
        private FindStartWithB _target;
        private IData _Data;
        private IMessageSystem _messageSystem;

        public FindStartWithBTests()
        {
            _messageSystem = Substitute.For<IMessageSystem>();
            _Data = Substitute.For<IData>();
            _target = new FindStartWithB(_Data, _messageSystem);
        }

        [Fact]
        public void NewStartWithString_OutPut_Right_Data()
        {
            string data = "B123 C234 A345 C15 B177 G3003 C235 B179";
            char split = ' ';
            string startWith = "B";
            var getData = new List<string>();

            _messageSystem.When(w => w.OutputMessage(Arg.Any<List<string>>()))
                .Do(d => getData = d[0].As<List<string>>());

            //Act
            _target.NewStartWithString(data, split, startWith);

            //Assert
            _messageSystem.Received()
                .OutputMessage(Arg.Is<List<string>>(r => 
                r[0] == "B123" && 
                r[1] == "B177" && 
                r[2] == "B179")
                );
            
            getData.Should().BeEquivalentTo(new List<string> { "B123", "B177", "B179" });

        }

        [Fact]
        public void FindStartWithStringMethod_Output_Right_Message()
        {
            //Arrange
            _Data.GetData().Returns("A123 B456 C789");

            var getData = new List<string>();

            _messageSystem.When(w => w.OutputMessage(Arg.Any<List<string>>()))
                .Do(d => getData = d[0].As<List<string>>());

            //Act
            _target.FindStartWithStringMethod("B");

            //Assert
            getData.Should().BeEquivalentTo(new List<string> { "B456" });
        }

        [Fact]
        public void SplitString_Success()
        {
            //Arrange
            string data = "A123 B456 C789 D999";

            //Act
            var target = _target.SplitString(data);

            //Assert
            target.Should()
                .BeEquivalentTo(new List<string>
                {
                    "A123","B456","C789","D999"
                });
        }

        [Fact]
        public void ExcludeString_Find_Right_Thing()
        {
            //Arrange
            string[] data = { "A123", "B456", "C789", "D999" };

            //Act
            var target = _target.GetStartsWithString(data, "B");

            //Assert
            target.Should()
                .BeEquivalentTo(new List<string>
                {
                    "B456"
                });
        }
    }
}