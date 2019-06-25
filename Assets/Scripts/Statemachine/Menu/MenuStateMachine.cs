namespace JP.Mytrix.Statemachine.Menu
{
    public class MenuStateMachine : StateMachine<MenuState>
    {
        public MenuStateMachine() : base()
        {
            AddState(MenuState.Main, new MainMenuState());
            AddState(MenuState.Options, new OptionsMenuState());
        }

        protected override MenuState GetInitialState()
        {
            return MenuState.Main;
        }
    }
}
