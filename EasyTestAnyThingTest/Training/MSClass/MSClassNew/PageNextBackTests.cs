using System.Collections.Generic;
using System.Linq;
using EasyTestAnyThing.Training.MSClass.MockPage;
using EasyTestAnyThing.Training.MSClass.MockPage.Models;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace EasyTestAnyThingTest.Training.MSClass.MSClassNew
{
    public class MockPageNextBack : PageNextBack
    {
        public MockPageNextBack(IData data) : base(data)
        {
        }

        protected override int TakeData => 2;
    }

    public class PageNextBackTests
    {
        private readonly MockPageNextBack _target;
        private readonly IData _data;

        public PageNextBackTests()
        {
            _data = Substitute.For<IData>();
            _target = new MockPageNextBack(_data);
        }

        [Fact]
        public void Take_Right_Data_When_Page_1_And_No_Query()
        {
            GivenData();

            var action = _target.GetVideos(new GetVideoRequest() { NowPage = 1 });

            action.Should().BeEquivalentTo(new
            {
                Videos = new List<Video>
                {
                        new Video
                        {
                            State = "Public",
                            UploadBy = "AhXin",
                            VideoName = "TestVideo_1",
                            VideoType = "TestFantasy",
                            VideoTime = 1
                        },
                        new Video
                        {
                            State = "Public",
                            UploadBy = "AhXin",
                            VideoName = "TestVideo_2",
                            VideoType = "TestFantasy",
                            VideoTime = 2
                        }
                },
                TotalPage = 13
            });
        }

        [Fact]
        public void Take_Right_Data_When_Page_1_And_Query_VideoName_Equal_TestVideo_5()
        {
            GivenData();

            var action = _target.GetVideos(new GetVideoRequest() { NowPage = 1, VideoName = "_15" });

            action.Should().BeEquivalentTo(new GetVideosResponse
            {
                Videos = new List<Video>
                    {
                        new Video
                        {
                            VideoName = "TestVideo_15",
                            VideoType = "TestAdventure",
                            State = "Private",
                            UploadBy = "JackChen",
                            VideoTime = 2,
                        },
                    },
                TotalPage = 1
            });
        }

        [Fact]
        public void Take_Right_Data_When_Page_1_And_No_VideoName_Is_VideoType_TestAdventure()
        {
            GivenData();

            var action = _target.GetVideos(new GetVideoRequest() { NowPage = 1, VideoType = "Adventure" });

            action.Should().BeEquivalentTo(new GetVideosResponse
            {
                Videos = new List<Video>
                {
                    new Video
                    {
                        State = "Public",
                        UploadBy = "JackChen",
                        VideoName = "TestVideo_3",
                        VideoTime = 0,
                        VideoType = "TestAdventure"
                    },
                    new Video
                    {
                        State = "Public",
                        UploadBy = "JackChen",
                        VideoName = "TestVideo_6",
                        VideoTime = 1,
                        VideoType = "TestAdventure"
                    }
                },
                TotalPage = 4
            });
        }

        [Fact]
        public void Take_Right_Data_When_Page_1_And_No_VideoName_Is_UploadBy_AhXin()
        {
            GivenData();

            var action = _target.GetVideos(new GetVideoRequest() { NowPage = 1, UploadBy = "Xin" });

            action.Should().BeEquivalentTo(new GetVideosResponse
            {
                Videos = new List<Video>
                {
                    new Video
                    {
                        State = "Public",
                        UploadBy = "AhXin",
                        VideoName = "TestVideo_1",
                        VideoTime = 1,
                        VideoType = "TestFantasy"
                    },
                    new Video
                    {
                        State = "Public",
                        UploadBy = "AhXin",
                        VideoName = "TestVideo_2",
                        VideoTime = 2,
                        VideoType = "TestFantasy"
                    }
                },
                TotalPage = 7
            });
        }

        [Fact]
        public void Take_Right_Data_When_Page_1_And_Query_State_Equal_Private()
        {
            GivenData();

            var action = _target.GetVideos(new GetVideoRequest() { NowPage = 1, State = "Private" });

            action.Should().BeEquivalentTo(new GetVideosResponse
            {
                Videos = new List<Video>
                    {
                        new Video
                        {
                            VideoName = "TestVideo_15",
                            VideoType = "TestAdventure",
                            State = "Private",
                            UploadBy = "JackChen",
                            VideoTime = 2,
                        },
                    },
                TotalPage = 1
            });
        }

        [Fact]
        public void Take_Right_Data_When_Page_1_And_No_VideoTime_More_Than_3()
        {
            GivenData();

            var action = _target.GetVideos(new GetVideoRequest() { NowPage = 1, VideoTime = 2 });

            action.Should().BeEquivalentTo(new GetVideosResponse
            {
                Videos = new List<Video>
                {
                    new Video
                    {
                        State = "Public",
                        UploadBy = "AhXin",
                        VideoName = "TestVideo_2",
                        VideoTime = 2,
                        VideoType = "TestFantasy"
                    },
                    new Video
                    {
                        State = "Public",
                        UploadBy = "AhXin",
                        VideoName = "TestVideo_4",
                        VideoTime = 4,
                        VideoType = "TestFantasy"
                    }
                },
                TotalPage = 10
            });
        }

        [Fact]
        public void Take_Right_Data_When_Page_1_And_Query_VideoType_Equal_TestAdventure_And_UploadBy_JackChen_VideoTime_MoreThan_4()
        {
            GivenData();

            var action = _target.GetVideos(
                new GetVideoRequest()
                {
                    NowPage = 1,
                    VideoType = "TestAdventure",
                    UploadBy = "JackChen",
                    VideoTime = 4
                });

            action.Should().BeEquivalentTo(new GetVideosResponse
            {
                Videos = new List<Video>
                    {
                        new Video
                        {
                            VideoName = "TestVideo_24",
                            VideoType = "TestAdventure",
                            State = "Public",
                            UploadBy = "JackChen",
                            VideoTime = 4,
                        },
                    },
                TotalPage = 1
            });
        }

        [Fact]
        public void When_Enter_Zero_Page_Return_Null()
        {
            GivenData();

            _target.GetVideos(new GetVideoRequest() { NowPage = 0 })
                .Should()
                .BeNull();
        }

        [Fact]
        public void When_Enter_Negative_Page_Return_Null()
        {
            GivenData();

            _target.GetVideos(new GetVideoRequest() { NowPage = -1 })
                .Should()
                .BeNull();
        }

        private void GivenData()
        {
            _data.Videos.Returns(new List<Video>(
                            Enumerable.Range(1, 25).Select(s => new Video
                            {
                                VideoName = $"TestVideo_{s}",
                                VideoType = s % 3 == 0 ? "TestAdventure" : "TestFantasy",
                                VideoTime = s % 3 == 0 || s % 5 == 0 ? (s * 10 / 60) : (s * 60 / 60),
                                State = s % 3 == 0 && s % 5 == 0 ? "Private" : "Public",
                                UploadBy = s % 3 == 0 || s % 5 == 0 ? "JackChen" : "AhXin"
                            }
                            )));
        }
    }
}