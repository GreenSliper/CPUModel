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
	public class CommandConstantFactory : AbstractCommandFactoryChain<CommandConstant>
	{
		public CommandConstantFactory(IEnumerable<string> supportedCommands) : base(supportedCommands)
		{
		}

		protected override CommandConstant ProduceCommand(string[] words)
		{
			if (words.Length != 2)
				throw new CommandParseException("Constant command should have 1 argument (except command name)");
			if (int.TryParse(words[1], out var constant))
				return new CommandConstant(words[0], constant);
			throw new CommandParseException("Failed to convert constant argument to integer!");
		}
	}
}
