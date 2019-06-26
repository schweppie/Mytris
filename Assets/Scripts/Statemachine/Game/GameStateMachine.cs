namespace JP.Mytrix.Statemachine.Game
{
    public class GameStateMachine : StateMachine<GameState>
    {
        public GameStateMachine() : base()
        {
            AddState(GameState.StartGame, new StartGameState());
            AddState(GameState.MoveTetrino, new MoveTetrinoState());
        }

        protected override GameState GetInitialState()
        {
            return GameState.StartGame;
        }
    }
}
