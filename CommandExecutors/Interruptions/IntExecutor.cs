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
	//TODO add command that can move function in T1 register
	internal class IntExecutor : IConcreteCommandExecutor<EmptyCommand>
	{
		public string Command => "INT";

		public void Execute(EmptyCommand command, CPUResources resources)
		{
			if (resources.commandQueue.Interruption)
				throw new Exception("Cannot use interruption while running an interruption");
			resources.regs.Save();
			resources.commandQueue.Interruption = true;
		}
	}
}
