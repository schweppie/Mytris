namespace JP.Mytrix.Statemachine.Game
{
    public class StartGameState : BaseGameState
    {
        public override void Enter()
        {
            base.Enter();
            gridController.Setup(10,24);
            tetrinoController.Setup();
            tetrinoSpawner.Setup();

            gameStateMachine.ChangeTo(GameState.SpawnTetrino);
        }
    }
}
