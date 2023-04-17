using Practice_Problem.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_Problem.Abstractions
{
    interface IActinoWithTextDatas
    {
        public event EventHandler<EventHandlerArgs> Action;
        public void CompletingAction(string textForWrite);
    }
}
