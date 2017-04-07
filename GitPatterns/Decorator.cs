using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitPatterns
{
    abstract class Programmer
    {
        public virtual string Nickname { get; set; }
        public virtual string Info { get; set; }
    }

    class RegularProgrammer : Programmer
    {
        public override string Info
        {
            get
            {
                return Nickname;
            }
        }
    }

    abstract class ProgrammerDecorator : Programmer
    {
        private Programmer _BaseProgrammer = null;

        public ProgrammerDecorator(Programmer Programmer)
        {
            _BaseProgrammer = Programmer;
        }

        public override string Info
        {
            get
            {
                return _BaseProgrammer.Info;
            }
        }
    }

    class CSharpProgrammerDecorator : ProgrammerDecorator
    {
        public string Level { get; set; }
        public CSharpProgrammerDecorator(Programmer Programmer) : base(Programmer)
        {
        }

        public override string Info
        {
            get
            {
                return base.Info + string.Format("\nKnows C# {0}", Level);
            }
        }
    }

    class JSProgrammerDecorator : ProgrammerDecorator
    {
        public string Level { get; set; }
        public JSProgrammerDecorator(Programmer Programmer) : base(Programmer)
        {
        }

        public override string Info
        {
            get
            {
                return base.Info + string.Format("\nKnows JS {0}", Level);
            }
        }
    }

    class SkillDecorator : ProgrammerDecorator
    {
        public string Skill { get; set; }
        public SkillDecorator(Programmer Programmer) : base (Programmer)
        {

        }

        public override string Info => base.Info + string.Format("\nis {0}", Skill);
    }
}
