using Domain.Execution.Commands;
using Domain.Execution;
using Domain.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandExecutors.Interruptions.PredefinedInterruptions;

namespace CommandExecutors.Interruptions
{
	//TODO add class library with predefined interruption codes (or place them in this lib lol)
	//load this library in this boy's constructor & move ASM code from the lib to PCI
	internal class IntExecutor : IConcreteCommandExecutor<CommandConstant>
	{
		Dictionary<int, IPredefinedInterruption> predefinedInterruptions = new();
		public IntExecutor()
		{
			var ints = CommandAssembly.assembly
			.GetTypes() //get all types
			.Where(x => x.GetInterface(typeof(IPredefinedInterruption).Name) != null)
			//construct the class from type
			.Select(x => (IPredefinedInterruption)Activator.CreateInstance(x)!);
			foreach (var interruption in ints)
				predefinedInterruptions.Add(interruption.Code, interruption);
		}

		public string Command => "INT";

		public void Execute(CommandConstant command, CPUResources resources)
		{
			if (resources.commandQueue.Interruption)
				throw new Exception("Cannot use interruption while running an interruption");
			resources.regs.Save();
			resources.commandQueue.Interruption = true;
			if (!predefinedInterruptions.ContainsKey(command.Constant))
				throw new KeyNotFoundException($"Cannot find interruption with code {command.Constant}");
			resources.commandQueue.SetInterruptionCommands(predefinedInterruptions[command.Constant].GetCommands());
		}
	}
}
