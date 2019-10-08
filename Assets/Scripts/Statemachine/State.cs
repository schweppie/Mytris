using UnityEngine;

namespace JP.Mytrix.Statemachine
{
    public abstract class State
    {
        public virtual void Initialize()
        {
        }
     
        public virtual void Enter()
        {
            Debug.Log("Entered state " + this.GetType().ToString());
        }

        public virtual void Update()
        {
        }

        public virtual void Exit()
        {
        }
    }
}
