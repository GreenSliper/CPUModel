using Domain.Execution;
using Domain.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Resources
{
	public class CPUResources
	{
		public Registers regs;
		public RAM ram;
		public CommandQueue commandQueue = null!;
		public Port port;

		public int programCounter = 0;

		public CPUResources(Registers regs, RAM ram, Port port)
		{
			this.regs = regs;
			this.ram = ram;
			this.port = port;
		}
	}
}
