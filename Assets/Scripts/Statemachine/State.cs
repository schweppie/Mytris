namespace JP.Mytrix.Statemachine
{
    public abstract class State
    {
        public virtual void Initialize()
        {
        }
     
        public virtual void Enter()
        {
        }

        public virtual void Update()
        {
        }

        public virtual void Exit()
        {
        }
    }
}
