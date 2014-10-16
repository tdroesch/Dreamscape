using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FSM
{
    /// <summary>
    /// Finite State Machine Context Class.
    /// Pass an init action in the constructor to configure
    /// the context map data
    /// </summary>
    sealed class FSMContext
    {
        private FSMState currentState;
        private FSMAction initAction;
        private Dictionary<string, object> contextMap;

        /// <summary>
        /// Used by the FSM to configure the context.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="data"></param>
        public void put(string name, object data)
        {
            contextMap.Add(name, data);
        }

        /// <summary>
        /// Used by the FSM to configure the context.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Object get(string name)
        {
            return contextMap[name];
        }

        /// <summary>
        /// Have the FSM respond to an event.
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="data"></param>

        public void dispatch(string eventName, object data)
        {
            currentState = currentState.dispatch(this, eventName, data);
        }

        /// <summary>
        /// Instantiate a context with the initial State and a configuring Action
        /// </summary>
        /// <param name="initState"></param>
        /// <param name="initAction"></param>
        public FSMContext(FSMState initState, FSMAction initAction = null)
        {
            currentState = initState;
            this.initAction = initAction;
            contextMap = new Dictionary<string, object>();
            if (this.initAction != null) this.initAction.execute(this, null);
        }
    }
}
