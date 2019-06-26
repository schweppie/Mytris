using System.Collections.Generic;
using UnityEngine;

namespace JP.Mytrix.Gameplay
{
    public class TetrinoVisualizer : MonoBehaviour
    {
        private Tetrino tetrino;

        private List<BlockVisualizer> blocks;
        
        public void Setup(Tetrino tetrino)
        {
            this.tetrino = tetrino;

            transform.name = "ActiveTetrino | " + tetrino.Config.name + " | " + tetrino.Config.Color.ToString();

            tetrino.OnDisposeEvent += OnDisposeEvent;

            for (int i = 0; i < tetrino.Blocks.Count; i++)
            {
                BlockVisualizer blockVisualizer = Instantiate(tetrino.Config.BlockConfig.VisualizerPrefab);
                blockVisualizer.Setup(tetrino.Blocks[i], tetrino.Config.Color);
            }
        }

        private void OnDisposeEvent()
        {
            tetrino.OnDisposeEvent -= OnDisposeEvent;
            Destroy(this.gameObject);
        }
    }
}
