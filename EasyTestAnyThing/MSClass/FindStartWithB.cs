using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EasyTestAnyThing.MSClass
{
    public class FindStartWithB
    {

        /*
             2022/01/05
             使用 C# 中的陣列及 foreach 陳述式來儲存及逐一查看資料序列

             如果假訂單識別碼是以 "B" 開頭，則將訂單識別碼列印至輸出。
         */
        private IMessageSystem _messageSystem;
        private IData _data;

        public FindStartWithB(IData data,IMessageSystem messageSystem)
        {
            _data = data;
            _messageSystem = messageSystem;
        }

        //hanway
        public void NewStartWithString(string data, char split, string startWith)
        {
            var resource = data.Split(split, ',')
                .Where(w => w.StartsWith(startWith))
                .ToList();

            _messageSystem.OutputMessage(resource);
        }

        public void FindStartWithStringMethod(string startWithString)
        {
            var data = _data.GetData();

            var fraudulentOrderIDs = SplitString(data);
            var excludeB = GetStartsWithString(fraudulentOrderIDs, startWithString);

            _messageSystem.OutputMessage(excludeB);
        }

        public string[] SplitString(string data)
        {
            return data.Split(' ', ',');
        }

        public List<string> GetStartsWithString(string[] fraudulentOrderIDs, string startsWith)
        {
            return fraudulentOrderIDs
                .Where(w => w.StartsWith(startsWith))
                .ToList();
        }
    }

    public class Data : IData
    {
        public string GetData()
        {
            return "B123 C234 A345 C15 B177 G3003 C235 B179";
        }
    }

    public interface IData 
    {
        string GetData();
    }

    public class ConsoleMessageSystem : IMessageSystem
    {
        public void OutputMessage(List<string> data)
        {
            data.ForEach(s => Console.WriteLine(s));
        }
    }
    public interface IMessageSystem
    {
        void OutputMessage(List<string> data);
    }   

    //public class FileMessageSystem : IMessageSystem
    //{
    //    private readonly string _path;

    //    public FileMessageSystem(string path)
    //    {
    //        _path = path;
    //    }

    //    public void OutputMessage(List<string> data)
    //    {
    //        File.WriteAllLines(_path, data);
    //    }
    //}




}