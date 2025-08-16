using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ganchito.Prompito.AbstractClasses;

namespace ganchito.Prompito.Classes
{
    class Command<Receiver> : AbstractCommandBase where Receiver : class
    {
        public delegate void ReceiverAction(Receiver receiver);

        private readonly Receiver _receiver;
        private readonly ReceiverAction _action;

        public Command(Receiver receiver, ReceiverAction action)
        {
            _receiver = receiver ?? throw new ArgumentNullException(nameof(receiver));
            _action = action ?? throw new ArgumentNullException(nameof(action));
        }

        public override void Execute()
        {
            _action.Invoke(_receiver);
        }
    }
}
