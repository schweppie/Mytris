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
        
        private TetrinoController tetrinoController;
        private CameraController cameraController;
        private GridController gridController;

        private Vector3 targetPosition = new Vector3();

        private const float DESTRUCTION_DURATION = 3f;

        private Block.UpdateType updateType;

        public override void Setup(Block block)
        {
            this.block = block;
            
            transform.localPosition = new Vector3(block.X, block.Y, 0);

            block.PositionUpdatedEvent += OnPositionUpdatedEvent;
            block.OnDisposeEvent += OnDisposeEvent;
            block.OnBounceAction += Bounce;

            tetrinoController = Locator.Instance.Get<TetrinoController>();
            cameraController = Locator.Instance.Get<CameraController>();
        }

        public void SetColor(Color color)
        {
            for(int i=0; i< renderers.Length; i++)
                renderers[i].material.SetColor("_Color", color);
        }

        private void OnPositionUpdatedEvent(int x, int y, Block.UpdateType updateType)
        {
            targetPosition.x = x;
            targetPosition.y = y;

            this.updateType = updateType;
        }

        private void Update()
        {
            if (updateType == Block.UpdateType.Instant)
                transform.localPosition = targetPosition;
            else
                transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition, 0.3f);
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
