using JP.Mytrix.Flow;
using UnityEngine;

namespace JP.Mytrix.Statemachine.Menu
{
    public class MainMenuState : State
    {
        public override void Enter()
        {
            Debug.Log("Enter menu state");
        }

        public override void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space))
                Locator.Instance.ActivateGame();
        }
    }
}
