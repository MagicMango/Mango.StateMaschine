using Mango.StateMaschine.Interfaces;
using Mango.StateMaschine.States;
using System;
using System.Collections.Generic;

namespace Mango.StateMaschine.Maschines
{
    public class HistoryStateMaschine : IHistroyStateMaschine
    {
        public IState CurrentState { get; set; }
        public Queue<IState> States { get; set; }
        public IServiceProvider ServiceCollection { get; set; }

        public HistoryStateMaschine()
        {
            States = new Queue<IState>();
        }
        public void Start()
        {
            SetStateAndExcecute(GetService<StateOne>());
        }

        public TService GetService<TService>() where TService : class
        {
            return (TService)ServiceCollection.GetService(typeof(TService));
        }
        public void SetStateAndExcecute(IState state)
        {
            CurrentState = state;
            States.Enqueue(state);
            state.Excecute(this);
        }
    }
}
