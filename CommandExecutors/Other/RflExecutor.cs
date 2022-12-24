using Domain.Execution;
using Domain.Execution.Commands;
using Domain.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandExecutors.Other
{
	internal class RflExecutor : IConcreteCommandExecutor<CommandRD>
	{
		public string Command => "RFL";

		public void Execute(CommandRD command, CPUResources resources)
		{
			int result = 0;
			int i = 0;
			foreach (var flag in resources.regs.flags.OrderBy(x=>(int)x.Key))
				result |= 1 << i++;
			resources.regs.ints[command.RegisterDestination] = result;
		}
	}
}
