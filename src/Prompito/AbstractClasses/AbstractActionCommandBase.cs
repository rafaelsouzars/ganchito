/*
 * 
 * Ganchito
 * Version: v1.0.0
 * Description: Utilitário de git hooks
 * Author: rafaelsouzars
 * Github: https://github.com/rafaelsouzars
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ganchito.Prompito.AbstractClasses
{
    public abstract class AbstractActionCommandBase
    {        
        protected bool _DEBUG = false;

        
        public bool DEBUG { get => _DEBUG; set { _DEBUG = value; } }
        

        abstract public void Run();

        abstract public void Run(string[] args);

        public void Help(string appName, string description)
        {
            Console.WriteLine("[ {0} ]\n\tDescrição: {1}", appName, description);
        }

    }
}
