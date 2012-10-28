using System;
using System.Collections.Generic;
using System.Linq;

namespace GA.Core.Util
{
    public static class ControlFlowHelper
    {
        private static Dictionary<string, int> _states = new Dictionary<string, int>();

        static ControlFlowHelper()
        {
            var pos = 0;

            _states.Add(JobStates.Uninitialized, pos++);
            _states.Add(JobStates.TargetsAccepted, pos++);
            _states.Add(JobStates.ReportsGenerated, pos++);
            _states.Add(JobStates.DeliveryOptionsAccepted, pos++);
            _states.Add(JobStates.DeliverablesConfirmed, pos++);
            _states.Add(JobStates.DeliveryInProgress, pos++);
            _states.Add(JobStates.DeliveryCompleted, pos++);
        }

        public static bool IsBeforeState(string currentState, string targetState)
        {
            return !CanViewState(currentState, targetState);
        }


        public static bool CanViewState(string currentState, string targetState)
        {
            if (!_states.ContainsKey(currentState)) return false;
            if (!_states.ContainsKey(targetState)) return false;

            var val = _states[currentState];
            var target = _states[targetState];

            return val >= target;
        }

        public static string GetInitialState()
        {
            return _states.Keys.First();
        }

        public static string GetNextState(string state)
        {
            if (state == null) throw new ArgumentNullException("state");
            if (!_states.ContainsKey(state)) throw new ArgumentException("Unknown State: " + state, "state");

            var val = _states[state];
            val++;
            foreach (var item in _states.Keys)
            {
                var q = _states[item];
                if (q == val) return item;
            }
            throw new InvalidOperationException("Failed State change from " + state + "!!!");
        }
    }

    public static class JobStates
    {
        public const string Uninitialized = "Uninitialized";
        public const string TargetsAccepted = "Targets Accepted";
        public const string ReportsGenerated = "Reports Generated";
        public const string DeliveryOptionsAccepted = "Delivery Options Accepted";
        public const string DeliverablesConfirmed = "Deliverables Confirmed";
        public const string DeliveryInProgress = "Delivery In Progress";
        public const string DeliveryCompleted = "Delivery Completed";
    }
}
