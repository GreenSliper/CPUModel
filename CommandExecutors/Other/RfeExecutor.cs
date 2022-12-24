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
	internal class RfeExecutor : IConcreteCommandExecutor<CommandEmpty>
	{
		public string Command => "RFE";

		public void Execute(CommandEmpty command, CPUResources resources)
		{
			resources.regs.flags[Registers.Flags.SuperUser] = false;
		}
	}
}
