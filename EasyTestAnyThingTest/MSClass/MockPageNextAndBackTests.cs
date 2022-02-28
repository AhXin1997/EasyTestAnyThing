using FluentAssertions;
using NSubstitute;
using System;
using System.Collections.Generic;
using Xunit;

namespace EasyTestAnyThing.MSClass.Tests
{
    public class MockPageNextAndBackTests
    {
        private IPageData _data;
        private MockPageNextAndBack _mockPageNextAndBack;
        private IMessageSystem _messageSystem;

        public MockPageNextAndBackTests()
        {
            _data = Substitute.For<IPageData>();
            _messageSystem = Substitute.For<IMessageSystem>();
            _mockPageNextAndBack = new MockPageNextAndBack(_data, _messageSystem);
        }

        [Fact]
        public void MockPageTest_Next()
        {
            //Arrange
            var setData = new List<string> { "1", "2", "3", "4" };
            var getData = new List<string>();
            _data.GetData().Returns(setData);

            _messageSystem.When(w => w.OutputMessage(Arg.Any<List<string>>()))
                            .Do(d => getData = d[0].As<List<string>>());

            //Act
            _mockPageNextAndBack.MockPage(PageButton.Next);

            //Assert
            getData.Should().BeEquivalentTo(new List<string> { "1", "2" });
        }

        [Fact]
        public void MockPageTest_Next_Retrun_Exception()
        {
            //Arrange
            var getData = new List<string>();
            _data.GetData().Returns(r =>
            {
                throw new Exception();
            });

            _messageSystem.When(w => w.OutputMessage(Arg.Any<List<string>>()))
                            .Do(d => getData = d[0].As<List<string>>());

            //Act
            _mockPageNextAndBack.MockPage(PageButton.Next);

            //Assert
            getData.Should().BeEquivalentTo(new List<string> { "2", "3" });
        }

        [Fact]
        public void MockPageTest_Next_OutDataRange()
        {
            //Arrange
            var setData = new List<string> { "1", "2", "3", "4" };
            var getData = new List<string>();
            _data.GetData().Returns(setData);

            _messageSystem.When(w => w.OutputMessage(Arg.Any<List<string>>()))
                            .Do(d => getData = d[0].As<List<string>>());

            //Act
            for (int i = 0; i < 3; i++)
            {
                _mockPageNextAndBack.MockPage(PageButton.Next);
            }

            //Assert
            getData.Should().BeEmpty();
        }

        [Fact]
        public void MockPageTest_Back()
        {
            //Arrange
            var setData = new List<string> { "1", "2", "3", "4" };
            var getData = new List<string>();
            _data.GetData().Returns(setData);

            _messageSystem.When(w => w.OutputMessage(Arg.Any<List<string>>()))
                            .Do(d => getData = d[0].As<List<string>>());

            //Act
            _mockPageNextAndBack.MockPage(PageButton.Back);

            //Assert
            getData.Should().BeEmpty();
        }

        [Fact]
        public void MockPageTest_Back_Page2()
        {
            //Arrange
            var setData = new List<string> { "1", "2", "3", "4" };
            var getData = new List<string>();
            _data.GetData().Returns(setData);

            _messageSystem.When(w => w.OutputMessage(Arg.Any<List<string>>()))
                            .Do(d => getData = d[0].As<List<string>>());

            //Act
            _mockPageNextAndBack.MockPage(PageButton.Next);
            _mockPageNextAndBack.MockPage(PageButton.Back);

            //Assert
            getData.Should().BeEquivalentTo(new List<string> { "1", "2" });
        }
    }
}