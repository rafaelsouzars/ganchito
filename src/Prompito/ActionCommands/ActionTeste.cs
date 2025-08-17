using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ganchito.Prompito.Classes;
using ganchito.src.Hooks.Classes;

namespace ganchito.Prompito.ActionCommands
{
    class ActionTeste : ActionCommand
    {       

        override public void Run(string[] args) 
        {
            if (args.Length == 2)
            {
                Console.WriteLine("Arg2: {0}", args[1]);
            }
            Console.WriteLine("Faz outra coisa");
        }
    }
}
