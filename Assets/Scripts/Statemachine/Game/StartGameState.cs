using UnityEngine;

namespace JP.Mytrix.Statemachine.Game
{
    public class StartGameState : BaseGameState
    {
        public override void Enter()
        {
            Debug.Log("Enter StartGameState");

            gameStateMachine.ChangeTo(GameState.MoveTetrino);
        }

        public override void Exit()
        {
            Debug.Log("Exit StartGameState");
        }
    }
}
