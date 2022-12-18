using Domain.Execution;
using CPUModel.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Resources;

namespace CPUModel.Execution
{
	public interface ICommandExecutor
	{
		void Execute(Command command, CPUResources resources);
	}

	public interface ICommandExecutorChain : ICommandExecutor
	{
		void AddSuccessor(ICommandExecutorChain executor);
	}

	public interface ITypedCommandExecutorChain<T> : ICommandExecutorChain
		where T : Command
	{
	}
}
