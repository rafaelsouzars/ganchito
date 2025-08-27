using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ganchito.Prompito.Classes;

namespace ganchito.Prompito.AbstractClasses
{
    abstract class AbstractAppHelpCommandBase
    {

        abstract public void Run(IDictionary<string, (string, ActionCommand) > receives);
    }
}
