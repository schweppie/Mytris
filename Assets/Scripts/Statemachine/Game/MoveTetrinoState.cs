using System.Collections;
using UnityEngine;

namespace JP.Mytrix.Statemachine.Game
{
    public class MoveTetrinoState : BaseGameState
    {
        private Coroutine moveTetrinoRoutine;

        public override void Enter()
        {
            moveTetrinoRoutine = tetrinoController.StartCoroutine(MoveTetrinoEnumerator());
        }

        public override void Update()
        {

        }

        private IEnumerator MoveTetrinoEnumerator()
        {
            while(true)
            {
                yield return new WaitForSeconds(1f);
                
                
                if(tetrinoController.CanMoveTetrinoDown())
                    tetrinoController.MoveTetrinoDown();
                else
                    gameStateMachine.ChangeTo(GameState.AddToGrid);
            }
        }

        public override void Exit()
        {
            tetrinoController.StopCoroutine(moveTetrinoRoutine);
        }
    }
}
