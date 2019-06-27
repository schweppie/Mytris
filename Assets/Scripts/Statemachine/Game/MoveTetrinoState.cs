using JP.Mytrix.Input;
using UnityEngine;

namespace JP.Mytrix.Statemachine.Game
{
    public class MoveTetrinoState : BaseGameState
    {
        private float lastMoveTime;

        public override void Enter()
        {
            inputController.OnInputDownEvent += OnInputDownEvent;

            lastMoveTime = Time.realtimeSinceStartup;
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

            if(!tetrinoController.CanMoveTetrino(0, -1))
                lastMoveTime = Time.realtimeSinceStartup;
        }

        public override void Update()
        {
            if(lastMoveTime + tetrinoController.MoveDuration < Time.realtimeSinceStartup)
            {
                if(tetrinoController.CanMoveTetrino(0, -1))
                    tetrinoController.MoveTetrino(0, -1);
                else
                    gameStateMachine.ChangeTo(GameState.AddToGrid);

                lastMoveTime = Time.realtimeSinceStartup;
            }
        }
        
        public override void Exit()
        {
            inputController.OnInputDownEvent -= OnInputDownEvent;
        }
    }
}
