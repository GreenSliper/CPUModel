using Domain.Execution.Commands;
using Domain.Execution;
using Domain.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandExecutors.Memory
{
	internal class LowExecutor : IConcreteCommandExecutor<CommandMemory>
	{
		public string Command => "LOW";

		public void Execute(CommandMemory command, CPUResources resources)
		{
			resources.regs.ints[command.Register] = resources.ram.GetWord(command.MemoryAddress);
		}
	}
}
