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
	public class CommandPortFactory : AbstractCommandFactoryChain<CommandPort>
	{
		public CommandPortFactory(IEnumerable<string> supportedCommands) : base(supportedCommands)
		{
		}

		protected override CommandPort ProduceCommand(string[] words)
		{
			if (words.Length != 3)
				throw new CommandParseException("RDC command should have 2 arguments (except command name)");
			if (int.TryParse(words[1], out var rd) && int.TryParse(words[2], out var portIndex))
				return new CommandPort(words[0], rd, portIndex);
			throw new CommandParseException("Failed to convert arguments to integers!");
		}
	}
}
