// See https://aka.ms/new-console-template for more information
using CommandExecutors;
using CPUModel;
using CPUModel.Execution;
using CPUModel.Parsing;
using CPUModel.Parsing.CommandFactory;
using CPUModel.Parsing.CommandFactory.Abstract;
using Domain.Execution;
using Domain.Execution.Commands;

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


ICommandExecutor ConfigureExecution()
{
	//build execution chain
	ICommandExecutorChain executor = new CommandExecutorChain<CommandRDSS>(CollectConcreteExecutors<CommandRDSS>());
	//executor.AddSuccessor(new CommandExecutorChain<CommandRDS>(CollectConcreteExecutors<CommandRDS>()));
	return executor;
}

ICommandFactory ConfigureParsing()
{
	ICommandFactory factory = new CommandRDSSFactory(commandsTypes[typeof(CommandRDSS)]);
	return factory;
}

ICommandExecutor commandExecutor = ConfigureExecution();

CPU cpu = new CPU(commandExecutor);
cpu.RunCode(new Parser(ConfigureParsing()), new FileASMSource("code.txt"));