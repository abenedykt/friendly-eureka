namespace PizzaApp
{
    public class NullableCommand : ICommand<object, object>
    {
        public bool CanExecute(object parameters)
        {
            return true;
        }

        public object Execute(object parameters)
        {
            return new object();
        }
    }
}
