using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitPatterns
{
    /*
     * factory method 
     */

    class LoggerFactory
    {
        public Logger CreateLogger(LoggerType type)
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
}
