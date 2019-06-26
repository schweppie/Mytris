using UnityEngine;

namespace JP.Mytrix.Statemachine.Game
{
    public class AddTetrinoToGridState : BaseGameState
    {
        public override void Enter()
        {
            Debug.Log("Enter AddTetrinoToGridState");

            tetrinoController.AddTetrinoToBoard();
            
            gameStateMachine.ChangeTo(GameState.UpdateGrid);
        }

        public override void Exit()
        {
            Debug.Log("Exit AddTetrinoToGridState");
        }
    }
}
