using EasyTestAnyThing.MSClass.New.MockPage.MockData.Models;
using System.Collections.Generic;
using System.Linq;

namespace EasyTestAnyThing.MSClass.New.MockPage.MockData
{
    public class MockVideoData
    {
        public class Data : IData
        {
            public Data()
            {
                Videos = new List<Video>
                    (
                        Enumerable.Range(1, 105).Select(s => new Video
                        {
                            VideoName = $"Video_{s}",
                            VideoType = s % 3 == 0 ? "Adventure" : "Fantasy",
                            VideoTime = s % 3 == 0 || s % 5 == 0 ? (s * 10 / 60) : (s * 60 / 60),
                            State = s % 3 == 0 && s % 5 == 0 ? "Private" : "Public",
                            UploadBy = s % 3 == 0 || s % 5 == 0 ? "JackChen" : "AhXin"
                        })
                    );
            }

            public List<Video> Videos { get; set; }
        }
    }
}