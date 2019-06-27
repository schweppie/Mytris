using System.Collections;
using JP.Mytrix.Input;
using UnityEngine;

namespace JP.Mytrix.Statemachine.Game
{
    public class MoveTetrinoState : BaseGameState
    {
        private Coroutine moveTetrinoRoutine;

        public override void Enter()
        {
            moveTetrinoRoutine = tetrinoController.StartCoroutine(MoveTetrinoEnumerator());
            inputController.OnInputDownEvent += OnInputDownEvent;
        }

        private void OnInputDownEvent(Inputs input)
        {
            switch(input)
            {
                case Inputs.Up:
                    if(tetrinoController.CanRotateTetrino())
                        tetrinoController.RotateTetrino();
                    break;
                case Inputs.Right:
                    if(tetrinoController.CanMoveTetrino(1,0))
                        tetrinoController.MoveTetrino(1,0);
                    break;
                case Inputs.Down:
                    if(tetrinoController.CanMoveTetrino(0, -1))
                        tetrinoController.MoveTetrino(0, -1);                
                    break;                
                case Inputs.Left:
                    if(tetrinoController.CanMoveTetrino(-1, 0))
                        tetrinoController.MoveTetrino(-1, 0);                
                    break;
            }
        }
        
        private IEnumerator MoveTetrinoEnumerator()
        {
            while(true)
            {
                yield return new WaitForSeconds(tetrinoController.MoveDuration);
                
                if(tetrinoController.CanMoveTetrino(0, -1))
                    tetrinoController.MoveTetrino(0, -1);
                else
                    gameStateMachine.ChangeTo(GameState.AddToGrid);
            }
        }

        public override void Exit()
        {
            tetrinoController.StopCoroutine(moveTetrinoRoutine);
            inputController.OnInputDownEvent -= OnInputDownEvent;
        }
    }
}
