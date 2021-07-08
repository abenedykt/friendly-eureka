using Xunit;

namespace K2021
{
    public class FizzBuzzGameTests_v2
    {
        [Theory,
        InlineData(1, "1"),
        InlineData(2, "2"),
        InlineData(3, "Fizz"),
        InlineData(4, "4"),
        InlineData(5, "Buzz"),
        InlineData(9, "Fizz"),
        InlineData(10, "Buzz"),
        InlineData(12, "Fizz"),
        InlineData(15, "Fizz Buzz"),
        InlineData(30, "Fizz Buzz"),
        InlineData(45, "Fizz Buzz")
        ]
        public void Should_return_values_according_to_fizz_buzz_game_rules(ushort value, string exected)
        {
            var game = new FizzBuzzGame();
            var actual = game.Play(value);
            Assert.Equal(exected, actual);
        }

        // AAA 

        // Arrange -> przygotowujemy dane/obiekty
        // Act -> SUT -> system under test -> akcja testowana
        // Assert -> sprawdzenie


        // correct_value
        // as_expected
        // expected
        // good_value
    }
}
