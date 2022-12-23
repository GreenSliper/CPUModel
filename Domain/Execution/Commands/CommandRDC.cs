using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Execution.Commands
{
	public class CommandRDC : Command
	{
		public int RegisterDestination { get; private set; }
		public int Constant { get; private set; }

		public CommandRDC(string name, int registerDestination, int constant) : base(name)
		{
			Constant = constant;
			RegisterDestination = registerDestination;
		}
	}
}
