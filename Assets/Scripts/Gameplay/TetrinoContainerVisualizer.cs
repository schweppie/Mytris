using JP.Mytrix.Flow;
using JP.Mytrix.Visualization;
using System.Collections;
using UnityEngine;

namespace JP.Mytrix.Gameplay
{
    public class TetrinoContainerVisualizer : DataVisualizer<TetrinoContainer>
    {
        private TetrinoContainer container;
        private TetrinoSpawner tetrinoSpawner;

        private Vector3 targetPosition;

        private const float MOVE_DURATION = 2f;
        private float moveTime = 0f;

        [SerializeField]
        private AnimationCurve movementCurve;

        public override void Setup(TetrinoContainer container)
        {
            this.container = container;
            tetrinoSpawner = Locator.Instance.Get<TetrinoSpawner>();

            transform.position = tetrinoSpawner.ContainerStartTransform.position;
            targetPosition = transform.position;

            container.OnPositionUpdateEvent += OnPositionUpdateEvent;
            container.OnDisposeEvent += OnDisposeEvent;

            OnPositionUpdateEvent(container.Position);
        }

        private void OnDestroy()
        {
            StopAllCoroutines();

            container.OnPositionUpdateEvent -= OnPositionUpdateEvent;
            container.OnDisposeEvent -= OnDisposeEvent;
        }

        private void OnDisposeEvent()
        {
            StopAllCoroutines();
            StartCoroutine(MoveToEndEnumerator());
        }

        private void OnPositionUpdateEvent(int position)
        {
            targetPosition = tetrinoSpawner.ContainerPositions[position].position;

            StopAllCoroutines();
            StartCoroutine(MoveEnumarator());
        }

        private IEnumerator MoveEnumarator()
        {
            moveTime = 0f;
            Vector3 fromPosition = transform.position;
            
            while(moveTime <= MOVE_DURATION)
            {
                transform.position = Vector3.LerpUnclamped(fromPosition, targetPosition, movementCurve.Evaluate(Mathf.Min(MOVE_DURATION, moveTime) / MOVE_DURATION));

                moveTime += Time.deltaTime;
                yield return null;
            }
        }

        private IEnumerator MoveToEndEnumerator()
        {
            targetPosition = tetrinoSpawner.ContainerEndTransform.position;
            yield return MoveEnumarator();

            Destroy(this.gameObject);
        }
    }
}
