using System.Collections;
using UnityEngine;

namespace JP.Mytrix.Statemachine.Game
{
    public class MoveTetrinoState : BaseGameState
    {
        public override void Enter()
        {
            Debug.Log("Enter MoveTetrinoState");

            tetrinoController.StartCoroutine(MoveTetrinoRoutine());
        }

        public override void Update()
        {

        }

        private IEnumerator MoveTetrinoRoutine()
        {
            while(true)
            {
                yield return new WaitForSeconds(1f);
                
                /*
                if(tetrinoController.CanMoveTetrinoDown())
                    tetrinoController.MoveTetrinoDown();
                    */

                Debug.Log("Move tetrino down one step");
            }
        }

        public override void Exit()
        {
            tetrinoController.StopCoroutine(MoveTetrinoRoutine());

            Debug.Log("Exit MoveTetrinoState");
        }
    }
}
