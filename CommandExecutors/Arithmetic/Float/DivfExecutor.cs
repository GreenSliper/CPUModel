using Domain.Execution.Commands;
using Domain.Execution;
using Domain.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Exceptions;

namespace CommandExecutors.Arithmetic.Float
{
	internal class DivfExecutor : IConcreteCommandExecutor<CommandRDSS>
	{
		public string Command => "DIVF";

		public void Execute(CommandRDSS command, CPUResources resources)
		{
			float ans = 0;
			if(resources.regs.floats[command.RegisterSource2] == 0)
				throw new DivisionByZeroInterruptionException();
			try
			{
				ans = checked(resources.regs.floats[command.RegisterSource1] / resources.regs.floats[command.RegisterSource2]);
			}
			catch (OverflowException)
			{
				resources.regs.flags[Registers.Flags.Overflowing] = true;
			}
			resources.regs.flags[Registers.Flags.Zero] = ans == 0;
			resources.regs.flags[Registers.Flags.Sign] = ans < 0;
			resources.regs.flags[Registers.Flags.Carry] = resources.regs.flags[Registers.Flags.Overflowing];

			resources.regs.floats[command.RegisterDestination] = ans;
		}
	}
}
