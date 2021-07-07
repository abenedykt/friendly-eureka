namespace K2021
{
    public class FizzBuzzGame
    {
        public string Play(ushort value)
        {
            if (Divisible_by_15(value)) return "Fizz Buzz";
            if (Divisible_by_5(value)) return "Buzz";
            if (Divisible_by_3(value)) return "Fizz";

            return Default(value);
        }

        private static string Default(ushort value)
        {
            return value.ToString();
        }

        private static bool Divisible_by_3(ushort value)
        {
            return Divisible(value, 3);
        }

        private static bool Divisible_by_5(ushort value)
        {
            return Divisible(value, 5);
        }

        private static bool Divisible_by_15(ushort value)
        {
            return Divisible(value, 15);
        }

        private static bool Divisible(ushort value, ushort divisor)
        {
            return value % divisor == 0;
        }
    }
}