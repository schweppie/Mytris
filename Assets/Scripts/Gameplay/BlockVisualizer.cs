using UnityEngine;

namespace JP.Mytrix.Gameplay
{
    public class BlockVisualizer : MonoBehaviour
    {
        private Block block;
        
        private Vector3 targetPosition;
        
        public void Setup(Block block)
        {
            this.block = block;
            
            transform.position = new Vector3(block.X, block.Y, 0);
            block.PositionUpdatedEvent += OnPositionUpdatedEvent;
        }

        private void OnPositionUpdatedEvent(int x, int y)
        {
            Debug.Log("OnPositionUpdatedEvent");
            
            //transform.position = new Vector3(block.X, block.Y, 0);

            targetPosition.x = x;
            targetPosition.y = y;
        }
        
        private void Update()
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, 0.3f);
        }
        

        private void OnDestroy()
        {
            block.PositionUpdatedEvent -= OnPositionUpdatedEvent;
        }
    }
}
