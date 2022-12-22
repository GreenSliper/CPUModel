using Domain.Execution.Commands;
using Domain.Execution;
using Domain.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Exceptions;

namespace CommandExecutors.Arithmetic
{
	internal class DivExecutor : IConcreteCommandExecutor<CommandRDSS>
	{
		public string Command => "DIV";

		public void Execute(CommandRDSS command, CPUResources resources)
		{
			int ans = 0;
			if (resources.regs.ints[command.RegisterSource2] == 0)
				throw new DivisionByZeroInterruptionException();
			ans = (resources.regs.ints[command.RegisterSource1] / resources.regs.ints[command.RegisterSource2]);
			resources.regs.flags[Registers.Flags.Zero] = ans == 0;
			resources.regs.flags[Registers.Flags.Sign] = ans < 0;

			resources.regs.ints[command.RegisterDestination] = ans;
		}
	}
}
