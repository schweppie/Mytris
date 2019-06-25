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
            locator.ActivateMenu();
        }
    }
}
