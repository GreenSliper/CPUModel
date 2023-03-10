using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Resources
{
	public class RAM
	{
		int[] mem;
		public RAM(int sizemem)
		{
			mem = new int[sizemem];
		}

		public short GetHalfWorld(int addr)
		{
			int word = 0;

			if (addr <= mem.Length)
				word = mem[addr];

			short halfWord = (short)word;
			return halfWord;
		}
		public int GetWord(int addr)
		{
			if (addr <= mem.Length)
				return mem[addr];
			return 0;
		}

		public (int, int) GetDoubleWordPaar(int addr)
		{
			int n1, n2;
			if (addr < mem.Length)
			{
				n1 = mem[addr];
				n2 = mem[addr + 1];
				return (n1, n2);
			}

			return (0, 0);
		}

		public long GetDoubleWord(int addr)
		{
			int n1, n2;
			long w1 = 0, w2 = 0;

			if (addr < mem.Length)
			{
				n1 = mem[addr];
				n2 = mem[addr + 1];

				w2 = ((long)n2) << 32;
				w1 = n1;
			}

			return w2 | w1;
		}

		public void SetWord(int addr, int value)
		{
			mem[addr] = value;
		}

		public void SetHalfWorld(int addr, short value)
		{
			if (addr <= mem.Length)
				mem[addr] = value;
		}
		public void SetDoubleWord(int addr, long value)
		{
			int n2 = (int)(value >> 32);
			int n1 = (int)(value);
			Console.WriteLine($"n2: {n2} n1: {n1}");

			if (addr < mem.Length)
			{
				mem[addr] = n1;
				mem[addr + 1] = n2;
			}

		}

		public void SetDoubleWord(int addr, int val1, int val2)
		{
			int n2 = val2;
			int n1 = val1;
			Console.WriteLine($"n2: {n2} n1: {n1}");

			if (addr < mem.Length)
			{
				mem[addr] = n1;
				mem[addr + 1] = n2;
			}

		}
		public int GetSizeMem() => mem.Length;
	}
}
