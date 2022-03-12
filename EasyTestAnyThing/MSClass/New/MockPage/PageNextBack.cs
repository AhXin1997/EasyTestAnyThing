using EasyTestAnyThing.MSClass.New.MockPage.MockData;
using EasyTestAnyThing.MSClass.New.MockPage.MockData.Models;
using System;
using System.Linq;

namespace EasyTestAnyThing.MSClass.New.MockPage
{
    public class PageNextBack
    {
        private readonly IData _data;
        private const int TakeData = 10;

        public PageNextBack(IData data)
        {
            _data = data;
        }

        /// <summary>
        /// 依搜尋條件,搜尋相應的資料,且含分頁功能
        /// 顯示符合這些資訊的總頁數及資料
        /// </summary>
        public GetVideosResponse GetVideos(GetVideoRequest request)
        {
            var videos = SetQuery(request);
            var totalPage = (int)Math.Ceiling(videos.Count() / (float)TakeData);

            if (request.NowPage > totalPage || request.NowPage <= 0)
            {
                return null;
            }

            return new GetVideosResponse()
            {
                Videos = videos.Skip((request.NowPage - 1) * TakeData).Take(TakeData).ToList(),
                TotalPage = totalPage
            };
        }

        private IQueryable<Video> SetQuery(GetVideoRequest request)
        {
            var videos = _data.Videos.AsQueryable();
            if (!string.IsNullOrWhiteSpace(request.VideoName))
            {
                videos = videos.Where(w => w.VideoName.Contains(request.VideoName));
            }
            if (!string.IsNullOrWhiteSpace(request.VideoType))
            {
                videos = videos.Where(w => w.VideoType.Contains(request.VideoType));
            }
            if (!string.IsNullOrWhiteSpace(request.UploadBy))
            {
                videos = videos.Where(w => w.UploadBy.Contains(request.UploadBy));
            }
            if (!string.IsNullOrWhiteSpace(request.State))
            {
                videos = videos.Where(w => w.State.Contains(request.State));
            }
            if (request.VideoTime != null)
            {
                videos = videos.Where(w => w.VideoTime >= request.VideoTime);
            }

            return videos;
        }
    }


}