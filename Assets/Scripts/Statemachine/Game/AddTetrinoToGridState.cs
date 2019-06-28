using System.Collections;
using UnityEngine;

namespace JP.Mytrix.Statemachine.Game
{
    public class AddTetrinoToGridState : BaseGameState
    {
        private Coroutine addTetrinoToGridRoutine;

        public override void Enter()
        {

            addTetrinoToGridRoutine = gridController.StartCoroutine(AddTetrinoToGridEnumerator());
        }

        private IEnumerator AddTetrinoToGridEnumerator()
        {
            tetrinoController.AddTetrinoToBoard();
            cameraController.AddTrauma(0.3f);
            yield return new WaitForSeconds(tetrinoController.MoveDuration);
            gameStateMachine.ChangeTo(GameState.ClearGrid);
        }

        public override void Exit()
        {
            gridController.StopAllCoroutines();
        }
    }
}
