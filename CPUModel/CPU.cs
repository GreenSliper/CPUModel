using CPUModel.Execution;
using CPUModel.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUModel
{
	public class CPU
	{
		ICommandExecutor executor;
		public CPU(ICommandExecutor executor)
		{
			this.executor = executor;
		}

		public void RunCode(IParser parser, IASMSource source)
		{
			var commands = parser.ParseASM(source);
			foreach (var command in commands)
			{
				executor.Execute(command);
			}
		}
	}
}
