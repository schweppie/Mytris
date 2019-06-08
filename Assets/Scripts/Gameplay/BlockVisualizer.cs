using UnityEngine;

namespace JP.Mytrix.Gameplay
{
    public class BlockVisualizer : MonoBehaviour
    {
        private Block block;
        
        public void Setup(Block block)
        {
            this.block = block;
            
            transform.position = new Vector3(block.X, block.Y, 0);
            block.PositionUpdatedEvent += OnPositionUpdatedEvent;
        }

        private void OnPositionUpdatedEvent(int x, int y)
        {
            transform.position = new Vector3(block.X, block.Y, 0);
        }

        private void OnDestroy()
        {
            block.PositionUpdatedEvent -= OnPositionUpdatedEvent;
        }
    }
}
