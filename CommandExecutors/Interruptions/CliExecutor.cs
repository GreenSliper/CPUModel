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
	internal class CliExecutor : IConcreteCommandExecutor<EmptyCommand>
	{
		public string Command => "CLI";

		public void Execute(EmptyCommand command, CPUResources resources)
		{
			resources.regs.flags[Registers.Flags.Iterrupt] = false;
		}
	}
}
