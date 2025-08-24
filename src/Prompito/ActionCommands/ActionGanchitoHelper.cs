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
using ganchito.Prompito.Classes;

namespace ganchito.Prompito.ActionCommands
{
    class ActionGanchitoHelper : ActionCommand
    {
        public override void Run(string[] args)
        {
            Console.WriteLine(" [ AJUDA ]\n");
            Console.WriteLine("\tcommit - Cria o hook 'commit-msg' no diretorio '.git' do projeto.\n");
            Console.WriteLine("\t    -r - Usa o script do repositório 'https://github.com/rafaelsouzars/githook-semantic-inspect-script'.\n\n");
            Console.WriteLine("\thelp   - Abre a ajuda do programa.\n");
        }
    }
}
