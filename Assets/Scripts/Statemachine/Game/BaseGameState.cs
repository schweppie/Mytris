using JP.Mytrix.Flow;
using JP.Mytrix.Gameplay;

namespace JP.Mytrix.Statemachine.Game
{
    public class BaseGameState : State
    {
        protected TetrinoController tetrinoController;
        protected GameStateMachine gameStateMachine;

        public override void Initialize()
        {
            tetrinoController = Locator.Instance.Get<TetrinoController>();

            gameStateMachine = Locator.Instance.Get<GameStateMachine>();
        }
    }
}
