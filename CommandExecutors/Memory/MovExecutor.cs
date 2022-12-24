using Domain.Execution;
using Domain.Execution.Commands;
using Domain.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandExecutors.Memory
{
	internal class MovExecutor : IConcreteCommandExecutor<CommandRDS>
	{
		public string Command => "MOV";

		public void Execute(CommandRDS command, CPUResources resources)
		{
			resources.regs.ints[command.RegisterDestination] = resources.regs.ints[command.RegisterSource];
		}
	}
}
