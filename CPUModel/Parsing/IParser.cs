using CPUModel.Parsing.ASMSource;
using Domain.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUModel.Parsing
{
	public interface IParser
	{
		IEnumerable<Command> ParseASM(IASMSource source);
	}
}
