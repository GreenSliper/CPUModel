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
	internal class StwExecutor : IConcreteCommandExecutor<CommandMemory>
	{
		public string Command => "STW";

		public void Execute(CommandMemory command, CPUResources resources)
		{
			int val = resources.regs.ints[command.Register];
			resources.ram.SetWord(command.MemoryAddress, val);
		}
	}
}
