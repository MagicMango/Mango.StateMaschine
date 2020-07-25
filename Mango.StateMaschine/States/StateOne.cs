using Mango.StateMaschine.Interfaces;
using System;

namespace Mango.StateMaschine.States
{
    public class StateOne : IState
    {
        public StateOne()
        {
            Console.WriteLine(nameof(StateOne));
        }
        public void Excecute(IStateMaschine stateMaschine)
        {
            Console.WriteLine("Excecuting " + nameof(StateOne));
            if (new Random().Next(0, 2) == 1)
            {
                stateMaschine.SetStateAndExcecute(stateMaschine.GetService<StateTwo>());
            }
            else
            {
                stateMaschine.SetStateAndExcecute(stateMaschine.GetService<StateThree>());
            }
        }
    }
}
