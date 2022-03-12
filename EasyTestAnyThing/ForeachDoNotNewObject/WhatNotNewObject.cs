using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyTestAnyThing.ForeachDoNotNewObject
{

    public class WhatNotNewObject
    {
        /// <summary>
        /// 探討一樣的效果,為什麼不能在 Foreach 內新增物件.
        /// </summary>
        /// <param name="isNewOnLoop">是否在迴圈內新增物件</param>
        public void Start(bool isNewOnLoop)
        {
            switch (isNewOnLoop)
            {
                case true:
                    OnLoop();
                    break;

                case false:
                    NotOnLoop();
                    break;
            }
        }

        public void OnLoop()
        {
            long beforeNewObjectMemory;
            long afterNewObjectMemory;
            var recordUsage = new List<int>();
            foreach (var item in Enumerable.Range(1, 100))
            {
                beforeNewObjectMemory = GetMemory("1");
                var myObject = new List<int>(item);
                myObject.Clear();
                afterNewObjectMemory = GetMemory("2");

                var getThisTimeUsageMemory =
                    GetAndShowThisTimeUsageMemory(afterNewObjectMemory, beforeNewObjectMemory);

                recordUsage.Add((int)(getThisTimeUsageMemory));
            }
            Console.WriteLine("Total Usage Memory - {0}", recordUsage.Sum() - recordUsage.First());
        }

        public void NotOnLoop()
        {
            var myObject = new List<int>();
            long beforeNewObjectMemory;
            long afterNewObjectMemory;
            var recordUsage = new List<int>();
            foreach (var item in Enumerable.Range(1, 100))
            {
                beforeNewObjectMemory = GetMemory("1");
                myObject.Add(item);
                myObject.Clear();
                afterNewObjectMemory = GetMemory("2");
                var getThisTimeUsageMemory = 
                    GetAndShowThisTimeUsageMemory(afterNewObjectMemory,beforeNewObjectMemory);
                
                recordUsage.Add((int)(getThisTimeUsageMemory));
            }
            Console.WriteLine("Total Usage Memory - {0}", recordUsage.Sum() - recordUsage.First());
        }

        private long GetAndShowThisTimeUsageMemory(long afterNewObjectMemory, long beforeNewObjectMemory)
        {
            var thisTimeUsageMemory = afterNewObjectMemory - beforeNewObjectMemory;
            Console.WriteLine("Once loop Use Memory - {0}", thisTimeUsageMemory);
            return thisTimeUsageMemory;
        }

        private long GetMemory(string message)
        {
            var memory = GC.GetTotalMemory(true);
            Console.WriteLine("{0} - {1}",message, memory);
            return memory;
        }
    }
}