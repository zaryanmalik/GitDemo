using System;

namespace GitDemo
{
    public class Switch
    {
        public State State = new OffState();
        public void On() { State.On(this); }
        public void Off() { State.Off(this); }
        public void StandBy()
        {
            State.StandBy(this);
        }
    }

    public abstract class State
    {
        public virtual void On(Switch sw)
        {
            Console.WriteLine("Light is already on.");
        }

        public virtual void Off(Switch sw)
        {
            Console.WriteLine("Light is already off.");
        }
        public virtual void StandBy(Switch sw)
        {
            Console.WriteLine("Light is already on standby.");
        }

    }

    public class OnState : State
    {
        public OnState()
        {
            Console.WriteLine("Light turned on.");
        }
        public override void Off(Switch sw)
        {
            Console.WriteLine("Turning light off...");
            sw.State = new OffState();
        }
        public override void StandBy(Switch sw)
        {
            Console.WriteLine("");
            sw.State = new StandByState();
        }
    }

    public class OffState : State
    {
        public OffState()
        {
            Console.WriteLine("Light turned off.");
        }

        public override void On(Switch sw)
        {
            Console.WriteLine("Turning light on...");
            sw.State = new OnState();
        }
        public override void StandBy(Switch sw)
        {
            Console.WriteLine("");
            sw.State = new StandByState();
        }
    }
    public class StandByState : State
    {
        public StandByState()
        {
            Console.WriteLine("Light is on standby");
        }
        public override void Off(Switch sw)
        {
            Console.WriteLine("Stand by to off Condition...");
            sw.State = new OffState();
        }

        public override void On(Switch sw)
        {
            Console.WriteLine("Stand By to On...");
            sw.State = new OnState();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var sw = new Switch();
            sw.On();
            sw.StandBy();
            sw.StandBy();
            sw.Off();
            sw.On();
            //sw.On();
        }
    }
}
