using System.Collections.Generic;
using EasyTestAnyThing.MSClassNew.MockPage.Models;

namespace EasyTestAnyThing.MSClassNew.MockPage
{
    public class GetVideosResponse
    {
        public List<Video> Videos { get ; set; }

        public int TotalPage { get; set; }
    }
}