using Domain.Execution.Commands;
using Domain.Execution;
using Domain.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandExecutors.Interruptions
{
	internal class StiExecutor : IConcreteCommandExecutor<CommandEmpty>
	{
		public string Command => "STI";

		public void Execute(CommandEmpty command, CPUResources resources)
		{
			resources.regs.flags[Registers.Flags.Iterrupt] = true;
		}
	}
}
