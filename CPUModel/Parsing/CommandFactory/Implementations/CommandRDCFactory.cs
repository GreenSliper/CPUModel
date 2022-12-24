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
	public class CommandRDCFactory : AbstractCommandFactoryChain<CommandRDC>
	{
		public CommandRDCFactory(IEnumerable<string> supportedCommands) : base(supportedCommands)
		{
		}

		protected override CommandRDC ProduceCommand(string[] words)
		{
			if (words.Length != 3)
				throw new CommandParseException("RDC command should have 2 arguments (except command name)");
			if (int.TryParse(words[1], out var rd) && int.TryParse(words[2], out var constant))
				return new CommandRDC(words[0], rd, constant);
			throw new CommandParseException("Failed to convert arguments to integers!");
		}
	}
}
