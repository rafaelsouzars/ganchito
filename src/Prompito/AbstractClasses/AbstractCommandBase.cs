using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ganchito.Prompito.Interfaces;

namespace ganchito.Prompito.AbstractClasses
{
    public abstract class AbstractCommandBase : ICommand
    {
        protected AbstractCommandBase() { }

        public abstract void Execute();

    }
}
