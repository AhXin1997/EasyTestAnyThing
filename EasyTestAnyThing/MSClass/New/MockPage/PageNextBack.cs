using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyTestAnyThing.MSClass.New.MockPage
{
    public class PageNextBack
    {
        private readonly Data _data;
        private const int TakeData = 10;

        public PageNextBack()
        {
            _data = new Data();
        }

        public void MockUser()
        {
            var nowPage = 0;
            var dataList = new List<Video>();
            while (true)
            {
                switch (Console.ReadKey().Key)
                {
                    //TODO Show Now Page And Fix Take/Skip Bug
                    case ConsoleKey.RightArrow:
                        dataList.AddRange(NextBack(nowPage++));
                        dataList.ForEach(f => Console.WriteLine(f.VideoName+f.VideoType));

                        break;
                    case ConsoleKey.LeftArrow:
                        dataList.AddRange(NextBack(nowPage--));
                        dataList.ForEach(f => Console.WriteLine(f.VideoName + f.VideoType));
                        break;
                }
            }
        }

        public List<Video> NextBack(int nowPage)
        {
            return _data.Videos.Skip(nowPage * TakeData).Take(TakeData).ToList();
        }
    }

    public class Data
    {
        public Data()
        {
            Videos = new List<Video>
                (
                    Enumerable.Range(1, 100).Select(s => new Video
                    {
                        VideoName = $"Video_{s}",
                        VideoType = s % 3 == 0 ? "Adventure" : "Fantasy"
                    })
                );
        }

        public List<Video> Videos { get; set; }
    }

    public class Video
    {
        public string VideoName { get; set; }
        public string VideoType { get; set; }
    }
}