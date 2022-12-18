using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUModel.Parsing
{
	/// <summary>
	/// Extends IEnumerable. Each element is an array of words
	/// </summary>
	public interface IASMSource : IEnumerable<string[]>
	{

	}
}
