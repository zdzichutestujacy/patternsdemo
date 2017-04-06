using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitPatterns
{
    class Builder
    {
        public Logger Build(ILogBuilder LogBuilder)
        {
            LogBuilder.BuildLevel();
            return LogBuilder.Logger;
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
}
