using Domain.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandExecutors.Interruptions.PredefinedInterruptions
{
	internal interface IPredefinedInterruption
	{
		int Code { get; }
		List<Command> GetCommands();
	}
}
