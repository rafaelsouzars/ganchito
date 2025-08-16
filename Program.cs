using System;
using ganchito.src.functions;
using ganchito.Prompito;
using ganchito.Prompito.ActionCommands;

namespace ganchito
{
    class Program
    {
        static void Main(string[] args)
        {         
            
            // CONCLUÍDO...
            var app = new Executer();

            app.InsertAppData(
                new {
                    AppName = "",
                    Version = "v1.0.0",
                    Description = "Utilitário de Git Hook",
                    ProfileURL = "https://github.com/rafasouzars",
                    RepositorieURL = "https://github.com/rafaelsouzars/ganchito"
                }); // 

            
            app.ScreenAbout(true);

            app.AddCommand(
                "init",
                "Teste Filha inicia alguma coisa",
                new ActionTeste()
                );


            app.ExecuteCommand(args);
            
        }
    }
}
