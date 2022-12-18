using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUModel.Parsing
{
	public class FileASMSource : IASMSource
	{
		class FileASMEnumerator : IEnumerator<string[]>
		{
			StreamReader strr;
			public FileASMEnumerator(string path)
			{
				if(!File.Exists(path))
					throw new FileNotFoundException();
				strr = new StreamReader(path);
			}
			public string[] Current { get; private set; } = null!;

			object IEnumerator.Current => Current;

			public void Dispose()
			{
				strr.Dispose();
			}

			public bool MoveNext()
			{
				var line = "";
				if ((line = strr.ReadLine()) != null)
				{
					Current = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
					return true;
				}
				return false;
			}

			public void Reset()
			{
				strr.BaseStream.Position = 0;
				strr.DiscardBufferedData();
			}
		}

		string path;

		public FileASMSource(string path)
		{
			this.path = path;
		}

		public IEnumerator<string[]> GetEnumerator() => new FileASMEnumerator(path);
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}
