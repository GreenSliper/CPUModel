using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Execution.Commands
{
	public class CommandRD : Command
	{
		public int RegisterDestination { get; private set; }

		public CommandRD(string name, int registerDestination) : base(name)
		{
			RegisterDestination = registerDestination;
		}
	}
}
