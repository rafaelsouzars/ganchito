using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Collections.ObjectModel;


namespace ganchito.Prompito.Classes
{
    internal class Args
    {        
        private readonly Dictionary<string, string> _args = new();
        private readonly ReadOnlyDictionary<string, string> _readOnlyArgs;
        private JsonDocument _json;

        public ReadOnlyDictionary<string, string> Arg
        {
            get
            {
                return _readOnlyArgs;
            }
        }        

        private object GetArgs()
        {           
            object obj = null;
            try 
            {
                if (_json != null) 
                {
                    obj = JsonSerializer.Serialize(_json);                    
                }
                
            }
            catch (Exception exception) 
            {
                Console.WriteLine(" [ ERROR ]\n\t{0}", exception.Message);
            }           

            return obj;
        }

        public Args(string[] args) 
        {
            try
            {
                string json = null;
                var flagsRegex = new Regex(@"^(-[a-zA-Z0-9])|(--([a-zA-Z0-9]{2,})(-[a-zA-Z0-9]+)?)$");

                if (args.Length > 0)
                {
                    var indexArg = 1;
                    var indexFlag = 1;
                    foreach (var arg in args)
                    {
                        if (!flagsRegex.IsMatch(arg))
                        {

                            if (string.IsNullOrEmpty(json))
                            {
                                json += $"{{ \"arg{indexArg}\" : \"{arg}\" ";
                            }
                            else if (!string.IsNullOrEmpty(json) && args.Length > 1)
                            {
                                json += $", \"arg{indexArg}\" : \"{arg}\" ";
                            }                            

                            _args.Add($"arg{indexArg}", arg);                            
                            indexArg++;
                        }                            
                        else
                        {
                            if (string.IsNullOrEmpty(json))
                            {
                                json += $"{{ \"flag{indexFlag}\" : \"{arg}\" ";
                            }
                            else if (!string.IsNullOrEmpty(json) && args.Length > 1)
                            {
                                json += $", \"flag{indexFlag}\" : \"{arg}\"";
                            }                            

                            _args.Add($"flag{indexFlag}", arg);
                            indexFlag++;
                        }
                    }

                    if (!string.IsNullOrEmpty(json)) 
                    {
                        json += $"}}";
                        _json = JsonDocument.Parse(json);
                    }
                }

            }
            catch (Exception exception)
            {
                Console.WriteLine(" [ ERROR ]\n\t{0}\n", exception.Message);
            }

            _readOnlyArgs = new ReadOnlyDictionary<string, string>(_args);
        }

        public void ShowArgs() 
        {
            if (_args.Count > 0) 
            {
                foreach (var arg in _args)
                {
                    Console.WriteLine(" {0} => {1}", arg.Key, arg.Value);
                }
            }
            else 
            {
                Console.WriteLine("\tSem argumentos...\n");
            }
            
        }
        
        public override string ToString() 
        {
            return GetArgs().ToString();
        }
    }
}
