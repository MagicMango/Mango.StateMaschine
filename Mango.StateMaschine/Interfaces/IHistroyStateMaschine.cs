using System.Collections.Generic;

namespace Mango.StateMaschine.Interfaces
{
    public interface IHistroyStateMaschine: IStateMaschine
    {
        public Queue<IState> States { get; set; }
    }
}
