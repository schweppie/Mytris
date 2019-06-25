using JP.Mytrix.Flow;
using JP.Mytrix.Input;
using UnityEngine;

namespace JP.Mytrix.Statemachine.Menu
{
    public class MainMenuState : State
    {
        private InputController inputController;

        public override void Initialize()
        {
            inputController = Locator.Instance.Get<InputController>();
        }

        public override void Enter()
        {
            Debug.Log("Enter menu state");

            inputController.OnInputDownEvent += OnInputDown;
        }

        private void OnInputDown(Inputs input)
        {
            if(input == Inputs.Up)
                Locator.Instance.ActivateGame();
        }

        public override void Exit()
        {
            inputController.OnInputDownEvent -= OnInputDown;
        }
    }
}
