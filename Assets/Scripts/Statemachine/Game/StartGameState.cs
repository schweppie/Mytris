namespace JP.Mytrix.Statemachine.Game
{
    public class StartGameState : BaseGameState
    {
        public override void Enter()
        {
            gameStateMachine.ChangeTo(GameState.SpawnTetrino);
        }
    }
}
