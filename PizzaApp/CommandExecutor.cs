using System;
using System.Diagnostics;

namespace PizzaApp
{
    public class CommandExecutor
    {
        public void Execute(ICommand command)
        {
            if(command != null)
            {
                if (command.CanExecute())
                {
                    var start = new Stopwatch();
                    try
                    {
                        command.Execute();
                    }
                    catch (Exception e)
                    {
                        // log exceptions
                        // nlog (?)
                        // Microsoft.Logging
                        // -> serilog
                    }


                    var elapsed = start.ElapsedMilliseconds;
                    // log -> command.GetType() + elapsed
                }
            }
        }
    }
}
