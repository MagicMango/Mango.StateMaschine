using Mango.StateMaschine.Interfaces;
using System;

namespace Mango.StateMaschine.States
{
    internal class StateTwo : IState
    {
        public StateTwo()
        {
            Console.WriteLine(nameof(StateTwo));
        }

        public void Excecute(IStateMaschine stateMaschine)
        {
            Console.WriteLine("Excecuting " + nameof(StateTwo));
            Console.WriteLine("Finish Excecuting");
        }
    }
}