/*

    PROMPITO CLI

    NAME: Scanner.cs

    VERSION: 1.0.0

    DESCRIPTION: Esta classe é responsável por escanear e gerar a matriz de tokens para o Parser.

    AUTHOR: Rafael Souza

*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Text.Json;
using System.Threading.Tasks;

namespace ganchito.src.interpretador
{
    class Scanner
    {

        // Expressões regulares para testar os comandos inseridos (Input regex tester): command line, command, options and arguments. 
        static private readonly Regex commandLineRegex = new Regex(@"^(init|help)((\s-([a-zA-Z0-9]){1}|\s--([a-zA-Z-0-9]){2,}(-[a-zA-Z0-9]+)?)*((\s[a-zA-Z0-9]+)((-*)?[a-zA-Z0-9]+)*)?)*$");
        static private readonly Regex commandRegex = new Regex(@"^(init|help)$");
        static private readonly Regex optionRegex = new Regex(@"^(-([a-zA-Z0-9]){1}|--([a-zA-Z-0-9]){2,}(-[a-zA-Z0-9]+)?)$");
        static private readonly Regex argumentRegex = new Regex(@"^(([a-zA-Z0-9]+)((-*)?[a-zA-Z0-9]+)*)?$");

        // Variáveis globais internas
        static private string argsLine = null;
        static private List<string> tokens = new List<string>();

        // Funções auxiliares
        static private string MakeSrtringCommandLine(string[] args)
        {
            string makeLine = null;
            foreach (var arg in args)
            {
                makeLine += $" {arg}";
            }

            return makeLine.Trim();
        }
        static public void Input(string[] args)
        {
            try 
            {
                // Concatena os argumentos inseridos para testar a linha de comando
                argsLine = MakeSrtringCommandLine(args);

                // Testa a sintaxe da linha
                if (commandLineRegex.IsMatch(argsLine))
                {
                    // Testa a sintaxe de cada argumento para gerar os tokens: 'command', 'option' e 'argument'
                    foreach (var token in args.Select((arg, i) => new { Arg = arg, Index = i }))
                    {
                        if (commandRegex.IsMatch(token.Arg) && token.Index == 0)
                        {
                            tokens.Add(JsonSerializer.Serialize(new { command = token.Arg }));
                        }
                        else if (optionRegex.IsMatch(token.Arg))
                        {
                            tokens.Add(JsonSerializer.Serialize(new { option = token.Arg }));
                        }
                        else if (argumentRegex.IsMatch(token.Arg))
                        {
                            tokens.Add(JsonSerializer.Serialize(new { argument = token.Arg }));
                        }
                    }

                }
                else
                {
                    // Exception para erro de sintaxe
                    throw new ArgumentException($"ERRO(!) Comando, opção ou argumento com erro de sintaxe: {argsLine}", nameof(args));
                }
            }
            catch (Exception exception)
            {
                // Mensagem de erro
                Console.WriteLine($"{exception}");
            }
            
        }

        // Retorna a matriz com os tokens
        static public string[] ToArrayTokens() 
        {
            return tokens.ToArray();
        }

        // Retorna uma lista de string com os tokens
        static public List<string> ToListTokens()
        {
            return tokens;
        }
    }
}
