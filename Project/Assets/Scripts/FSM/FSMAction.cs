using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FSM
{
    /// <summary>
    /// Finite State Machine Action Interface
    /// Define new Classes that inherit from Action to make changes
    /// to the Context while navigating the FSM.
    /// </summary>
    interface FSMAction
    {
        /// <summary>
        /// Modify the Context based on param data.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="data"></param>
        void execute(FSMContext context, object data);
    }
}
