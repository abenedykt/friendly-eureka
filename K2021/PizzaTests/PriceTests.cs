using Pizza;
using Xunit;

namespace PizzaTests
{
    public class PriceTests
    {
        [Fact]
        public void When_price_is_lower_than_zero_should_throw_exception_invalid_value()
        {
            Assert.Throws<InvalidPriceValueException>(()=> new Price(-10));
        }
    }
}