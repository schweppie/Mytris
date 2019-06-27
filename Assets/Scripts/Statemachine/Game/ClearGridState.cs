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
            JP.Mytrix.Gameplay.Grid grid = gridController.Grid;    

            bool gridFellDown = false;
            while(row < grid.Height)
            {
                if(grid.IsRowFull(row))
                {
                    grid.ClearRow(row);
                    grid.MoveGridDown(row);
                    gridFellDown = true;
                    row--;
                }

                row++;
            }

            if(gridFellDown)
                yield return new WaitForSeconds(tetrinoController.MoveDuration);

            gameStateMachine.ChangeTo(GameState.SpawnTetrino);

            yield return null;
        }

        public override void Exit()
        {
            gridController.StopAllCoroutines();
        }
     }
}
