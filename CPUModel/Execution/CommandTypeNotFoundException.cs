using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUModel.Execution
{
	internal class CommandTypeNotFoundException : Exception
	{
		public CommandTypeNotFoundException()
		{
		}

		public CommandTypeNotFoundException(string message) 
			: base(message)
		{
		}

		public CommandTypeNotFoundException(string message, Exception inner)
			: base(message, inner)
		{
		}
	}
}
