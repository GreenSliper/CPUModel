using Domain.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Execution
{
	public interface IConcreteCommandExecutor<T>
		where T : Command
	{
		void Execute(T command, CPUResources resources);
		string Command { get; }
	}
}
