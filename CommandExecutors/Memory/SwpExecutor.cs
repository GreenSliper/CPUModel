using Domain.Execution.Commands;
using Domain.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Resources;

namespace CommandExecutors.Memory
{
	internal class SwpExecutor : IConcreteCommandExecutor<CommandRDS>
	{
		public string Command => "SWP";

		public void Execute(CommandRDS command, CPUResources resources)
		{
			int tmp = resources.regs.ints[command.RegisterDestination];
			resources.regs.ints[command.RegisterDestination] = resources.regs.ints[command.RegisterSource];
			resources.regs.ints[command.RegisterSource] = tmp;
		}
	}
}
