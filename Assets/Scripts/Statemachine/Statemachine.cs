using System;
using System.Collections.Generic;
using System.Linq;

namespace JP.Mytrix.Statemachine
{
    public abstract class StateMachine<T> where T : Enum
    {
        protected Dictionary<T, State> states;

        protected T currentStateId;

        private T startStateId;

        public StateMachine()
        {
            states = new Dictionary<T, State>();
            startStateId = GetInitialState();

            running = false;
        }       

        protected abstract T GetInitialState();

        private bool running = false;

        public void AddState(T stateId, State state) 
        {
            if(states.ContainsKey(stateId))
                states[stateId] = state;
            else
                states.Add(stateId, state);
        }

        public void Start()
        {
            foreach(var pair in states) pair.Value.Initialize();

            currentStateId = startStateId;
            states[currentStateId].Enter();
            
            running = true;
        }

        public void ChangeTo(T stateId)
        {
            states[currentStateId].Exit();

            currentStateId = stateId;

            states[currentStateId].Enter();
        }

        public void Update()
        {
            if(!running)
                return;

            states[currentStateId].Update();
        }

        public void Stop()
        {
            if(running)
                states[currentStateId].Exit();

            running = false;
        }
    }
}
