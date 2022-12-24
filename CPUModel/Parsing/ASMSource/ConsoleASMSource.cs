using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUModel.Parsing.ASMSource
{
	public class ConsoleASMSource : IASMSource
	{
		class ConsoleASMEnumerator : IEnumerator<string[]>
		{
			int counter = 0;
			public ConsoleASMEnumerator()
			{
				Console.WriteLine("Write ASM code in the console. To stop, write /stop");
			}
			public string[] Current { get; private set; } = null!;

			object IEnumerator.Current => Current;

			public void Dispose()
			{
				counter = 0;
			}

			public bool MoveNext()
			{
				var line = "";
				Console.Write($"[{counter++}] ");
				if ((line = Console.ReadLine()) != "/stop")
				{
					Current = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
					return true;
				}
				return false;
			}

			public void Reset()
			{
				counter = 0;
			}
		}
		public IEnumerator<string[]> GetEnumerator() => new ConsoleASMEnumerator();

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}
