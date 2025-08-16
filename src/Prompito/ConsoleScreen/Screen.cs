using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ganchito.Prompito.Classes;

namespace ganchito.Prompito.ConsoleScreen
{
    class Screen
    {
        private static AppData _appData;
        private static bool _activeScreenLetter = true;

        public static bool ActiveScreenLetter { get => _activeScreenLetter; set { _activeScreenLetter = value; } }
        

        public static void About(AppData appData)
        {           

            try
            {
                _appData = appData;

                Regex versionNumberRegex = new Regex(@"^v(\d\.){2,2}(\d)$");
                Regex urlProfileRegex = new Regex(@"^(http|https)\:\/\/([a-z0-9]+)\.(github\.io|io|me|tech|cc|com|net)(\/[a-z0-9]+)?$");
                Regex urlRepositorieRegex = new Regex(@"^(http|https)\:\/\/([a-z0-9]+)\.(github\.io|io|me|tech|cc|com|net)(\/[a-z0-9]+){2,2}$");                

                // Verifica a inserção e valida o parametro 'versionNumber'.
                if (!string.IsNullOrWhiteSpace(_appData.GetVersionNumber))
                {
                    if (!versionNumberRegex.IsMatch(_appData.GetVersionNumber))
                    {
                        throw new ArgumentException("A sintaxe do 'Numero de Versão' é inválida. Exemplo: 'v1.2.3'\nArgumento:", nameof(_appData.GetVersionNumber));
                    }
                }

                // Verifica a inserção e valida o parametro 'urlProfile'
                if (!string.IsNullOrWhiteSpace(_appData.GetDescription))
                {

                }

                // Verifica a inserção e valida o parametro 'urlProfile'
                if (!string.IsNullOrWhiteSpace(_appData.GetProfileURL))
                {
                    if (!urlProfileRegex.IsMatch(_appData.GetProfileURL))
                    {
                        throw new ArgumentException("A syntaxe de 'URL' é inválida", nameof(_appData.GetProfileURL));
                    }
                }

                // Verifica a inserção e valida o parametro 'urlRepositorie'
                if (!string.IsNullOrWhiteSpace(_appData.GetRepositorieURL))
                {
                    if (!urlRepositorieRegex.IsMatch(_appData.GetRepositorieURL))
                    {
                        throw new ArgumentException("A syntaxe de 'URL' é inválida", nameof(_appData.GetRepositorieURL));
                    }
                }

                AppScreenLetter.Init();

                if (ActiveScreenLetter) 
                {
                    AppScreenLetter.DrawString($"{_appData.GetAppName}");
                    Console.WriteLine("----------------------------------------------------------------------------");
                    Console.WriteLine($"{_appData.GetAppName}");
                    Console.WriteLine($"{_appData.GetVersionNumber}");
                    Console.WriteLine($"Dev: {_appData.GetProfileURL}");
                    Console.WriteLine($"Repositório: {_appData.GetRepositorieURL}");
                    Console.WriteLine("-----------------------------------------------------------------------------");
                }

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }

            

        }
    }
}
