using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FSM
{
    /// <summary>
    /// Finite State Machine Transition Class.
    /// Create Transitions to move between States.
    /// Has a target State and an Action that will
    /// execute every time this transition is made.
    /// </summary>
    sealed class FSMTransition
    {
        private FSMState target;
        private FSMAction transAction;

        /// <summary>
        /// Executes the Transitions Action and returns its target State.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public FSMState execute(FSMContext context, object data)
        {
            if (transAction != null) transAction.execute(context, data);
            return target;
        }

        /// <summary>
        /// Constructor gets a target State and an optional Action.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="transAction"></param>
        public FSMTransition(FSMState target, FSMAction transAction = null)
        {
            this.target = target;
            this.transAction = transAction;
        }
    }
}
