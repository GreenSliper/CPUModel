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
	internal class StdwExecutor : IConcreteCommandExecutor<CommandMemory>
	{
		public string Command => "STDW";

		public void Execute(CommandMemory command, CPUResources resources)
		{
			long val = (resources.regs.ints[command.Register] << 32) | + resources.regs.ints[command.Register + 1];
			resources.ram.SetDoubleWord(command.MemoryAddress, val);
		}
	}
}
