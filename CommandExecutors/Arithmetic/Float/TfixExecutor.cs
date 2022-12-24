using Domain.Execution;
using Domain.Execution.Commands;
using Domain.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandExecutors.Arithmetic.Float
{
	internal class TfixExecutor : IConcreteCommandExecutor<CommandRDS>
	{
		public string Command => "TFIX";

		public void Execute(CommandRDS command, CPUResources resources)
		{
			int ans = 0;
			if(MathF.Abs(resources.regs.floats[command.RegisterSource]) > int.MaxValue)
				resources.regs.flags[Registers.Flags.Overflowing] = true;
			else
				ans = (int)resources.regs.floats[command.RegisterSource];
			resources.regs.flags[Registers.Flags.Zero] = ans == 0;
			resources.regs.flags[Registers.Flags.Sign] = ans < 0;
			resources.regs.flags[Registers.Flags.Carry] = resources.regs.flags[Registers.Flags.Overflowing];

			resources.regs.ints[command.RegisterDestination] = ans;
		}
	}
}
