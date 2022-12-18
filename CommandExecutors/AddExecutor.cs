using Domain.Execution;
using Domain.Execution.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandExecutors
{
	internal class AddExecutor : IConcreteCommandExecutor<CommandRDSS>
	{
		public string Command => "ADD";

		public void Execute(CommandRDSS command)
		{
			throw new NotImplementedException();
		}
	}
}
