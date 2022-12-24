using Domain.Exceptions;
using Domain.Execution.Commands;
using Domain.Execution;
using Domain.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandExecutors.Arithmetic.Integer.Logical
{
    internal class CmpExecutor : IConcreteCommandExecutor<CommandRDS>
    {
        public string Command => "CMP";

        public void Execute(CommandRDS command, CPUResources resources)
        {
            int ans = 0;
            try
            {
                ans = checked(resources.regs.ints[command.RegisterDestination] - resources.regs.ints[command.RegisterSource]);
            }
            catch
            {
                resources.regs.flags[Registers.Flags.Overflowing] = true;
            }
            resources.regs.flags[Registers.Flags.Zero] = ans == 0;
            resources.regs.flags[Registers.Flags.Sign] = ans < 0;
            resources.regs.flags[Registers.Flags.Carry] = resources.regs.flags[Registers.Flags.Overflowing];
        }
    }
}
