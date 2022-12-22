using CPUModel.Execution;
using CPUModel.Parsing;
using Domain.Exceptions;
using Domain.Execution;
using Domain.Resources;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUModel
{
	public class CPU
	{
		CPUResources resources;
		ICommandExecutor executor;
		Dictionary<Type, IInterruptionHandler> interruptionHandlers;

		public CPU(ICommandExecutor executor, CPUResources resources, IEnumerable<IInterruptionHandler> interruptionHandlers)
		{
			this.executor = executor;
			this.resources = resources;
			this.interruptionHandlers = new();
			foreach (var handler in interruptionHandlers)
				this.interruptionHandlers.Add(handler.InterruptionType, handler);
		}

		public void RunCode(IParser parser, IASMSource source)
		{
			var commands = parser.ParseASM(source);
			resources.commandQueue = new(commands);
			while (resources.commandQueue.TryGetCommand(out var command))
			{
				try
				{
					executor.Execute(command, resources);
				}
				catch (InterruptionException e)
				{
					if (resources.regs.flags[Registers.Flags.Iterrupt])
						throw new Exception("Cannot start interruption in another interruption! You may have forgot to call IRET");
					if (!interruptionHandlers.TryGetValue(e.GetType(), out var handler))
						throw new MissingMemberException($"Interruption handler for {e.GetType()} not found!", e);
					resources.regs.Save();
					resources.commandQueue.Interruption = resources.regs.flags[Registers.Flags.Iterrupt] = true;
					resources.commandQueue.SetInterruptionCommands(handler.GetInterruptionCommands());
				}
			}
		}
	}
}
