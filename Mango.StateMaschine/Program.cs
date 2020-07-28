using Mango.StateMaschine.Extensions;
using Mango.StateMaschine.Filter;
using Mango.StateMaschine.Interfaces;
using Mango.StateMaschine.Maschines;
using Mango.StateMaschine.Models;
using Mango.StateMaschine.States;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace Mango.StateMaschine
{
    class Program
    {
        static void Main(string[] args)
        {
            #region StateMaschine
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

            bool run = true;

            Task.Run(() =>
            {
                while (run)
                {
                    Console.WriteLine(string.Format("Time: {0} ms, State: {1}", DateTime.Now.ToString("fffff") ,stateMaschine.CurrentState?.GetType().Name ?? "Not started yet"));
                }
            }).ConfigureAwait(false);

            stateMaschine.Start();
            run = false;

            foreach (var state in stateMaschine.States)
            {
                Console.WriteLine(string.Format("State {0}", state.GetType().Name));
            }
            #endregion

            var filterprops = new FilterQueryObject<ObjectToFilter>() 
            { 
                Object = new[] { new ObjectToFilter() { Id = 5, MyString = "Hello" } },
                PropertieFilters = new List<FilterProperty>(new [] { 
                    new FilterProperty() 
                    {  
                        Method = "Contains",
                        Property = "MyString",
                        Value = "Hello"
                    } 
                })
            };

            var where = filterprops.ToWhereClause();
            var objects = filterprops.GetObjectValues();

            var r = filterprops.Object.AsQueryable().Where(where, objects).ToArray();

            Console.ReadKey();
        }
    }
}
