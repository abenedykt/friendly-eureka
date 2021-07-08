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


        public static implicit operator decimal(Price price)
        {
            return price.Value;
        }

        public static implicit operator Price(decimal value)
        {
            return new Price(value);
        }
    }

    public class InvalidPriceValueException : Exception
    {
    }
}