using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ganchito.src.interpretador
{
    class Parser
    {
        
        static public void Scanner() 
        {
            Regex commandArgsRegex = new Regex(@"^(init|help)(\s-([a-zA-Z0-9]){1}|\s--([a-zA-Z-0-9]+)(-[a-zA-Z0-9]+)?)*(\s[a-zA-Z0-9]+)?$");
        } 
    }
}
