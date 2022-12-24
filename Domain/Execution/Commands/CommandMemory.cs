using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Execution.Commands
{
	public class CommandMemory : Command
	{
		public int Register { get; private set; }
		public int MemoryAddress { get; private set; }
		public CommandMemory(string name, int register, int memoryAddress) : base(name)
		{
			Register = register;
			MemoryAddress = memoryAddress;
		}

		public override string GetStringRepresentation() => $"{Name} r{Register} m{MemoryAddress}";
	}
}
