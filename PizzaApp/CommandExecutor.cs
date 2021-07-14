using System;

namespace PizzaApp
{
    public class CommandExecutor
    {
        public TResult Execute<TParam, TResult>(ICommand<TParam,TResult> command, TParam parameters)
        {
            if(command != null)
            {
                if (command.CanExecute(parameters))
                {
                    try
                    {
                        return command.Execute(parameters);
                    }
                    catch (Exception e)
                    {
                        // log exceptions
                        // nlog (?)
                        // Microsoft.Logging
                        // -> serilog
                    }
                }
            }

            return default;  // to tak nie powinno wyglądać
        }
    }





    //public interface ICommandExecutor
    //{
    //    TResult Execute<TParam, TResult>(ICommand<TParam, TResult> command, TParam param);
    //}
}
