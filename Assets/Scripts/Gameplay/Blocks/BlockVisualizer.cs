using System;
using System.Collections;
using DG.Tweening;
using JP.Mytrix.Flow;
using JP.Mytrix.Visualization;
using UnityEngine;

namespace JP.Mytrix.Gameplay.Blocks
{
    public class BlockVisualizer : DataVisualizer<Block>
    {
        [SerializeField]
        private Transform visualizerRoot;

        [SerializeField]
        private Transform blockRoot;
        
        [SerializeField]
        private Renderer[] renderers;

        [SerializeField]
        private Rigidbody[] rigidbodies;

        private Block block;
        
        private Vector3 targetPosition;

        private const float X_OFFSET = -5f;
        
        private TetrinoController tetrinoController;
        private CameraController cameraController;

        private const float DESTRUCTION_DURATION = 3f;

        public override void Setup(Block block)
        {
            this.block = block;
            
            transform.position = new Vector3(block.X + X_OFFSET, block.Y, 0);

            block.PositionUpdatedEvent += OnPositionUpdatedEvent;
            block.OnDisposeEvent += OnDisposeEvent;
            block.OnBounceAction += Bounce;

            targetPosition = transform.position;

            transform.position = targetPosition;

            tetrinoController = Locator.Instance.Get<TetrinoController>();
            cameraController = Locator.Instance.Get<CameraController>();
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

        public void Shake()
        {
            ResetShake();
            visualizerRoot.DOShakePosition(0.2f, 0.1f, 30).onComplete += ResetShake;
            cameraController.AddTrauma(0.05f);
        }

        private void ResetShake()
        {
            visualizerRoot.DOKill();
            visualizerRoot.localPosition = Vector3.zero;
        }

        public void Bounce()
        {
            ResetBounce();
            blockRoot.localScale = Vector3.one * 1.3f;
            blockRoot.DOScale(Vector3.one, 0.4f).SetEase(Ease.OutElastic);
        }

        public void ResetBounce()
        {
            blockRoot.DOKill();
            blockRoot.localScale = Vector3.one;
        }

        private IEnumerator DestructionEnumerator()
        {
            Vector3 randomDirection = new Vector3();

            for(int i=0 ; i<rigidbodies.Length ; i++)
            {
                Rigidbody rigidbody = rigidbodies[i];

                rigidbody.isKinematic = false;

                randomDirection.x = UnityEngine.Random.Range(-0.2f, 0.2f);
                randomDirection.y = UnityEngine.Random.Range( 0.5f, 1f);
                randomDirection.z = UnityEngine.Random.Range(-1f, 1f);

                randomDirection.Normalize();

                rigidbody.AddForce(randomDirection * UnityEngine.Random.Range(30f,40f), ForceMode.VelocityChange);
                rigidbody.AddTorque(randomDirection * UnityEngine.Random.Range(100f,150f), ForceMode.VelocityChange);

                float randomScaleDuration = UnityEngine.Random.Range(0.3f, 1.5f);
                rigidbody.transform.DOScale(Vector3.zero, randomScaleDuration).SetDelay(DESTRUCTION_DURATION - randomScaleDuration);
            }

            yield return new WaitForSeconds(DESTRUCTION_DURATION);

            Destroy(this.gameObject);
        }

        private void OnDisposeEvent()
        {
            block.PositionUpdatedEvent -= OnPositionUpdatedEvent;
            block.OnDisposeEvent -= OnDisposeEvent;
            block.OnBounceAction -= Bounce;

            StartCoroutine(DestructionEnumerator());
        }
    }
}
