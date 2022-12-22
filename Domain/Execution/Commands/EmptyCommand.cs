using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Execution.Commands
{
	public class EmptyCommand : Command
	{
		public EmptyCommand(string name) : base(name)
		{
		}
	}
}
