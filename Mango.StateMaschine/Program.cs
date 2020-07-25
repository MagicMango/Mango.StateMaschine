using Mango.StateMaschine.Interfaces;
using Mango.StateMaschine.Maschines;
using Mango.StateMaschine.States;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Mango.StateMaschine
{
    class Program
    {
        static void Main(string[] args)
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddTransient<StateOne>();
            serviceCollection.AddTransient<StateTwo>();
            serviceCollection.AddTransient<StateThree>();

            serviceCollection.AddTransient<IHistroyStateMaschine, HistoryStateMaschine>((services) => {
                var stateMaschine = new HistoryStateMaschine();
                stateMaschine.ServiceCollection = serviceCollection.BuildServiceProvider();
                return stateMaschine;
            });

            IHistroyStateMaschine stateMaschine = serviceCollection.BuildServiceProvider().GetService<IHistroyStateMaschine>();


            stateMaschine.Start();

            foreach (var state in stateMaschine.States)
            {
                Console.WriteLine(string.Format("State {0}", state.GetType().Name));
            }

            Console.ReadLine();
        }
    }
}
