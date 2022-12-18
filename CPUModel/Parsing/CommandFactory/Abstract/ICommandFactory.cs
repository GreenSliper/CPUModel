using Domain.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUModel.Parsing.CommandFactory.Abstract
{
    public interface ICommandFactory
    {
        public Command CreateCommand(string[] words);
    }
}
