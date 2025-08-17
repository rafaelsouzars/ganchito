/*
 *
 *   PROMPITO CLI
 *
 *   NAME: Executer.cs
 *
 *   VERSION: 1.0.0
 *
 *   DESCRIPTION: Esta classe é responsável por (...).
 *
 *   AUTHOR: Rafael Souza
 *
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ganchito.Prompito.Interfaces;
using ganchito.Prompito.Classes;
using ganchito.Prompito.ConsoleScreen;
using ganchito.Prompito.ActionCommands;

namespace ganchito.Prompito
{

    class Executer : IExecuter
    {        
        private static object _appData;
        private static bool _DEBUG_MODE = false;
        private static Dictionary<string,(string,ActionCommand)> _receives = new Dictionary<string,(string, ActionCommand)>();

        public bool DEBUG_MODE { get => _DEBUG_MODE; set { _DEBUG_MODE = value; } }

        public Executer ()
        {
            
        }
        

        private static void DebugMode(string message)
        {
            if (_DEBUG_MODE)
            {
                Console.WriteLine($" [ DEBUG MODE ON ]\n\t{message}\n");
            }
        }

        private void Init() 
        {
            var p = new Program();
            this.AddCommand(p.ToString().Replace(".Program",""),"",new ActionGanchito());            
        }

        public void InsertAppData(object appData)          
        {
            try
            {                
                _appData = appData ?? throw new ArgumentNullException("O ProgramData não pode ser nulo", nameof(appData));

                var appName = _appData?.GetType().GetProperty("AppName")?.GetValue(_appData);
                var version = _appData?.GetType().GetProperty("Version")?.GetValue(_appData);
                var description = _appData?.GetType().GetProperty("Description")?.GetValue(_appData);
                var profileURL = _appData?.GetType().GetProperty("ProfileURL")?.GetValue(_appData);
                var repositorieURL = _appData?.GetType().GetProperty("RepositorieURL")?.GetValue(_appData);                

                Screen.About(new AppData((string)appName, (string)version, (string)description, (string)profileURL, (string)repositorieURL));
                                
                DebugMode($"AppName: {appName}, Version: {version}, Description: {description}, Profile: {profileURL}, Repositorie: {repositorieURL}");
                
            }
            catch (Exception exception)
            {
                Console.WriteLine("ERROR: {0}", exception);
            }
        }

        public void ExecuteCommand(string[] args) 
        {
            try 
            {                
                if (args.Length >= 1)
                {
                    if (_receives.Keys.Contains<string>(args[0]))
                    {
                        if (_receives.TryGetValue(args[0], out (string, ActionCommand) receiver))
                        {
                            var command = new Command<ActionCommand>(receiver.Item2, r => r.Run(args));
                            command.Execute();
                        }
                    }
                    else 
                    {
                        throw new ArgumentException("\tMessage: Commando não reconhecido\n");    
                    }
                                            
                }                               
                
            }
            catch (Exception exception) 
            {
                Console.WriteLine(exception);
            }
            
        }

        public void AddCommand(string commandName, ActionCommand newCommand)
        {
            _receives.Add(commandName, ("", newCommand));
        }

        public void AddCommand (string commandName , string description , ActionCommand newCommand) 
        {
            _receives.Add(commandName, ( description, newCommand ));
        }

        public void ScreenAbout (bool activeScreen) 
        {
            Screen.ActiveScreenLetter = activeScreen;
        }

    }
}
    

