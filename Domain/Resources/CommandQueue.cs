using Domain.Execution;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Resources
{
    public class CommandQueue
    {
        public bool Interruption { get; set; }
        IEnumerator<Command> PC = null!;
        IEnumerator<Command> PCI = null!;
        List<Command> executedCommands = new();
        public CommandQueue(IEnumerable<Command> PCcommands = null!)
        {
            if (PCcommands != null)
                PC = PCcommands.GetEnumerator();
        }

        public void SetInterruptionCommands(IEnumerable<Command> commands)
        {
            PCI = commands.GetEnumerator();
        }

        public bool TryGetCommand(out Command command)
        {
            command = null!;
            if (Interruption)
            {
                if (!PCI.MoveNext())
                    return false;
                command = PCI.Current;
                return true;
            }
            else if (!PC.MoveNext())
                return false;
            command = PC.Current;
            executedCommands.Add(command);
            return true;
        }
    }
}
