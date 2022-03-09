using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyTestAnyThing.MSClass.New.MockPage
{
    public class PageNextBack
    {
        private readonly IData _data;
        private const int TakeData = 10;
        private const string OutputVideoFormat = "Video : {0} \tType :{1}";
        private const string OutputPageFormat = "Page {0}/{1}";

        public PageNextBack(IData data)
        {
            _data = data;
        }

        /// <summary>
        /// 此 StartMethod 模擬 Front-End 使用情況。
        /// 輸入頁數後取得該頁數的 TakeData 數資料.
        /// </summary>
        public void StartMethod()
        {
            while (true)
            {
                Console.WriteLine("EnterPage");
                var userInput = Console.ReadLine();
                if (int.TryParse(userInput, out var userPage) && userPage != 0)
                {
                    var data = GetVideos(userPage);
                    data.Videos.ForEach(f =>
                        Console.WriteLine(OutputVideoFormat, f.VideoName, f.VideoType)
                    );
                    Console.WriteLine(OutputPageFormat, userPage, data.TotalPage);
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        public GetVideosResponse GetVideos(int nowPage)
        {
            int totalPage = (int)Math.Ceiling(_data.Videos.Count / (float)TakeData);
            if (nowPage <= totalPage && nowPage != 0)
            {
                return new GetVideosResponse
                {
                    Videos = _data.Videos.Skip((nowPage - 1) * TakeData).Take(TakeData).ToList(),
                    TotalPage = totalPage
                };
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }

    public class GetVideosResponse 
    {
        public List<Video> Videos { get; set; }

        public int TotalPage { get; set; }
    }

    public class Data : IData
    {
        public Data()
        {
            Videos = new List<Video>
                (
                    Enumerable.Range(1, 105).Select(s => new Video
                    {
                        VideoName = $"Video_{s}",
                        VideoType = s % 3 == 0 ? "Adventure" : "Fantasy"
                    })
                );
        }

        public List<Video> Videos { get; set; }
    }

    public interface IData
    {
        List<Video> Videos { get; set; }
    }

    public class Video
    {
        public string VideoName { get; set; }
        public string VideoType { get; set; }
    }
}