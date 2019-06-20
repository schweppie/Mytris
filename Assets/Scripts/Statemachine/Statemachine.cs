using System;
using System.Collections.Generic;
using UnityEngine;

namespace JP.Mytrix.Statemachine
{
    public abstract class StateMachine<T> where T : Enum
    {
        protected Dictionary<T, State> states;

        protected T currentStateId;

        private T startStateId;

        public StateMachine(T initialStateId)
        {
            states = new Dictionary<T, State>();

            startStateId = initialStateId;
        }       

        public void AddState(T stateId, State state) 
        {
            if(states.ContainsKey(stateId))
                states[stateId] = state;
            else
                states.Add(stateId, state);
        }

        public void Start()
        {
            states[startStateId].Enter();
        }

        public void ChangeTo(T stateId)
        {
            states[currentStateId].Exit();

            currentStateId = stateId;

            states[currentStateId].Enter();
        }

        public void Update()
        {
            states[currentStateId].Update();
        }

        public void Stop()
        {
            states[currentStateId].Exit();
        }
    }

    public enum TetrisGameStates
    {
        Idle,
    }

    public class TetrisIdleState : State
    {
        public override void Enter()
        {
            Debug.Log("Enter state");
        }

        public override void Update()
        {
            Debug.Log("uPDATE " + UnityEngine.Random.Range(1,100));
        }
        
    }

    public class TetrisStateMachine : StateMachine<TetrisGameStates>
    {
        public TetrisStateMachine(TetrisGameStates initialStateId) : base(initialStateId)
        {
        }
    }
}
