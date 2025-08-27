/*
 * 
 * Ganchito
 * Version: v1.1.0
 * Description: Utilitário de git hooks
 * Author: rafaelsouzars
 * Github: https://github.com/rafaelsouzars
 * 
 */
using System;


namespace ganchito.Prompito.AbstractClasses
{
    public abstract class AbstractActionCommandBase
    {        
        protected bool _DEBUG = false;        

        public bool DEBUG { get => _DEBUG; set { _DEBUG = value; } }        

        protected AbstractActionCommandBase() { }

        protected AbstractActionCommandBase(string[] args) {  }

        abstract public void Run();

        abstract public void Run(string[] args);

        virtual public void Help(string appName, string description)
        {
            Console.WriteLine("[ {0} ]\n\tDescrição: {1}", appName, description);
        }

    }
}
