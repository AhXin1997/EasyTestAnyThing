using System.Collections.Generic;
using EasyTestAnyThing.Training.MSClass.MockPage.Models;

namespace EasyTestAnyThing.Training.MSClass.MockPage
{
    public class GetVideosResponse
    {
        public List<Video> Videos { get ; set; }

        public int TotalPage { get; set; }
    }
}