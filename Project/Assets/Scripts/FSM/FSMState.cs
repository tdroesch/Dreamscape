using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FSM
{
    /// <summary>
    /// Finite State Machine State Class
    /// Contains two actions to be executed everytime the state is entered or exited.
    /// Holds a Transition table the tranlates events into Transitions
    /// Instantiate with name and optional entry and exit actions.
    /// </summary>
    sealed class FSMState
    {
        private FSMAction entryAction;
        private FSMAction exitAction;
        private string name;
        /// <summary>
        /// State name accessor.
        /// </summary>
        public string Name
        {
            get { return name; }
        }
        private Dictionary<string, FSMTransition> transTable;

        /// <summary>
        /// Add a Event-Transition pair to the State's Transition table.
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="transition"></param>
        public void addTransition(string eventName, FSMTransition transition)
        {
            transTable.Add(eventName, transition);
        }

        /// <summary>
        /// Execute the State's entry Action.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="data"></param>
        public void executeEntryAction(FSMContext context, object data)
        {
            if (entryAction != null) entryAction.execute(context, data);
        }

        /// <summary>
        /// Make the transition between the current State and a
        /// target State based on an event.
        /// Called by the FSMContext.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="eventName"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public FSMState dispatch(FSMContext context, string eventName, object data)
        {
            FSMTransition t;
            if (transTable.TryGetValue(eventName, out t))
            {
                if (exitAction != null) exitAction.execute(context, data);
                FSMState newState = t.execute(context, data);
                newState.executeEntryAction(context, data);
                return newState;
            }
            else return this;
        }

        /// <summary>
        /// Create a new State.
        /// Entry and Exit actions are optional.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="entryAction"></param>
        /// <param name="exitAction"></param>
        public FSMState(string name, FSMAction entryAction = null, FSMAction exitAction = null)
        {
            this.name = name;
            this.entryAction = entryAction;
            this.exitAction = exitAction;
            transTable = new Dictionary<string, FSMTransition>();
        }
    }
}
