using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitPatterns
{
    sealed class Singleton
    {
        public string Version { get; set; }
        private static readonly Singleton _instance = new Singleton();

        private Singleton()
        {
            Version = "v1.0";
        }

        public static Singleton Instance {
            get
            {
                return _instance;
            }
        }
    }
}
