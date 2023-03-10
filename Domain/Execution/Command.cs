using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Execution
{
	public abstract class Command
	{
		public string Name { get; private set; }

		public abstract string GetStringRepresentation();
		public Command(string name)
		{
			Name = name;
		}
	}
}
