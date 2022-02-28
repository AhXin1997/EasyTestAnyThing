using System.Collections.Generic;
using System.Linq;

namespace EasyTestAnyThing.MSClass
{
    public class MockPageNextAndBack
    {
        /*
            2022/01/07

            模擬網頁頁面前後跳轉
            每次只顯示兩筆資料
        */

        private IMessageSystem _messageSystem;
        private IPageData _pageData;
        private int page;

        public MockPageNextAndBack(IPageData pageData, IMessageSystem messageSystem)
        {
            _messageSystem = messageSystem;
            _pageData = pageData;
        }

        public void MockPage(PageButton pageButton)
        {
            //int page;
            List<string> getData;
            try
            {
                getData = _pageData.GetData();
            }
            catch (System.Exception)
            {
                getData = new List<string>()
                {
                    "2","3","4","5"
                };
            }

            var outputData = new List<string>();
            switch (pageButton)
            {
                case PageButton.Next:
                    page++;
                    outputData = getData.Skip((page - 1) * 2)
                        .Take(2).OrderBy(o => o).ToList();
                    break;

                case PageButton.Back:
                    if (page >= 1)
                    {
                        page--;
                        outputData = getData.Skip((page - 1) * 2)
                            .Take(2).OrderBy(o => o).ToList();
                    }
                    break;

                default:
                    break;
            }

            _messageSystem.OutputMessage(outputData);
        }

        public class PageData : IPageData
        {
            public List<string> GetData()
            {
                return new List<string>
                {
                    "data1",
                    "data2",
                    "data3",
                    "data4",
                    "data5",
                    "data6",
                    "data7",
                    "data8",
                    "data9",
                    "data10"
                };
            }
        }


    }
    public enum PageButton
    {
        Next,
        Back
    }

    public interface IPageData
    {
        List<string> GetData();
    }
}