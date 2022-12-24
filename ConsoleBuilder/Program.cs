using CommandExecutors;
using CPUModel;
using CPUModel.Execution;
using CPUModel.Parsing;
using CPUModel.Parsing.ASMSource;
using CPUModel.Parsing.CommandFactory.Abstract;
using CPUModel.Parsing.CommandFactory.Implementations;
using Domain.Exceptions;
using Domain.Execution;
using Domain.Execution.Commands;
using Domain.Resources;
using SimpleConsoleMenu;

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
	executor.AddSuccessor(new CommandExecutorChain<CommandRDS>(CollectConcreteExecutors<CommandRDS>()));
	executor.AddSuccessor(new CommandExecutorChain<CommandEmpty>(CollectConcreteExecutors<CommandEmpty>()));
	executor.AddSuccessor(new CommandExecutorChain<CommandConstant>(CollectConcreteExecutors<CommandConstant>()));
	executor.AddSuccessor(new CommandExecutorChain<CommandRDC>(CollectConcreteExecutors<CommandRDC>()));
	executor.AddSuccessor(new CommandExecutorChain<CommandRD>(CollectConcreteExecutors<CommandRD>()));
	executor.AddSuccessor(new CommandExecutorChain<CommandMemory>(CollectConcreteExecutors<CommandMemory>()));
	executor.AddSuccessor(new CommandExecutorChain<CommandPort>(CollectConcreteExecutors<CommandPort>()));
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
	factory.AddSuccessor(new CommandRDSFactory(commandsTypes[typeof(CommandRDS)]));
	factory.AddSuccessor(new CommandEmptyFactory(commandsTypes[typeof(CommandEmpty)]));
	factory.AddSuccessor(new CommandConstantFactory(commandsTypes[typeof(CommandConstant)]));
	factory.AddSuccessor(new CommandRDCFactory(commandsTypes[typeof(CommandRDC)]));
	factory.AddSuccessor(new CommandRDFactory(commandsTypes[typeof(CommandRD)]));
	factory.AddSuccessor(new CommandMemoryFactory(commandsTypes[typeof(CommandMemory)]));
	factory.AddSuccessor(new CommandPortFactory(commandsTypes[typeof(CommandPort)]));
	return factory;
}

CPUResources ConfigureCPUResources()
{
	var regs = new Registers(8, 8);
	var ram = new RAM(16);
	var port = new USB();
	return new CPUResources(regs, ram, port);
}

ICommandExecutor commandExecutor = ConfigureExecution();

CPU cpu = new CPU(commandExecutor, ConfigureCPUResources(), ConfigureInterruptions());
IParser parser = new Parser(ConfigureParsing());

IMenu menu = new Menu("Main menu [CPU started, waiting]", new IMenuItem[]
	{
		new Menu("Run code", new IMenuItem[]
			{
				new MenuItem("From default file", () => cpu.RunCode(parser, new FileASMSource("code.txt"))),
				new MenuItem("From file (set path)", () =>
				{
					Console.WriteLine("Enter file local/absolute path: ");
					var path = Console.ReadLine();
					if(File.Exists(path))
						cpu.RunCode(parser, new FileASMSource(path));
					else
						Console.WriteLine("File does not exist!");
				}),
				new MenuItem("From console (JIT)", () => cpu.RunCode(parser, new ConsoleASMSource())),
			}),
		new MenuItem("Command list", () => 
		{
			foreach(var type in commandsTypes)
			{
				Console.WriteLine(type.Key.Name + ":");
				foreach(var command in type.Value.OrderBy(x=>x))
					Console.WriteLine($"\t{command}");
			}
		})
	});

menu.Select(null!);