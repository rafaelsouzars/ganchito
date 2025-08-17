using System;
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
                });

            
            app.ScreenAbout(true);

            app.AddCommand(
                "commit",
                "Teste Filha inicia alguma coisa",
                new ActionGanchito()
                );

            app.AddCommand(
                "help",
                "Ajuda do Ganchito v1.0.0",
                new ActionGanchitoHelper()
                );


            app.ExecuteCommand(args);
            
        }
    }
}
