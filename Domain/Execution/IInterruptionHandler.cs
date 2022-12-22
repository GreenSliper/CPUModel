using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Execution
{
	public interface IInterruptionHandler
	{
		Type InterruptionType { get; }
		IEnumerable<Command> GetInterruptionCommands();
	}

	public interface IConcreteInterruptionHandler<T> : IInterruptionHandler
		where T : InterruptionException
	{
		Type IInterruptionHandler.InterruptionType { get => typeof(T); }
	}
}
