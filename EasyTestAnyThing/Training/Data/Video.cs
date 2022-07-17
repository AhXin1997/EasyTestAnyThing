using System;

namespace EasyTestAnyThing.Training.Data
{
    public class Video
    {
        public string Name { get; set; }
        public VideoType Type { get; set; }
        public bool IsPublic { get; set; }
        public string UploadBy { get; set; }
        public DateTime Time { get; set; }
    }
}