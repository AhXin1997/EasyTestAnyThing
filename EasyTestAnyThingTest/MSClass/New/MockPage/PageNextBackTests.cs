using EasyTestAnyThing.MSClass.New.MockPage;
using FluentAssertions;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace EasyTestAnyThingTest.MSClass.New.MockPage
{
    public class PageNextBackTests
    {
        private readonly PageNextBack _target;
        private readonly IData _data;

        public PageNextBackTests()
        {
            _data = Substitute.For<IData>();
            _target = new PageNextBack(_data);
        }

        [Fact]
        public void TakeRightData()
        {
            GivenData();

            var action = _target.GetVideos(1);

            action.Videos.Count.Should().Be(10);

            action.Should().BeEquivalentTo(new GetVideosResponse
            {
                Videos = new List<Video>
                    {
                        new Video{VideoName = "TestVideo_1", VideoType = "TestFantasy" },
                        new Video{VideoName = "TestVideo_2", VideoType = "TestFantasy" },
                        new Video{VideoName = "TestVideo_3", VideoType = "TestAdventure" },
                        new Video{VideoName = "TestVideo_4", VideoType = "TestFantasy" },
                        new Video{VideoName = "TestVideo_5", VideoType = "TestFantasy" },
                        new Video{VideoName = "TestVideo_6", VideoType = "TestAdventure" },
                        new Video{VideoName = "TestVideo_7", VideoType = "TestFantasy" },
                        new Video{VideoName = "TestVideo_8", VideoType = "TestFantasy" },
                        new Video{VideoName = "TestVideo_9", VideoType = "TestAdventure" },
                        new Video{VideoName = "TestVideo_10", VideoType = "TestFantasy" },
                    },
                TotalPage = 3
            });
        }

        [Fact]
        public void Thow_Error_When_Enter_Out_Range_Page()
        {
            GivenData();

            _target.Invoking(i => i.GetVideos(0))
                .Should()
                .Throw<ArgumentOutOfRangeException>();

        }

        private void GivenData()
        {
            _data.Videos.Returns(new List<Video>(
                            Enumerable.Range(1, 25).Select(s => new Video
                            {
                                VideoName = $"TestVideo_{s}",
                                VideoType = s % 3 == 0 ? "TestAdventure" : "TestFantasy"
                            })));
        }
    }
}