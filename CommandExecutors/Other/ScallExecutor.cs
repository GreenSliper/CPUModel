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
	internal class ScallExecutor : IConcreteCommandExecutor<CommandEmpty>
	{
		public string Command => "SCALL";

		public void Execute(CommandEmpty command, CPUResources resources)
		{
			resources.regs.flags[Registers.Flags.USuperUser] = true;
		}
	}
}
