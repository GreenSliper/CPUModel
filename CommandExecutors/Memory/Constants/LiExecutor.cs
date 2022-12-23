﻿using Domain.Execution.Commands;
using Domain.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Resources;

namespace CommandExecutors.Memory.Constants
{
	internal class LiExecutor : IConcreteCommandExecutor<CommandRDC>
	{
		public string Command => "LI";

		public void Execute(CommandRDC command, CPUResources resources)
		{
			resources.regs.ints[command.RegisterDestination] = command.Constant;
		}
	}
}
