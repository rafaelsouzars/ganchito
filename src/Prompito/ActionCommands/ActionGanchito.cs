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

        public ActionGanchito()
        {            
            AddFlag(
                "-r",
                "--repo-hook",
                "Criar hook a partir de repositório de script"                
                );

            AddFlag(
                "-h",
                "--help",
                "Ajuda do comando"
                );
        }

        public override void Run(string[] args)
        {            
            try
            {
                InitArgumentsMapper(args);
                var hookFiles = new HookFiles();
                Console.WriteLine("Teste do get Arg: {0}", Arg.Count);

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
