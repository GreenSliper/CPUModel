using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Resources
{
	public abstract class Port
	{
		protected int[] dataPortPins = null!;
		public abstract void SendDataToPin(int dataPortPin, int value);
		public abstract int ReceiveDataToPin(int dataPortPin);
		public int GetCountPinsInPort() { return dataPortPins.Length; }

	}
}
