using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_Problem.Events
{
    class EventSources
    {
        public event EventHandler<EventHandlerArgs> Event;

        public void ConsoleWrite(string textForWrite)
        {
            Event.Invoke(this, new EventHandlerArgs());
        }
    }
}
