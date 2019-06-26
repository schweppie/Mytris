using UnityEngine;

namespace JP.Mytrix.Statemachine.Game
{
    public class SpawnTetrinoState : BaseGameState
    {
        public override void Enter()
        {
            tetrinoController.SpawnTetrino();
            gameStateMachine.ChangeTo(GameState.MoveTetrino);
        }

        public override void Exit()
        {
        }
    }
}
