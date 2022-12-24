using Domain.Execution.Commands;
using Domain.Execution;
using Domain.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandExecutors.Ports
{
	internal class OutExecutor : IConcreteCommandExecutor<CommandPort>
	{
		public string Command => "OUT";

		public void Execute(CommandPort command, CPUResources resources)
		{
			resources.regs.ints[command.Register] = resources.port.ReceiveDataToPin(command.PinIndex);
		}
	}
}
