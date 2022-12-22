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

		public CommandQueue commandQueue;

		public CPUResources(Registers regs)
		{
			this.regs = regs;
		}
	}
}
