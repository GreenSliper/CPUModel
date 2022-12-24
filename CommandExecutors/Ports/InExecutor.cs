using Domain.Execution;
using Domain.Execution.Commands;
using Domain.Resources;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandExecutors.Ports
{
	internal class InExecutor : IConcreteCommandExecutor<CommandPort>
	{
		public string Command => "IN";

		public void Execute(CommandPort command, CPUResources resources)
		{
			resources.port.SendDataToPin(command.PinIndex, resources.regs.ints[command.Register]);
		}
	}
}
