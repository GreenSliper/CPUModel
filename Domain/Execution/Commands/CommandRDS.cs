using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Execution.Commands
{
	public class CommandRDS : Command
	{
		public int RegisterDestination {get; private set;}
		public int RegisterSource { get; private set; }

		public CommandRDS(string name, int registerDestination, int registerSource) : base(name)
		{
			RegisterDestination = registerDestination;
			RegisterSource = registerSource;
		}
	}
}
