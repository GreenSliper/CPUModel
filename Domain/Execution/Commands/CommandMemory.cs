using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Execution.Commands
{
	public class CommandMemory : Command
	{
		public CommandMemory(string name) : base(name)
		{
		}

		public override string GetStringRepresentation()
		{
			throw new NotImplementedException();
		}
	}
}
