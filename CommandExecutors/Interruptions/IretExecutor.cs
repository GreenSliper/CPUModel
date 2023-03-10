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
	internal class IretExecutor : IConcreteCommandExecutor<CommandEmpty>
	{
		public string Command => "IRET";

		public void Execute(CommandEmpty command, CPUResources resources)
		{
			resources.commandQueue.Interruption = false;
			resources.regs.Restore();
		}
	}
}
