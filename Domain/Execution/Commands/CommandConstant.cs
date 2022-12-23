using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Execution.Commands
{
	public class CommandConstant : Command
	{
		public int Constant { get; private set; }
		public CommandConstant(string name, int constant) : base(name)
		{
			this.Constant = constant;
		}
	}
}
