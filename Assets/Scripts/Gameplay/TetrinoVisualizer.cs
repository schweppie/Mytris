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

            for (int i = 0; i < tetrino.Blocks.Count; i++)
            {
                BlockVisualizer blockVisualizer = Instantiate(tetrino.Config.BlockConfig.VisualizerPrefab);
                blockVisualizer.Setup(tetrino.Blocks[i]);
            }
            
        }
    }
}
