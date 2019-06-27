using JP.Mytrix.Visualization;
using UnityEngine;

namespace JP.Mytrix.Gameplay
{
    public class BlockVisualizer : DataVisualizer<Block>
    {
        [SerializeField]
        private Renderer renderer;

        private Block block;
        
        private Vector3 targetPosition;
        
        public override void Setup(Block block)
        {
            this.block = block;
            
            transform.position = new Vector3(block.X, block.Y, 0);
            block.PositionUpdatedEvent += OnPositionUpdatedEvent;

            block.OnDisposeEvent += OnDisposeEvent;

            targetPosition = transform.position;

            transform.position = targetPosition;
        }

        public void SetColor(Color color)
        {
            renderer.material.SetColor("_Color", color);
        }

        private void OnPositionUpdatedEvent(int x, int y)
        {
            targetPosition.x = x;
            targetPosition.y = y;

            //transform.position = new Vector3(x, y, 0);
        }
        
        private void Update()
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, 0.3f);
        }


        private void OnDisposeEvent()
        {
            block.PositionUpdatedEvent -= OnPositionUpdatedEvent;
            block.OnDisposeEvent -= OnDisposeEvent;

            Destroy(this.gameObject);
        }
    }
}
