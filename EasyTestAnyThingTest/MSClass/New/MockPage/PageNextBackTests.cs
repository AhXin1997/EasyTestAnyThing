using EasyTestAnyThing.MSClass.New.MockPage;
using Xunit;
using Xunit.Abstractions;

namespace EasyTestAnyThingTest.MSClass.New.MockPage
{
    public class PageNextBackTests
    {
        private readonly PageNextBack _target;
        private readonly Data _data;
        private readonly ITestOutputHelper _testOutputHelper;

        public PageNextBackTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            _target = new PageNextBack();
            _data = new Data();
        }

        [Fact]
        public void Test()
        {
            foreach (var item in _data.Videos)
            {
                _testOutputHelper.WriteLine(item.VideoName + item.VideoType);
            }
        }
    }
}