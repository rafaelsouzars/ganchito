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
using ganchito.Prompito.AbstractClasses;

namespace ganchito.Prompito.Classes
{
    internal class HelpCommand : AbstractAppHelpCommandBase
    {
        public override void Run(IDictionary<string, (string, ActionCommand)> receives) 
        {
            try 
            {
                if (receives != null) 
                {
                    Console.WriteLine(" [ AJUDA ]\n");
                    if (receives.Count > 0) 
                    {                        
                        foreach (var receive in receives)
                        {
                            Console.WriteLine("  {0,-10} - {1,10}\n", receive.Key, receive.Value.Item1);

                            foreach (var flag in receive.Value.Item2.Flags)
                            {
                                Console.WriteLine("\t{0,-2} {1,-12} - {2,10}\n", flag.Key, flag.Value.Item1, flag.Value.Item2);
                            }
                        }
                    }
                    else 
                    {
                        Console.WriteLine("\tNenhum comando...");
                    }
                    
                }
                else 
                {
                    throw new ArgumentNullException(nameof(receives),"Não pode ser nulo!");
                }
            }
            catch (Exception exception) 
            {
                Console.WriteLine(" [ ERROR ]\n\t{0}", exception.Message);            
            }
        }
    }
}
