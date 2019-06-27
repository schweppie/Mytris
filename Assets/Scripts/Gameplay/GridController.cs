using UnityEngine;

namespace JP.Mytrix.Gameplay
{
    public class GridController : MonoBehaviour
    {
        public Grid Grid { get; private set;}

        public void Setup(int width, int height)
        {
            Grid = new Grid(width, height);
        }

        private void Update()
        {
            if(Grid!=null)
                Grid.DebugDraw();
        }
    }
}
