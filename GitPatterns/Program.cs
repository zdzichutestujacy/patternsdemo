using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitPatterns
{
    enum LoggerType
    {
        Cool,
        Bad
    }

    interface ILog
    {
        void Log();
    }

    interface ILogBuilder
    {
        void BuildLevel();
        Logger Logger { get; }
    }

    class Builder
    {
        public Logger Build(ILogBuilder LogBuilder)
        {
            LogBuilder.BuildLevel();
            return LogBuilder.Logger;
        }
    }

    abstract class Logger : ILog
    {
        public virtual int level { get; set; } // some abstract prop
        public virtual void Log()
        {
            throw new NotImplementedException();
        }
    }

    sealed class CoolLoggerBuilder : ILogBuilder
    {
        private Logger _logger;

        public CoolLoggerBuilder()
        {
            _logger = new CoolLogger();
        }

        public Logger Logger
        {
            get
            {
                return _logger;
            }
        }

        public void BuildLevel()
        {
            _logger.level = 5;
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

    /*
     * factory method 
     */
     
    class LoggerFactory
    {
        public Logger CreateLogger (LoggerType type)
        {
            switch (type)
            {
                case LoggerType.Cool:
                    return new CoolLogger();
                default:
                    return new BadLogger();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Logger logger;

            // for abstract factory example

            //Random random = new Random();
            //if (random.NextDouble() > .5)
            //    logger = new CoolLogger();
            //else
            //    logger = new BadLogger();

            // for builder pattern example

            //Builder builder = new Builder();
            //logger = builder.Build(new CoolLoggerBuilder());
            //Console.WriteLine(logger.level);
            //logger.Log();

            LoggerFactory loggerFactory = new LoggerFactory();
            logger = loggerFactory.CreateLogger(LoggerType.Cool);
            logger.Log();
        }
    }
}
