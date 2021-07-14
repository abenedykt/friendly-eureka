namespace PizzaApp
{
    // v1
    //public interface ICommand
    //{
    //    bool CanExecute();
    //    void Execute();
    //}


    // v2
    public interface ICommand<TParam, TResult>
    {
        bool CanExecute(TParam parameters);
        TResult Execute(TParam parameters);
    }
}
