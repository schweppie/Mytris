namespace JP.Mytrix.Statemachine.Game
{
    public class UpdateGridState : BaseGameState
    {
        public override void Enter()
        {
            gameStateMachine.ChangeTo(GameState.SpawnTetrino);
        }
    }
}
