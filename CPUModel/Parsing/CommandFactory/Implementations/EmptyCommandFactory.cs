using CPUModel.Parsing.CommandFactory.Abstract;
using CPUModel.Parsing.Exceptions;
using Domain.Execution.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUModel.Parsing.CommandFactory.Implementations
{
    public class CommandEmptyFactory : AbstractCommandFactoryChain<CommandEmpty>
    {
        public CommandEmptyFactory(IEnumerable<string> supportedCommands) : base(supportedCommands)
        {
        }

        protected override CommandEmpty ProduceCommand(string[] words)
        {
            if (words.Length != 1)
                throw new CommandParseException("No-argument command should only contain name, no arguments");
            return new CommandEmpty(words[0]);
        }
    }
}
