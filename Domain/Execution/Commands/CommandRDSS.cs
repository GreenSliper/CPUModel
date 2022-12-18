using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Execution.Commands
{
	public class CommandRDSS : Command
	{
		public int RegisterDestination { get; private set; }
		public int RegisterSource1 { get; private set; }
		public int RegisterSource2 { get; private set; }

		public CommandRDSS(string name, int registerDestination, int registerSource1, int registerSource2) : base(name)
		{
			RegisterDestination = registerDestination;
			RegisterSource1 = registerSource1;
			RegisterSource2 = registerSource2;
		}
	}
}
