namespace JP.Mytrix.Statemachine.Game
{
    public class GameStateMachine : StateMachine<GameState>
    {
        public GameStateMachine() : base()
        {
            AddState(GameState.StartGame, new StartGameState());
            AddState(GameState.SpawnTetrino, new SpawnTetrinoState());
            AddState(GameState.MoveTetrino, new MoveTetrinoState());
            AddState(GameState.AddToGrid, new AddTetrinoToGridState());
            AddState(GameState.ClearGrid, new ClearGridState());
        }

        protected override GameState GetInitialState()
        {
            return GameState.StartGame;
        }
    }
}
