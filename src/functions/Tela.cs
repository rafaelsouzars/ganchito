using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ganchito.src.functions
{
    class Tela
    {
        public static void Sobre(string programName, string versionNumber, string description, string urlProfile, string urlRepositorie )
        {
            // Expressões regulares para validação dos parametros do método.
            Regex versionNumberRegex = new Regex(@"^v(\d\.){2,2}(\d)$");
            Regex urlProfileRegex = new Regex(@"^(http|https)\:\/\/([a-z0-9]+)\.(github\.io|io|me|tech|cc|com|net)(\/[a-z0-9]+)?$");
            Regex urlRepositorieRegex = new Regex(@"^(http|https)\:\/\/([a-z0-9]+)\.(github\.io|io|me|tech|cc|com|net)(\/[a-z0-9]+){2,2}$");

            try
            {
                // Verifica se o parametro 'programName' foi inserido.
                if (programName is null or "")
                {
                    throw new ArgumentException("Parametro nulo", nameof(programName));
                }

                // Verifica a inserção e valida o parametro 'versionNumber'.
                if (versionNumber is null or "") 
                {
                    throw new ArgumentException("Parametro nulo", nameof(versionNumber));
                }
                else if (!versionNumberRegex.IsMatch(versionNumber))
                {
                    throw new ArgumentException("Numero de versão inválido", nameof(versionNumber));
                }

                // Verifica a inserção e valida o parametro 'urlProfile'
                if (!(urlProfile is null or ""))
                {
                    if (!urlProfileRegex.IsMatch(urlProfile))
                    {
                        throw new ArgumentException("URL inválida", nameof(urlProfile));
                    }
                }


                // Verifica a inserção e valida o parametro 'urlRepositorie'
                if (!(urlRepositorie is null or ""))
                {
                    if (!urlRepositorieRegex.IsMatch(urlRepositorie))
                    {
                        throw new ArgumentException("URL inválida", nameof(urlRepositorie));
                    }
                }
                

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }     

            LetraConsole.IniciarAlfabeto();
            LetraConsole.DrawString($"{programName}");

            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine($"{programName} {versionNumber}");
            Console.WriteLine($"{description}");
            Console.WriteLine($"Dev: {urlProfile}");
            Console.WriteLine($"Repositório: {urlRepositorie}");
            Console.WriteLine("----------------------------------------------------------------------------\n\n");
        }
    }
}
