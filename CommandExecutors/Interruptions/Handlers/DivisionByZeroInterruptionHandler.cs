using Domain.Exceptions;
using Domain.Execution;
using Domain.Execution.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandExecutors.Interruptions.Handlers
{
    internal class DivisionByZeroInterruptionHandler : IConcreteInterruptionHandler<DivisionByZeroInterruptionException>
    {
        List<Command> commands = new List<Command>()
        {
            new CommandEmpty("CLI"),
            new CommandEmpty("IRET")
        };

        public IEnumerable<Command> GetInterruptionCommands() => commands.ToList();
    }
}
