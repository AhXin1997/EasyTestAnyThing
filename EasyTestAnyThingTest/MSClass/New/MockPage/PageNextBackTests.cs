using EasyTestAnyThing.MSClass.New.MockPage;
using EasyTestAnyThing.MSClass.New.MockPage.MockData;
using EasyTestAnyThing.MSClass.New.MockPage.MockData.Models;
using FluentAssertions;
using NSubstitute;
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
        public void Take_Right_Data_When_Page_1_And_No_Query()
        {
            GivenData();

            var action = _target.GetVideos(new GetVideoRequest() {NowPage = 1});

            action.Videos.Count.Should().Be(10);

            action.Should().BeEquivalentTo(new
            {
                Videos = new[]
                    {
                        new {VideoName = "TestVideo_1", VideoType = "TestFantasy" },
                        new {VideoName = "TestVideo_2", VideoType = "TestFantasy" },
                        new {VideoName = "TestVideo_3", VideoType = "TestAdventure" },
                        new {VideoName = "TestVideo_4", VideoType = "TestFantasy" },
                        new {VideoName = "TestVideo_5", VideoType = "TestFantasy" },
                        new {VideoName = "TestVideo_6", VideoType = "TestAdventure" },
                        new {VideoName = "TestVideo_7", VideoType = "TestFantasy" },
                        new {VideoName = "TestVideo_8", VideoType = "TestFantasy" },
                        new {VideoName = "TestVideo_9", VideoType = "TestAdventure" },
                        new {VideoName = "TestVideo_10", VideoType = "TestFantasy" },
                    },
                TotalPage = 3
            });
        }

        [Fact]
        public void Take_Right_Data_When_Page_1_And_Query_VideoName_Equal_TestVideo_5()
        {
            GivenData();

            var action = _target.GetVideos(new GetVideoRequest() { NowPage = 1 , VideoName = "_15"});

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
        public void Take_Right_Data_When_Page_1_And_Query_VideoType_Equal_TestAdventure_And_UploadBy_JackChen_VideoTime_MoreThan_4()
        {
            GivenData();

            var action = _target.GetVideos(
                new GetVideoRequest() { 
                    NowPage = 1, 
                    VideoType = "TestAdventure" ,
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
        public void Thow_Error_When_Enter_Zero_Page()
        {
            GivenData();

            _target.GetVideos(new GetVideoRequest() {NowPage = 0 })
                .Should()
                .BeNull();
        }

        [Fact]
        public void Thow_Error_When_Enter_Negative_Page()
        {
            GivenData();

            _target.GetVideos(new GetVideoRequest() {NowPage = -1 })
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
                            })));
        }
    }
}