using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitPatterns
{

    enum StateName
    {
        On,
        Off
    }

    public interface IState
    {
        void SwitchOn();
        void SwitchOff();

        // you could add:
        //void Connect(string wifi);
        //void Disconnect();
        //void Scan();
    }

    class Wlan : IState
    {
        private IState _State;

        private Dictionary<IState, StateName> _States;

        const string Name = "SuperX1000";

        public Wlan()
        {
            _States = new Dictionary<IState, StateName>();
            _States.Add(new SwitchedOff(this), StateName.Off);
            _States.Add(new SwitchedOn(this), StateName.On);
            _State = _States.Where(a => a.Value == StateName.Off).SingleOrDefault().Key;
        }

        public Dictionary<IState, StateName> States
        {
            get
            {
                return _States;
            }
        }

        public IState State
        {
            get
            {
                return _State;
            }
            set
            {
                _State = value;
            }
        }

        public void SwitchOn()
        {
            _State.SwitchOn();
        }

        public void SwitchOff()
        {
            _State.SwitchOff();
        }
    }

    class SwitchedOff : IState
    {
        private Wlan _Wlan;

        public SwitchedOff(Wlan Wlan)
        {
            _Wlan = Wlan;
        }

        public void SwitchOff()
        {
            Console.WriteLine("Is already switched off..");
        }

        public void SwitchOn()
        {
            Console.WriteLine("Powering on..");
            _Wlan.State = _Wlan.States.Where(a => a.Value == StateName.On).SingleOrDefault().Key;
            Console.WriteLine("Wlan ON");
        }
    }

    class SwitchedOn : IState
    {
        private Wlan _Wlan;

        public SwitchedOn(Wlan Wlan)
        {
            _Wlan = Wlan;
        }

        public void SwitchOff()
        {
            Console.WriteLine("Powering off..");
            _Wlan.State = _Wlan.States.Where(a => a.Value == StateName.On).SingleOrDefault().Key;
            Console.WriteLine("Wlan OFF");
        }

        public void SwitchOn()
        {
            Console.WriteLine("Wlan is working..");
        }
    }
}
