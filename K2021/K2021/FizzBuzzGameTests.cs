using Xunit;

namespace K2021
{
    public class FizzBuzzGameTests
    {
        private readonly FizzBuzzGame _game;

        public FizzBuzzGameTests()
        {
            _game = new FizzBuzzGame();
        }

        [Fact]
        public void When_play_1_should_return_1()
        {
            var result = _game.Play(1);
            Assert.Equal("1", result);
        }

        [Fact]
        public void When_play_3_should_return_Fizz()
        {
            var result = _game.Play(3);
            Assert.Equal("Fizz", result);
        }

        [Fact]
        public void When_play_5_should_return_Buzz()
        {
            var result = _game.Play(5);
            Assert.Equal("Buzz", result);
        }

        [Fact]
        public void When_play_15_should_return_Fizz_Buzz()
        {
            var result = _game.Play(15);
            Assert.Equal("Fizz Buzz", result);
        }
    }
}
