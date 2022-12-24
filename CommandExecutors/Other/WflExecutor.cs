using Domain.Execution.Commands;
using Domain.Execution;
using Domain.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandExecutors.Other
{
	internal class WflExecutor : IConcreteCommandExecutor<CommandRD>
	{
		public string Command => "WFL";

		public void Execute(CommandRD command, CPUResources resources)
		{
			int i = 0;
			foreach (var flag in Enum.GetValues(typeof(Registers.Flags)).Cast<Registers.Flags>().OrderBy(x => (int)x))
				resources.regs.flags[flag] = (resources.regs.ints[command.RegisterDestination] & (1 << i)) != 0;
		}
	}
}
