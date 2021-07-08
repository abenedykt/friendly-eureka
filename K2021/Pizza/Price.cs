using System;

namespace Pizza
{
    public class Price
    {
        public Price(decimal value)
        {
            if (value < 0) throw new InvalidPriceValueException();

            Value = value;
        }

        public decimal Value { get; }
    }

    public class InvalidPriceValueException : Exception
    {
    }
}