using EasyTestAnyThing.MSClass.New.CharReverse;
using FluentAssertions;
using Xunit;

namespace EasyTestAnyThingTest.MSClass.New.CharReverse
{
    public class NewCharReverseTests
    {
        private readonly NewCharReverse _target;

        public NewCharReverseTests()
        {
            _target = new NewCharReverse();
        }

        [Fact]
        public void Assert_Sentence_Reverse()
        {
            _target
                .ReverseLogic("The quick brown fox jumps over the lazy dog", ' ')
                .Should()
                .Be("ehT kciuq nworb xof spmuj revo eht yzal god");
        }

        [Fact]
        public void Assert_Word_Reverse_Split_With_Blank()
        {
            _target
                .ReverseLogic("Good Night", ' ')
                .Should()
                .Be("dooG thgiN");
        }

        [Fact]
        public void Assert_Word_Reverse_Split_With_Comma()
        {
            _target
                .ReverseLogic("Good,Day", ',')
                .Should()
                .Be("dooG yaD");
        }
    }
}