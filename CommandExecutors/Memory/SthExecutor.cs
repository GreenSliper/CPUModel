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
	internal class SthExecutor : IConcreteCommandExecutor<CommandMemory>
	{
		public string Command => "STH";

		public void Execute(CommandMemory command, CPUResources resources)
		{
			short val = (short)(resources.regs.ints[command.Register] << 16 >> 16);
			resources.ram.SetHalfWorld(command.MemoryAddress, val);
		}
	}
}
