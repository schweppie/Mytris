namespace JP.Mytrix.Statemachine.Game
{
    public class GameStateMachine : StateMachine<GameState>
    {
        public GameStateMachine() : base()
        {
            AddState(GameState.StartGame, new StartGameState());
        }

        protected override GameState GetInitialState()
        {
            return GameState.StartGame;
        }
    }
}
