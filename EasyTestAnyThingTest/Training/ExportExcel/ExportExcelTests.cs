using EasyTestAnyThing.Training.Data;
using EasyTestAnyThing.Training.ExportExcel;
using NSubstitute;
using System;
using System.Collections.Generic;
using Xunit;

namespace EasyTestAnyThingTest.Training.ExportExcel
{
    public class ExportExcelTests
    {
        private readonly EasyTestAnyThing.Training.ExportExcel.ExportExcel _target;
        private IData _data;

        public ExportExcelTests()
        {
            _data = Substitute.For<IData>();
            _target = new EasyTestAnyThing.Training.ExportExcel.ExportExcel(_data);
        }

        [Fact(Skip = "")]
        public void Export()
        {
            _data.Videos.Returns(new List<Video>()
            {
                new Video()
                {
                    Name = "Horror01",
                    IsPublic = true,
                    Type = VideoType.Horror,
                    Time = new DateTime(2022, 7, 15, 09, 15, 30),
                    UploadBy = "AhXin"
                },
                new Video()
                {
                    Name = "Horror02",
                    IsPublic = true,
                    Type = VideoType.Adventure,
                    Time = new DateTime(2022, 7, 12, 15, 30, 30),
                    UploadBy = "AhXin"
                }
            });

            _target.Export(new ExportExcelRequest()
            {
                Type = VideoType.Adventure
            });
        }
    }
}