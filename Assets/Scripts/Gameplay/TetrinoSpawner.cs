using JP.Mytris.Data;
using System.Collections.Generic;
using UnityEngine;

namespace JP.Mytrix.Gameplay
{
    public class TetrinoSpawner : MonoBehaviour
    {
        [SerializeField]
        private TetrinoConfig[] configs;

        private List<TetrinoContainer> tetrinoContainters = new List<TetrinoContainer>();

        private const int STACK_SIZE = 3;

        public delegate void TetrinoSpawnedDelegate(TetrinoConfig config);
        public event TetrinoSpawnedDelegate OnTetrinoSpawnedEvent;

        public void Setup()
        {
            tetrinoContainters.Clear();

            for (int i = 0; i < STACK_SIZE; i++)
            {
                TetrinoContainer tetrinoContainer = new TetrinoContainer(i, configs[Random.Range(0, configs.Length)]);
                tetrinoContainters.Add(tetrinoContainer);
            }
        }

        public void SpawnTetrino()
        {
            if (tetrinoContainters.Count == 0)
                return;

            TetrinoContainer tetrinoContainer = tetrinoContainters[0];
            tetrinoContainer.Dispose();

            tetrinoContainters.RemoveAt(0);

            for (int i = 0; i < tetrinoContainters.Count; i++)
                tetrinoContainters[i].MoveUp();

            TetrinoContainer newTetrinoContainer = new TetrinoContainer(tetrinoContainters.Count - 1, configs[Random.Range(0, configs.Length)]);
            tetrinoContainters.Add(newTetrinoContainer);

            DispatchOnTetrinoSpawnedEvent(tetrinoContainer.Config);
        }

        private void DispatchOnTetrinoSpawnedEvent(TetrinoConfig config)
        {
            if (OnTetrinoSpawnedEvent != null)
                OnTetrinoSpawnedEvent(config);
        }
    }
}
