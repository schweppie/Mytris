namespace JP.Mytrix.Statemachine.Game
{
    public class StartGameState : BaseGameState
    {
        public override void Enter()
        {
            gridController.Setup(10,20);
            tetrinoController.Setup();

            gameStateMachine.ChangeTo(GameState.SpawnTetrino);
        }
    }
}
