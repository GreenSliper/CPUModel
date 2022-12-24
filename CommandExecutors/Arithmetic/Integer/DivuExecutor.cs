using Domain.Exceptions;
using Domain.Execution.Commands;
using Domain.Execution;
using Domain.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandExecutors.Arithmetic.Integer
{
	internal class DivuExecutor : IConcreteCommandExecutor<CommandRDSS>
	{
		public string Command => "DIVU";

		public void Execute(CommandRDSS command, CPUResources resources)
		{
			uint ans = 0;
			if (resources.regs.ints[command.RegisterSource2] == 0)
				throw new DivisionByZeroInterruptionException();
			ans = (uint)resources.regs.ints[command.RegisterSource1] / (uint)resources.regs.ints[command.RegisterSource2];
			resources.regs.flags[Registers.Flags.Zero] = ans == 0;
			resources.regs.flags[Registers.Flags.Sign] = ans < 0;

			resources.regs.ints[command.RegisterDestination] = (int)ans;
		}
	}
}
