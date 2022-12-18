using CPUModel.Parsing.CommandFactory.Abstract;
using Domain.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUModel.Parsing
{
	public class Parser : IParser
	{
		ICommandFactory commandFactory;
		public Parser(ICommandFactory commandFactory)
		{
			this.commandFactory = commandFactory;
		}
		public IEnumerable<Command> ParseASM(IASMSource source)
		{
			foreach (var lineWords in source)
			{
				yield return commandFactory.CreateCommand(lineWords);
			}
		}
	}
}
