using CPUModel.Parsing.CommandFactory.Abstract;
using CPUModel.Parsing.Exceptions;
using Domain.Resources;
using Domain.Execution.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUModel.Parsing.CommandFactory
{
	public class CommandRDSSFactory : AbstractCommandFactoryChain<CommandRDSS>
	{
		public CommandRDSSFactory(IEnumerable<string> supportedCommands) : base(supportedCommands)
		{
		}

		protected override CommandRDSS ProduceCommand(string[] words)
		{
			if (words.Length != 4)
				throw new CommandParseException("RDSS command should have 3 arguments except command name");
			if (int.TryParse(words[1], out int rd) && int.TryParse(words[2], out int rs1) && int.TryParse(words[3], out int rs2))
				return new CommandRDSS(words[0], rd, rs1, rs2);
			throw new CommandParseException("RDSS command invalid registers");
		}
	}
}
