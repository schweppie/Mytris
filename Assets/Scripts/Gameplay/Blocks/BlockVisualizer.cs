using System.Collections;
using JP.Mytrix.Visualization;
using UnityEngine;

namespace JP.Mytrix.Gameplay.Blocks
{
    public class BlockVisualizer : DataVisualizer<Block>
    {
        [SerializeField]
        private Renderer[] renderers;

        [SerializeField]
        private Rigidbody[] rigidbodies;

        private Block block;
        
        private Vector3 targetPosition;

        private const float X_OFFSET = -5f;
        
        public override void Setup(Block block)
        {
            this.block = block;
            
            transform.position = new Vector3(block.X + X_OFFSET, block.Y, 0);
            block.PositionUpdatedEvent += OnPositionUpdatedEvent;

            block.OnDisposeEvent += OnDisposeEvent;

            targetPosition = transform.position;

            transform.position = targetPosition;
        }

        public void SetColor(Color color)
        {
            for(int i=0; i< renderers.Length; i++)
                renderers[i].material.SetColor("_Color", color);
        }

        private void OnPositionUpdatedEvent(int x, int y, PositionUpdateType updateType)
        {
            targetPosition.x = x + X_OFFSET;
            targetPosition.y = y;

            if(updateType == PositionUpdateType.Rotate)
                transform.position = new Vector3(x + X_OFFSET, y, 0);
        }
        
        private void Update()
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, 0.3f);
        }

        private IEnumerator DestructionEnumerator()
        {
            Vector3 randomDirection = new Vector3();

            for(int i=0 ; i<rigidbodies.Length ; i++)
            {
                Rigidbody rigidbody = rigidbodies[i];

                rigidbody.isKinematic = false;

                randomDirection.x = Random.Range(-0.2f, 0.2f);
                randomDirection.y = Random.Range( 0.5f, 1f);
                randomDirection.z = Random.Range(-1f, 1f);

                randomDirection.Normalize();

                rigidbody.AddForce(randomDirection * Random.Range(30f,40f), ForceMode.VelocityChange);
                rigidbody.AddTorque(randomDirection * Random.Range(100f,150f), ForceMode.VelocityChange);
            }

            yield return new WaitForSeconds(5f);

            Destroy(this.gameObject);
        }

        private void OnDisposeEvent()
        {
            block.PositionUpdatedEvent -= OnPositionUpdatedEvent;
            block.OnDisposeEvent -= OnDisposeEvent;

            StartCoroutine(DestructionEnumerator());
        }
    }
}
