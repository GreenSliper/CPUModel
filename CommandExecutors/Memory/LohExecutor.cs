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
	internal class LohExecutor : IConcreteCommandExecutor<CommandMemory>
	{
		public string Command => "LOH";

		public void Execute(CommandMemory command, CPUResources resources)
		{
			resources.regs.ints[command.Register] = resources.ram.GetHalfWorld(command.MemoryAddress);
		}
	}
}
