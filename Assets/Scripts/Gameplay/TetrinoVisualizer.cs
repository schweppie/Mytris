using System.Collections.Generic;
using JP.Mytrix.Gameplay.Blocks;
using JP.Mytrix.Visualization;

namespace JP.Mytrix.Gameplay
{
    public class TetrinoVisualizer : DataVisualizer<Tetrino>
    {
        private Tetrino tetrino;

        private List<BlockVisualizer> blocks = new List<BlockVisualizer>();
        
        public override void Setup(Tetrino tetrino)
        {
            this.tetrino = tetrino;

            transform.name = "ActiveTetrino | " + tetrino.Config.name + " | " + tetrino.Config.Color.ToString();

            tetrino.OnDisposeEvent += OnDisposeEvent;
            tetrino.OnTetrinoShakeAction += Shake;

            for (int i = 0; i < tetrino.Blocks.Count; i++)
            {
                BlockVisualizer blockVisualizer = Instantiate(tetrino.Config.BlockConfig.VisualizerPrefab);
                blockVisualizer.Setup(tetrino.Blocks[i]);
                blockVisualizer.SetColor(tetrino.Config.Color);

                blocks.Add(blockVisualizer);
            }
        }

        public void Shake()
        {
            for(int i=0; i<blocks.Count; i++)
                blocks[i].Shake();
        }

        private void OnDisposeEvent()
        {
            tetrino.OnTetrinoShakeAction -= Shake;
            tetrino.OnDisposeEvent -= OnDisposeEvent;
            Destroy(this.gameObject);
        }
    }
}
