using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitPatterns
{

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

            // for factory method example

            //LoggerFactory loggerFactory = new LoggerFactory();
            //logger = loggerFactory.CreateLogger(LoggerType.Cool);
            //logger.Log();

            Console.WriteLine(Singleton.Instance.Version);
            Singleton.Instance.Version = "2.0";
            Console.WriteLine(Singleton.Instance.Version);

        }
    }
}
