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
	internal class RcrExecutor : IConcreteCommandExecutor<CommandRDSS>
	{
		public string Command => "RCR";

		public void Execute(CommandRDSS command, CPUResources resources)
		{
			int ans = 0;
			try
			{
				ans = checked(resources.regs.ints[command.RegisterSource1] >> resources.regs.ints[command.RegisterSource2]);
			}
			catch (OverflowException)
			{
				resources.regs.flags[Registers.Flags.Overflowing] = true;
			}
			resources.regs.flags[Registers.Flags.Zero] = ans == 0;
			resources.regs.flags[Registers.Flags.Sign] = ans < 0;
			resources.regs.flags[Registers.Flags.Carry] = resources.regs.flags[Registers.Flags.Overflowing];

			resources.regs.ints[command.RegisterDestination] = ans;
		}
	}
}
