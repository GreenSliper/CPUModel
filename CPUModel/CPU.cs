using CPUModel.Execution;
using CPUModel.Parsing;
using Domain.Resources;
using System;
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
		public CPU(ICommandExecutor executor, CPUResources resources)
		{
			this.executor = executor;
			this.resources = resources;
		}

		public void RunCode(IParser parser, IASMSource source)
		{
			var commands = parser.ParseASM(source);
			foreach (var command in commands)
			{
				executor.Execute(command, resources);
			}
		}
	}
}
