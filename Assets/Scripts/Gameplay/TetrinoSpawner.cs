using JP.Mytris.Data;
using JP.Mytrix.Flow;
using System.Collections.Generic;
using UnityEngine;

namespace JP.Mytrix.Gameplay
{
    public class TetrinoSpawner : MonoBehaviour
    {
        [SerializeField]
        private TetrinoContainerVisualizer tetrinoContainerVisualizerPrefab;

        [SerializeField]
        private TetrinoConfig editorConfig;

        [SerializeField]
        private TetrinoConfig[] configs;

        public Transform ContainerStartTransform;
        public Transform ContainerEndTransform;

        public Transform[] ContainerPositions;

        private List<TetrinoContainer> tetrinoContainers = new List<TetrinoContainer>();

        public delegate void TetrinoSpawnedDelegate(Tetrino config);
        public event TetrinoSpawnedDelegate OnTetrinoSpawnedEvent;

        private GridController gridController;

        public void Setup()
        {
            gridController = Locator.Instance.Get<GridController>();

            tetrinoContainers.Clear();

            for (int i = 0; i < ContainerPositions.Length; i++)
                SpawnTetrinoContainer(i);
        }

        private void Update()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.O))
                SpawnTetrino();
        }

        public void SpawnTetrino()
        {
            if (tetrinoContainers.Count == 0)
                return;

            TetrinoContainer tetrinoContainer = tetrinoContainers[0];
            tetrinoContainers.RemoveAt(0);

            for (int i = 0; i < tetrinoContainers.Count; i++)
                tetrinoContainers[i].MoveUp();

            DispatchOnTetrinoSpawnedEvent(tetrinoContainer.Tetrino);

            tetrinoContainer.Dispose();

            SpawnTetrinoContainer(ContainerPositions.Length-1);
        }

        public void SpawnTetrinoContainer(int index)
        {
            Tetrino tetrino = new Tetrino(gridController.Grid.Width / 2, gridController.Grid.Height - 5, configs[Random.Range(0, configs.Length)]);
            TetrinoContainerVisualizer visualizer = Instantiate(tetrinoContainerVisualizerPrefab);

            TetrinoContainer tetrinoContainer = new TetrinoContainer(index, tetrino);
            tetrinoContainers.Add(tetrinoContainer);

            visualizer.Setup(tetrinoContainer);

            tetrino.MoveToContainer(tetrinoContainer);
        }

        private void DispatchOnTetrinoSpawnedEvent(Tetrino tetrino)
        {
            if (OnTetrinoSpawnedEvent != null)
                OnTetrinoSpawnedEvent(tetrino);
        }
    }
}
