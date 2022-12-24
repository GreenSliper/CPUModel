using Domain.Execution.Commands;
using Domain.Execution;
using Domain.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandExecutors.Arithmetic.Integer.Logical
{
	internal class OrExecutor : IConcreteCommandExecutor<CommandRDSS>
	{
		public string Command => "OR";

		public void Execute(CommandRDSS command, CPUResources resources)
		{
			int ans = resources.regs.ints[command.RegisterSource1] | resources.regs.ints[command.RegisterSource2];
			resources.regs.flags[Registers.Flags.Zero] = ans == 0;
			resources.regs.flags[Registers.Flags.Sign] = ans < 0;

			resources.regs.ints[command.RegisterDestination] = ans;
		}
	}
}
