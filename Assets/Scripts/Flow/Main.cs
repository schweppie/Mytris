using JP.Mytrix.Statemachine;
using JP.Mytrix.Statemachine.Game;
using JP.Mytrix.Statemachine.Menu;
using UnityEngine;

namespace JP.Mytrix.Flow
{
    public class Main : MonoBehaviour
    {
        [SerializeField]
        private Locator locator;

        private void Start()
        {
            locator.Initalize();
            var menuStateMachine = locator.Get<MenuStateMachine>();

            menuStateMachine.Start();
        }
    }
}
