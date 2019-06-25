using JP.Mytrix.Flow;
using JP.Mytrix.Gameplay;
using UnityEngine;

namespace JP.Mytrix.Statemachine.Game
{
    public class MoveTetrinoState : State
    {
        private TetrinoController tetrinoController;

        public override void Initialize()
        {
            tetrinoController = Locator.Instance.Get<TetrinoController>();
        }

        public override void Enter()
        {
            Debug.Log("Enter MoveTetrinoState");
        }

        public override void Update()
        {

        }

        public override void Exit()
        {
            Debug.Log("Enter MoveTetrinoState");
        }
    }
}
