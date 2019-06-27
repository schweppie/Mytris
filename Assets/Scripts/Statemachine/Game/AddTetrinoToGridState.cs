using UnityEngine;

namespace JP.Mytrix.Statemachine.Game
{
    public class AddTetrinoToGridState : BaseGameState
    {
        public override void Enter()
        {
            tetrinoController.AddTetrinoToBoard();
            gameStateMachine.ChangeTo(GameState.UpdateGrid);
        }
    }
}
