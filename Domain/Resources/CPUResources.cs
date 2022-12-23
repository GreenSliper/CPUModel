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

		public CommandQueue commandQueue = null!;

		public int programCounter = 0;

		public CPUResources(Registers regs)
		{
			this.regs = regs;
		}
	}
}
