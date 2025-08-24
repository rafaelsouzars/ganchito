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

                if (args.Length == 1) 
                {
                    if (hookFiles.GitHookDirectoryExist())
                    {
                        hookFiles.CreateHookFile();
                    } 
                }
                else if (args.Length == 2) 
                {
                    if (string.Equals(args[1],"-r")) 
                    {
                        hookFiles.CreateHookFile(hookFiles.CreateFileRepositorieStream()); 
                    }
                    else 
                    {
                        throw new ArgumentException("Argumento não reconhecido: ", args[1]);
                    }
                }
                else if (args.Length > 2) 
                {
                    throw new ArgumentException("Argumentos não reconhecidos: ", args.ToString());
                }
                                
               
            }
            catch (Exception exception) 
            {
                Console.WriteLine(" [ ERROR ]\n\t{0}",exception.Message);
            }
        }
    }
}
