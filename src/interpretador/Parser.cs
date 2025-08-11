/*

    PROMPITO CLI

    NAME: Parser.cs

    VERSION: 1.0.0

    DESCRIPTION: Esta classe é responsável por criar o arquivo AST para o executor de commandos.

    AUTHOR: Rafael Souza

*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ganchito.src.interpretador
{
    class Parser
    {  
        // Expressões regulares para identificações de rules, commands, options e arguments.
        static private readonly Regex tokenRegex = new Regex(@"(command|option|argument)");
        static private readonly Regex commandRegex = new Regex(@"(init|help)");
        static private readonly Regex optionRegex = new Regex(@"(-([a-zA-Z0-9]){1}|--([a-zA-Z-0-9]){2,}(-[a-zA-Z0-9]+)?)");
        static private readonly Regex argumentRegex = new Regex(@"([a-zA-Z0-9]+)((-*)?[a-zA-Z0-9]+)*");

        static private MatchCollection matches;

        //static private object objCommand; 

        static private readonly List<Regex> listRegex= new List<Regex>();

        // Variáveis globais 
        static private string lineRule = null;
        static private string astCommand = null;
        static private string[] astOptions = new string[] { };
        static private string[] astArguments = new string[] { };
        static private string astRule = null;
        static private object AST;

        /* Variáveis PUBLICAS */

        // Modo DEBUG
        static public bool DEBUG = false;

        // Cria a linha de rules dos tokens
        static private string MakeLineCommandTokensRule(string[] tokens)
        {
            Regex reg = new Regex(@"(init|help|option|argument)");
            string rule = null;
            foreach (var token in tokens.Select((value, i) => new { Value = value, Index = i }))
            {
                rule += $" {reg.Match(token.Value)}";
            }
            return rule.Trim();
        }

        // Cria o AST
        static private void MakeAST(string[] tokens) 
        {
            foreach (var token in tokens.Select((obj, i) => new { Obj = obj, Index = i }))
            {
                if (tokenRegex.IsMatch(token.Obj))
                {

                    switch (tokenRegex.Match(token.Obj).ToString())
                    {
                        case "command":
                            astCommand = commandRegex.Match(token.Obj).ToString();
                            break;
                        case "option":
                            astOptions = astOptions.Append<string>(optionRegex.Match(token.Obj).ToString()).ToArray();
                            break;
                        case "argument":
                            matches = argumentRegex.Matches(token.Obj);
                            astArguments = astArguments.Append<string>(matches[1].Value).ToArray();
                            break;

                    }
                }
            }

            // AST
            AST = new { Command = astCommand, Options = astOptions, Arguments = astArguments, Rule = astRule };            
            
        }


        static public object GetAST()
        {
            return AST;
        }        

        /*static public void AddCommands(object command) 
        {
            objCommand = command;
        }*/

        static public void Input(string[] tokens) 
        {            
            // Rules
            listRegex.Add(new Regex(@"^init$"));
            listRegex.Add(new Regex(@"^init argument$"));
            listRegex.Add(new Regex(@"^init option$"));
            listRegex.Add(new Regex(@"^init option argument$"));
            listRegex.Add(new Regex(@"^init argument$"));
            listRegex.Add(new Regex(@"^help$"));
            listRegex.Add(new Regex(@"^help argument$"));

            // Criar a linha rules gerada pelos tokens
            lineRule = MakeLineCommandTokensRule(tokens);             

            // Analisa se a regra existe (futuramente, na gramática)
            foreach (Regex rule in listRegex) 
            {
                if (rule.IsMatch(lineRule))
                {

                    astRule = rule.ToString().Replace("^", "").Replace("$", "");

                    MakeAST(tokens);                    

                    if (DEBUG)
                    {
                        Console.WriteLine($"Rule => | {astRule} |");
                        Console.WriteLine($"MakeAST: {JsonSerializer.Serialize(AST)}");
                        
                    }
                }                
            }           

            
        } 
    }
}
