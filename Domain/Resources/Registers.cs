using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Resources
{
	public class Registers : ISaveable
	{
		public enum Flags
		{
			Zero = 'Z',
			Carry = 'C',
			Sign = 'S',
			Overflowing = 'O',
			Iterrupt = 'I',
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

		private Registers? reserve = null;

		public void Save()
		{
			reserve = new Registers(ints.Length, floats.Length);
			Array.Copy(ints, reserve.ints, ints.Length);
			Array.Copy(floats, reserve.floats, floats.Length);
			foreach(var flag in flags.Keys)
				reserve.flags[flag] = flags[flag];
		}

		public void Restore()
		{
			if (reserve == null)
				throw new NullReferenceException("Cannot restore reserve of registers because it was not created!");
			Array.Copy(reserve.ints, ints, ints.Length);
			Array.Copy(reserve.floats, floats, floats.Length);
			foreach (var flag in flags.Keys)
				flags[flag] = reserve.flags[flag];
			reserve = null;
		}
	}
}
