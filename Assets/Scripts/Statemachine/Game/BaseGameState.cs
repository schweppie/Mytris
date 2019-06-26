using JP.Mytrix.Flow;
using JP.Mytrix.Gameplay;
using JP.Mytrix.Input;

namespace JP.Mytrix.Statemachine.Game
{
    public class BaseGameState : State
    {
        protected TetrinoController tetrinoController;
        protected GameStateMachine gameStateMachine;

        protected InputController inputController;

        public override void Initialize()
        {
            tetrinoController = Locator.Instance.Get<TetrinoController>();
            gameStateMachine = Locator.Instance.Get<GameStateMachine>();
            inputController = Locator.Instance.Get<InputController>();
        }
    }
}
