using EasyTestAnyThing.MSClass.New.MockPage.Models;
using System.Collections.Generic;

namespace EasyTestAnyThing.MSClass.New.MockPage
{
    public class GetVideosResponse
    {
        public List<Video> Videos { get ; set; }

        public int TotalPage { get; set; }
    }
}