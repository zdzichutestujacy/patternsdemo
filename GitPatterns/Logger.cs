using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitPatterns
{
    interface ILog
    {
        void Log();
    }

    interface ILogBuilder
    {
        void BuildLevel();
        Logger Logger { get; }
    }

    abstract class Logger : ILog
    {
        public virtual int level { get; set; } // some abstract prop
        public virtual void Log()
        {
            throw new NotImplementedException();
        }
    }

    class CoolLogger : Logger
    {
        public override void Log()
        {
            Console.WriteLine("Hi hello!");
        }
    }

    class BadLogger : Logger
    {
        public override void Log()
        {
            Console.WriteLine("Bad bad..");
        }
    }
}
