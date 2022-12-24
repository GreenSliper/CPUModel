using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Execution.Commands
{
	public class CommandEmpty : Command
	{
		public CommandEmpty(string name) : base(name)
		{
		}

		public override string GetStringRepresentation() => Name;
	}
}
