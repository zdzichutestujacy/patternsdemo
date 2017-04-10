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

            // for singleton example

            //Console.WriteLine(Singleton.Instance.Version);
            //Singleton.Instance.Version = "2.0";
            //Console.WriteLine(Singleton.Instance.Version);

            // for adapter pattern example

            //DTOPerson person = new DTOPerson
            //{
            //    fName = "Jane",
            //    lName = "Doe",
            //    job = "whatever"
            //};
            //PersonAdapter PersonAdapter = new PersonAdapter();
            //PersonAdapter.addPerson(person);
            //foreach (var p in PersonAdapter.getPeople())
            //{
            //    Console.WriteLine("{0} {1} {2}", p.firstName, p.lastName, p.position);
            //}

            // for decorator pattern example

            //RegularProgrammer regularProgrammer = new RegularProgrammer { Nickname = "TheMe" };
            //JSProgrammerDecorator jsDecorated = new JSProgrammerDecorator(regularProgrammer) { Level = "godlike" };
            //SkillDecorator skillDecorated = new SkillDecorator(jsDecorated);
            //skillDecorated.Skill = "friendly, perceptive";
            //Console.WriteLine(skillDecorated.Info);

            // for observer pattern example

            SampleProduct coolProd = new SampleProduct { Qty = 3, Price = 19.99M };
            Console.WriteLine("Product created. Qty: {0}, Price: {1}", coolProd.Qty, coolProd.Price);

            SampleObserver observer1 = new SampleObserver();
            observer1.QtyChanged += HandleQtyChanged;
            SampleObserver observer2 = new SampleObserver((EventHandler<decimal>)HandlePriceChanged);

            coolProd.Subscribe(observer1);
            coolProd.Subscribe(observer2);

            coolProd.Qty = 2;
            coolProd.Price = 5.99M;

        }

        // methods for observer pattern 
        public static void HandleQtyChanged(object sender, int qty)
        {
            Console.WriteLine("Qty changed: {0}", qty);
        }

        public static void HandlePriceChanged(object sender, decimal price)
        {
            Console.WriteLine("Price changed: {0}", price);
        }


    }
}
