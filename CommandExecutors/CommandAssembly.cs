using System.Reflection;

namespace CommandExecutors
{
	public class CommandAssembly
	{
		public static readonly Assembly assembly = typeof(CommandAssembly).Assembly;
	}
}