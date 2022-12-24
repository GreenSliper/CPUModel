using Domain.Execution.Commands;
using Domain.Execution;
using Domain.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandExecutors.Arithmetic.Float
{
	internal class TfloExecutor : IConcreteCommandExecutor<CommandRDS>
	{
		public string Command => "TFLO";

		public void Execute(CommandRDS command, CPUResources resources)
		{
			float ans = 0;
			ans = resources.regs.ints[command.RegisterSource];
			resources.regs.flags[Registers.Flags.Zero] = ans == 0;
			resources.regs.flags[Registers.Flags.Sign] = ans < 0;

			resources.regs.floats[command.RegisterDestination] = ans;
		}
	}
}
