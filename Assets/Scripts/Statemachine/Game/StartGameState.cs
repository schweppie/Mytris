namespace JP.Mytrix.Statemachine.Game
{
    public class StartGameState : BaseGameState
    {
        public override void Enter()
        {
            gridController.Setup(10,14);
            tetrinoController.Setup();

            gameStateMachine.ChangeTo(GameState.SpawnTetrino);
        }
    }
}
