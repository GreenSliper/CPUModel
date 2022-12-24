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
			Zero = 0,
			Carry,
			Sign,
			Overflowing,
			Iterrupt,
			TStepByStep,
			USuperUser
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

		public void Print()
		{
			Console.WriteLine();
			Console.Write("Flags: ");
			foreach (var flag in flags.OrderBy(x=>(int)x.Key))
				Console.Write($"{flag.Key.ToString()[0]}:{(flag.Value?1:0)}; ");
			Console.WriteLine();
			Console.WriteLine("Registers: \tint\tfloat");
			for (int i = 0; i < Math.Max(ints.Length, floats.Length); i++)
			{
				if(i < ints.Length)
					Console.Write($"\t\t{ints[i]}");
				else
					Console.Write("\t\t");
				if (i < floats.Length)
					Console.Write($"\t{floats[i]}");
				Console.WriteLine();
			}
		}
	}
}
