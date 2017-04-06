using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitPatterns
{
    public interface ILog
    {
        void Log();
    }

    public abstract class Logger : ILog
    {
        public virtual void Log()
        {
            throw new NotImplementedException();
        }
    }

    public class CoolLogger : Logger
    {
        public override void Log()
        {
            Console.WriteLine("Hi hello!");
        }
    }

    public class BadLogger : Logger
    {
        public override void Log()
        {
            Console.WriteLine("Bad bad..");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Logger logger;
            Random random = new Random();
            if (random.NextDouble() > .5)
                logger = new CoolLogger();
            else
                logger = new BadLogger();
            logger.Log();
            Console.ReadKey();
        }
    }
}
