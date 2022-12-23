using Domain.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandExecutors.Interruptions.PredefinedInterruptions
{
	internal class PredefinedInterruption0 : IPredefinedInterruption
	{
		public int Code => 0;

		public List<Command> GetCommands()
		{
			Console.WriteLine("Aboba");
			return new List<Command>() { };
		}
	}
}
