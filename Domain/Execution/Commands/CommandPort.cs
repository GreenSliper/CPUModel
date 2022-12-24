using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Execution.Commands
{
	public class CommandPort : Command
	{
		public int Register {get; private set;}
		public int PinIndex {get; private set;}
		public CommandPort(string name, int register, int portIndex) : base(name)
		{
			Register = register;
			PinIndex = portIndex;
		}

		public override string GetStringRepresentation() => $"{Name} r{Register} p{PinIndex}";
	}
}
