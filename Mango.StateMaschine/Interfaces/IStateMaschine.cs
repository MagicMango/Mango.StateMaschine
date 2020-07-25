using System;

namespace Mango.StateMaschine.Interfaces
{
    public interface IStateMaschine
    {
        public TService GetService<TService>() where TService: class;
        public IState CurrentState { get; set; }
        public void Start();
        public void SetStateAndExcecute(IState state);
    }
}
