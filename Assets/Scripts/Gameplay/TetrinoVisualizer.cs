using System.Collections.Generic;
using JP.Mytrix.Flow;
using JP.Mytrix.Gameplay.Blocks;
using JP.Mytrix.Visualization;
using UnityEngine;

namespace JP.Mytrix.Gameplay
{
    public class TetrinoVisualizer : DataVisualizer<Tetrino>
    {
        private Tetrino tetrino;

        private List<BlockVisualizer> blocks = new List<BlockVisualizer>();

        private Vector3 position;

        private TetrinoController tetrinoController;

        public override void Setup(Tetrino tetrino)
        {
            this.tetrino = tetrino;

            tetrinoController = Locator.Instance.Get<TetrinoController>();

            transform.name = "ActiveTetrino | " + tetrino.Config.name + " | " + tetrino.Config.Color.ToString();

            position = new Vector3(tetrino.X, tetrino.Y, 0);

            transform.localPosition = position;

            tetrino.OnDisposeEvent += OnDisposeEvent;
            tetrino.OnTetrinoShakeAction += Shake;
            tetrino.OnPositionUpdatedEvent += OnPositionUpdated;

            for (int i = 0; i < tetrino.Blocks.Count; i++)
            {
                BlockVisualizer blockVisualizer = Instantiate(tetrino.Config.BlockConfig.VisualizerPrefab);

                blockVisualizer.transform.SetParent(this.transform);

                blockVisualizer.Setup(tetrino.Blocks[i]);
                blockVisualizer.SetColor(tetrino.Config.Color);

                blocks.Add(blockVisualizer);
            }
        }

        private void Update()
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, position, 0.3f);
        }

        private void OnPositionUpdated(int x, int y)
        {
            position.x = x;
            position.y = y;
        }

        public void Shake()
        {
            for(int i=0; i<blocks.Count; i++)
                blocks[i].Shake();
        }

        private void OnDisposeEvent()
        {
            for (int i = 0; i < blocks.Count; i++)
                blocks[i].transform.SetParent(tetrinoController.VisualizersRoot);

            tetrino.OnTetrinoShakeAction -= Shake;
            tetrino.OnDisposeEvent -= OnDisposeEvent;
            tetrino.OnPositionUpdatedEvent -= OnPositionUpdated;

            Destroy(this.gameObject);
        }
    }
}
