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
                }
            }
        }
    }
}
