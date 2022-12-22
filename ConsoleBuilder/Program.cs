// See https://aka.ms/new-console-template for more information
using CommandExecutors;
using CPUModel;
using CPUModel.Execution;
using CPUModel.Parsing;
using CPUModel.Parsing.CommandFactory;
using CPUModel.Parsing.CommandFactory.Abstract;
using Domain.Exceptions;
using Domain.Execution;
using Domain.Execution.Commands;
using Domain.Resources;

Dictionary<Type, IEnumerable<string>> commandsTypes = new();

IEnumerable<IConcreteCommandExecutor<T>> CollectConcreteExecutors<T>() where T: Command
{
	var execs = CommandAssembly.assembly //get assembly of executors
		.GetTypes() //get all types
		.Where(x =>
		{
			//type must implement IConcreteCommandExecutor interface
			var intrfc = x.GetInterface(typeof(IConcreteCommandExecutor<>).Name);
			//select types implementing this interface, which command generic type is that we're looking for
			return intrfc != null && intrfc.GetGenericArguments().FirstOrDefault() == typeof(T);
		})
		//construct the class from type
		.Select(x => (IConcreteCommandExecutor<T>)Activator.CreateInstance(x)!);
	commandsTypes.Add(typeof(T), execs.Select(x => x.Command));
	return execs;
}

IEnumerable<IConcreteInterruptionHandler<T>> CollectInterruptionHandlers<T>() where T : InterruptionException
{
	var handlers = CommandAssembly.assembly //get assembly of executors
		.GetTypes() //get all types
		.Where(x =>
		{
			//type must implement IConcreteInterruptionHandler interface
			var intrfc = x.GetInterface(typeof(IConcreteInterruptionHandler<>).Name);
			//select types implementing this interface, which command generic type is that we're looking for
			return intrfc != null && intrfc.GetGenericArguments().FirstOrDefault() == typeof(T);
		})
		//construct the class from type
		.Select(x => (IConcreteInterruptionHandler<T>)Activator.CreateInstance(x)!);
	return handlers;
}


ICommandExecutor ConfigureExecution()
{
	//build execution chain
	ICommandExecutorChain executor = new CommandExecutorChain<CommandRDSS>(CollectConcreteExecutors<CommandRDSS>());
	executor.AddSuccessor(new CommandExecutorChain<EmptyCommand>(CollectConcreteExecutors<EmptyCommand>()));
	return executor;
}

IEnumerable<IInterruptionHandler> ConfigureInterruptions()
{
	//concat all interruption handlers
	return CollectInterruptionHandlers<DivisionByZeroInterruptionException>().Cast<IInterruptionHandler>()
		.Concat(CollectInterruptionHandlers<KernelModeOperationOnlyInterruptionException>())
		.Concat(CollectInterruptionHandlers<OperationNotFoundInterruptionException>());
}

ICommandFactory ConfigureParsing()
{
	ICommandFactoryChain factory = new CommandRDSSFactory(commandsTypes[typeof(CommandRDSS)]);
	factory.AddSuccessor(new CommandRDSSFactory(commandsTypes[typeof(EmptyCommand)]));
	return factory;
}

CPUResources ConfigureCPUResources()
{
	var regs = new Registers(8, 8);
	return new CPUResources(regs);
}

ICommandExecutor commandExecutor = ConfigureExecution();

CPU cpu = new CPU(commandExecutor, ConfigureCPUResources(), ConfigureInterruptions());
cpu.RunCode(new Parser(ConfigureParsing()), new FileASMSource("code.txt"));