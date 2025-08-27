/*
 * 
 * Ganchito
 * Version: v1.1.0
 * Description: Utilitário de git hooks
 * Author: rafaelsouzars
 * Github: https://github.com/rafaelsouzars
 * 
 */
using ganchito.Prompito.AbstractClasses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace ganchito.Prompito.Classes
{
    class ActionCommand : AbstractActionCommandBase
    {
        private Dictionary<string, (string, string)> _flags = new Dictionary<string, (string, string)>();
        private readonly Dictionary<string, string> _args = new();
        private ReadOnlyDictionary<string, string> _readOnlyArgs;

        public Dictionary<string, (string, string)> Flags
        {
            get 
            { 
                return _flags; 
            }

            private set 
            { 
                _flags = value; 
            }
        }

        public ReadOnlyDictionary<string, string> Arg
        {
            get
            {
                return _readOnlyArgs;
            }
        }

        public ActionCommand () 
        {
        
        }

        public ActionCommand(string[] args)
        {
            InitArgumentsMapper(args);
        }

        /// <summary>
        /// Método InitArgumentsMapper(). Mapeia o array de argumentos é retorna os objetos na propriedade Arg.
        /// 
        /// Este método fornece acesso padronizado aos argumentos. Se o array 'args' tiver uma entrada 'copy -x source dest'
        /// os elementos podem ser acessados na classe da seguinte forma: Arg["arg1"], Arg["flag1"], Arg["arg2"] Arg["arg3"]
        /// </summary>
        /// <param name="args">Array com os argumentos do console</param>        
        /// <remarks></remarks>
        protected void InitArgumentsMapper(string[] args) 
        {
            try
            {
                var flagsRegex = new Regex(@"^(-[a-zA-Z0-9])|(--([a-zA-Z0-9]{2,})(-[a-zA-Z0-9]+)?)$");

                if (args.Length > 0)
                {
                    var indexArg = 1;
                    var indexFlag = 1;
                    foreach (var arg in args)
                    {
                        if (!flagsRegex.IsMatch(arg))
                        {
                            _args.Add($"arg{indexArg}", arg);
                            indexArg++;
                        }
                        else
                        {
                            _args.Add($"flag{indexFlag}", arg);
                            indexFlag++;
                        }
                    }

                }

            }
            catch (Exception exception)
            {
                Console.WriteLine(" [ ERROR ]\n\t{0}\n", exception.Message);
            }

            _readOnlyArgs = new ReadOnlyDictionary<string, string>(_args);
        }

        protected bool FlagsVerify(string flag)
        {
            var flagsRegex = new Regex(@"^(-[a-zA-Z0-9])|(--([a-zA-Z0-9]{2,})(-[a-zA-Z0-9]+)?)$");

            if (flagsRegex.IsMatch(flag))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected bool FlagVerify(string flag)
        {
            var flagRegex = new Regex(@"^(-[a-zA-Z0-9])$");

            if (flagRegex.IsMatch(flag))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected bool ExtendFlagVerify(string flag)
        {
            var extendFlagRegex = new Regex(@"^(--([a-zA-Z0-9]{2,})(-[a-zA-Z0-9]+)?)$");

            if (extendFlagRegex.IsMatch(flag))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool ContainsFlag(string flag)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(flag))
                {
                    if (FlagVerify(flag))
                    {
                        if (_flags.ContainsKey(flag))
                        {
                            return true;
                        }
                        else
                        {
                            return false;                            
                        }
                    }
                    else
                    {
                        throw new ArgumentException("Formato de flag não reconhecido. ", flag);
                    }
                }
                else
                {
                    throw new ArgumentNullException(nameof(flag), "O arqumento não pode ser nulo");
                }
            }
            catch (Exception exception)
            {                
                Console.WriteLine(" [ ERROR ]\n\t{0}", exception.Message);
                return false;
            }

        }

        /// <summary>
        /// Método AddFlag(). Adiciona uma flag ao ActionCommand.
        /// </summary>
        /// <param name="flag">String com a flag</param>        
        /// <remarks>Exemplos de formatos de flags: "-e", "-X" e "-8".</remarks>
        public void AddFlag(string flag)
        {
            try
            {
                if (FlagVerify(flag))
                {
                    _flags.Add(flag, ("", ""));
                }
                else
                {
                    throw new ArgumentException("Formato de flag não reconhecido. ", flag);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(" [ ERROR ]\n\t{0}", exception.Message);
            }


        }        

        /// <summary>
        /// Método AddFlag(). Adiciona uma flag ao ActionCommand e sua versão extendida.
        /// </summary>
        /// <param name="flag">String com a flag</param>
        /// <param name="extendFlag">String com a flag extendida</param>
        /// <remarks>Exemplo de formato de flag extendida: "--add-flags".</remarks>
        public void AddFlag(string flag, string extendFlag)
        {
            try
            {
                if (FlagVerify(flag) && ExtendFlagVerify(extendFlag))
                {
                    _flags.Add(flag, (extendFlag, ""));
                }
                if (!FlagVerify(flag))
                {
                    throw new ArgumentException("Formato de flag não reconhecido. ", flag);
                }
                else if (!ExtendFlagVerify(extendFlag))
                {
                    throw new ArgumentException("Formato de flag extendida não reconhecido. ", extendFlag);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(" [ ERROR ]\n\t{0}", exception.Message);
            }
        }        

        /// <summary>
        /// Método AddFlag(). Adiciona uma flag ao ActionCommand, sua versão extendida e uma descrição.
        /// </summary>
        /// <param name="flag">String com a flag</param>
        /// <param name="extendFlag">String com a flag extendida</param>
        /// <param name="descriptionFlag">String com a descrição da flag</param>
        /// <remarks>Exemplo de formato de flag extendida: "--add-flags".</remarks>
        public void AddFlag(string flag, string extendFlag, string descriptionFlag)
        {
            try
            {
                if (FlagVerify(flag) && ExtendFlagVerify(extendFlag))
                {
                    _flags.Add(flag, (extendFlag, descriptionFlag));
                }
                if (!FlagVerify(flag))
                {
                    throw new ArgumentException("Formato de flag não reconhecido. ", flag);
                }
                else if (!ExtendFlagVerify(extendFlag))
                {
                    throw new ArgumentException("Formato de flag extendida não reconhecido. ", extendFlag);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(" [ ERROR ]\n\t{0}", exception.Message);
            }
        }
        

        /// <summary>
        /// Método AddExtendFlag(). Adiciona uma flag extendida a uma flag já existente.
        /// </summary>
        /// <param name="flag">String com a flag para busca</param>
        /// <param name="extendFlag">String com a flag extendida</param>        
        /// <remarks>Exemplo de formato de flag extendida: "--add-flags".</remarks>
        public void AddExtendFlag(string flag, string extendFlag) 
        {
            try 
            {

                if (ContainsFlag(flag))
                {
                    var tuple = _flags[flag];

                    tuple = (extendFlag, tuple.Item2);

                    _flags[flag] = tuple;
                }
                else
                {
                    throw new ArgumentException("Item não encontrado", flag);
                }               
                
            }
            catch (Exception exception) 
            {
                Console.WriteLine(" [ ERROR ]\n\t{0}", exception.Message);
            }
        }

        /// <summary>
        /// Método AddExtendFlag(). Adiciona uma descrição a uma flag já existente.
        /// </summary>
        /// <param name="flag">String com a flag para busca</param>
        /// <param name="descriptionFlag">String com a descrição</param>        
        /// <remarks>Exemplo de formato de flag extendida: "--add-flags".</remarks>
        public void AddDescriptionFlag(string flag, string descriptionFlag)
        {
            try
            {

                if (ContainsFlag(flag))
                {
                    var tuple = _flags[flag];

                    tuple = (tuple.Item1, descriptionFlag);

                    _flags[flag] = tuple;
                }
                else
                {
                    throw new ArgumentException("Item não encontrado", flag);
                }

            }
            catch (Exception exception)
            {
                Console.WriteLine(" [ ERROR ]\n\t{0}", exception.Message);
            }
        }       


        /// <summary>
        /// Método Run(). Executa o código implementado no escopo quando o comando for executado.
        /// </summary>       
        /// <remarks>Deve ser implementado em cada classe derivada.</remarks>
        override public void Run() 
        {
            
        }

        /// <summary>
        /// Método Run(). Executa o código implementado no escopo quando o comando for executado.
        /// </summary>
        /// <param name="args">Recebe os argumentos do console</param>        
        /// <remarks>Deve ser implementado em cada classe derivada.</remarks>
        override public void Run(string[] args)
        {
            
        }        


    }
}
