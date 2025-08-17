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
using System.IO;
using ganchito.Prompito.Classes;
using ganchito.src.Hooks.Classes;


namespace ganchito.Prompito.ActionCommands
{
    class ActionGanchito : ActionCommand
    {

        public override void Run(string[] args)
        {            
            try
            {       
                var hookFiles = new HookFiles();

                if (hookFiles.GitHookDirectoryExist())
                {
                    hookFiles.CreateHookFile();
                }                
               
            }
            catch (Exception exception) 
            {
                Console.WriteLine("ERROR: {0}",exception);
            }
        }
    }
}
