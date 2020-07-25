using Mango.StateMaschine.Interfaces;
using System;

namespace Mango.StateMaschine.States
{
    public class StateThree : IState
    {
        public void Excecute(IStateMaschine stateMaschine)
        {
            Console.WriteLine("Excecuting " + nameof(StateThree));
            Console.WriteLine("Welcome to the sink");
        }
    }
}