using Domain.Execution.Commands;
using Domain.Execution;
using Domain.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandExecutors.Arithmetic.Integer
{
    internal class SubuExecutor : IConcreteCommandExecutor<CommandRDSS>
    {
        public string Command => "SUBU";

        public void Execute(CommandRDSS command, CPUResources resources)
        {
            uint ans = 0;
            try
            {
                ans = checked((uint)resources.regs.ints[command.RegisterSource1] - (uint)resources.regs.ints[command.RegisterSource2]);
            }
            catch (OverflowException)
            {
                resources.regs.flags[Registers.Flags.Overflowing] = true;
            }
            resources.regs.flags[Registers.Flags.Zero] = ans == 0;
            resources.regs.flags[Registers.Flags.Sign] = false;
            resources.regs.flags[Registers.Flags.Carry] = resources.regs.flags[Registers.Flags.Overflowing];

            resources.regs.ints[command.RegisterDestination] = (int)ans;
        }
    }
}
