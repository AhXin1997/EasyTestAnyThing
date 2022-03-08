using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyTestAnyThing.MSClass.New.MockPage
{
    public class PageNextBack
    {
        private readonly Data _data;

        public PageNextBack() 
        {
            _data = new Data();
        }

        public List<Video> NextBack() 
        {
            var takeDatas = 10;
            var nowPage = 0;

            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.LeftArrow:
                    nowPage++;
                    return _data.Videos.Skip((nowPage * takeDatas) - takeDatas).Take(takeDatas).ToList();
                case ConsoleKey.RightArrow:
                    nowPage--;
                    return _data.Videos.Skip(nowPage * takeDatas).Take(takeDatas).ToList();
                default:
                    break;
            }
            return _data.Videos.Take(10).Skip(0).ToList();
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