using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUModel.Parsing.Exceptions
{
	public class CommandParseException : Exception
	{
		public CommandParseException(string message) : base(message) { }
		public CommandParseException(string message, Exception inner) : base(message, inner) { }
	}
}
