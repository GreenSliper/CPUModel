using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Execution.Commands
{
	public class CommandPort : Command
	{
		public CommandPort(string name) : base(name)
		{
		}

		public override string GetStringRepresentation()
		{
			throw new NotImplementedException();
		}
	}
}
