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
	public class CommandRDSFactory : AbstractCommandFactoryChain<CommandRDS>
	{
		public CommandRDSFactory(IEnumerable<string> supportedCommands) : base(supportedCommands)
		{
		}

		protected override CommandRDS ProduceCommand(string[] words)
		{
			if (words.Length != 4)
				throw new CommandParseException("RDS command should have 2 arguments except command name");
			if (int.TryParse(words[1], out int rd) && int.TryParse(words[2], out int rs1))
				return new CommandRDS(words[0], rd, rs1);
			throw new CommandParseException("RDS command invalid registers");
		}
	}
}
