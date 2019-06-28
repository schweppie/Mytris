using System.Collections;
using UnityEngine;

namespace JP.Mytrix.Statemachine.Game
{
    public class ClearGridState : BaseGameState
    {
        private Coroutine clearGridRoutine;

        public override void Enter()
        {
            clearGridRoutine = gridController.StartCoroutine(ClearGridEnumerator());
        }

        private IEnumerator ClearGridEnumerator()
        {
            int row=0;
            Gameplay.Grid grid = gridController.Grid;    

            bool gridFellDown = false;
            while(row < grid.Height)
            {
                if(grid.IsRowFull(row))
                {
                    grid.ClearRow(row);
                    grid.MoveGridDown(row);
                    gridFellDown = true;
                    row--;

                    cameraController.AddTrauma(0.3f);
                    yield return new WaitForSeconds(0.17f);
                }

                row++;
            }

            gameStateMachine.ChangeTo(GameState.SpawnTetrino);

            yield return null;
        }

        public override void Exit()
        {
            gridController.StopAllCoroutines();
        }
     }
}
