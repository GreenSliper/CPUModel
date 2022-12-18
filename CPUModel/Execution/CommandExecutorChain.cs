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
	public class CommandExecutorChain<T> : ITypedCommandExecutorChain<T>
		where T : Command
	{
		ICommandExecutorChain next = null!;
		Dictionary<string, IConcreteCommandExecutor<T>> concreteExecutors = new();
		public CommandExecutorChain(IEnumerable<IConcreteCommandExecutor<T>> concreteExecutors)
		{
			foreach (var ex in concreteExecutors)
				this.concreteExecutors.Add(ex.Command, ex);
		}

		public void AddSuccessor(ICommandExecutorChain executor)
		{
			if(next == null)
				next = executor;
			else
				next.AddSuccessor(executor);
		}

		public void Execute(T command, CPUResources resources)
		{
			concreteExecutors[command.Name].Execute(command, resources);
		}

		public void Execute(Command command, CPUResources resources)
		{
			if (command is T concreteCommand)
				Execute(concreteCommand, resources);
			else if (next != null)
				next.Execute(command, resources);
			else
				throw new CommandTypeNotFoundException($"Handler for type {command.GetType()} not found!");
		}
	}
}
