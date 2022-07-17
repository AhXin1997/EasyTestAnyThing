using System;
using EasyTestAnyThing.Training.Data;

namespace EasyTestAnyThing.Training.ExportExcel
{
    public class ExportExcelRequest
    {
        public string Name { get; set; }
        public VideoType? Type { get; set; }
        public bool IsPublic { get; set; }
        public string UploadBy { get; set; }
        
        //public DateTime Time { get; set; }
    }
}