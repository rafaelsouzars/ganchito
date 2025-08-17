using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ganchito.Prompito.Classes;

namespace ganchito.Prompito.Interfaces
{
    interface IExecuter
    {

        public bool DEBUG_MODE { get; set; }
        public void Init() 
        {
            
        }

        public void InsertAppData(AppData appData) 
        {
        
        }

        public void ExecuteCommand(string[] args) 
        {
            // Implementation
        }

        public void AddCommand(string commandName, ActionCommand newCommand)
        {

        }

        public void AddCommand(string commandName, string description, ActionCommand newCommand) 
        {
            
        }

        public void ScreenAbout(bool activeScreen) 
        {
            
        }
    }
}
