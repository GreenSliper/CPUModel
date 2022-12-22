using CPUModel.Parsing.CommandFactory.Abstract;
using CPUModel.Parsing.Exceptions;
using Domain.Execution.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUModel.Parsing.CommandFactory
{
    internal class EmptyCommandFactory : AbstractCommandFactoryChain<EmptyCommand>
    {
        public EmptyCommandFactory(IEnumerable<string> supportedCommands) : base(supportedCommands)
        {
        }

        protected override EmptyCommand ProduceCommand(string[] words)
        {
            if(words.Length != 1)
				throw new CommandParseException("No-argument command should only name, no arguments");
            return new EmptyCommand(words[0]);
		}
    }
}
