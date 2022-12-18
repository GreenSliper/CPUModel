using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Resources
{
	public class Registers
	{
		public enum Flags
		{
			Zero = 'Z',
			Carry = 'C',
			Sign = 'S',
			Overflowing = 'O',
			Iterrapt = 'I',
			StepByStep = 'T',
			SuperUser = 'U'
		}

		public readonly int[] ints;
		public readonly float[] floats;

		public Dictionary<Flags, bool> flags = new();

		public Registers(int intCount, int floatCount)
		{
			ints = new int[intCount];
			floats = new float[floatCount];
			foreach (var flag in Enum.GetValues(typeof(Flags)))
				flags.Add((Flags)flag, false);
		}
	}
}
