using CPUModel.Parsing.Exceptions;
using Domain.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUModel.Parsing.CommandFactory.Abstract
{
    public abstract class AbstractCommandFactoryChain<T> : ICommandFactoryChain where T : Command
    {
        ICommandFactoryChain next = null!;

        HashSet<string> supportedCommands = new HashSet<string>();
        public AbstractCommandFactoryChain(IEnumerable<string> supportedCommands)
        {
            this.supportedCommands = new HashSet<string>(supportedCommands);
        }

        public void AddSuccessor(ICommandFactoryChain factory)
        {
            if (next == null)
                next = factory;
            else
                next.AddSuccessor(factory);
        }

        public Command CreateCommand(string[] words)
        {
            if (words == null || !words.Any())
                throw new CommandParseException("Empty command cannot be parsed");
            if (supportedCommands.Contains(words[0]))
                return ProduceCommand(words);
            else
                return next.CreateCommand(words);
        }

        protected abstract T ProduceCommand(string[] words);
    }
}
