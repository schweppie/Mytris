using System;
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

        private Vector3 centerPosition;



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
            tetrino.OnStateUpdatedEvent += OnStateUpdated;

            for (int i = 0; i < tetrino.Blocks.Count; i++)
            {
                BlockVisualizer blockVisualizer = Instantiate(tetrino.Config.BlockConfig.VisualizerPrefab);

                blockVisualizer.transform.SetParent(this.transform);

                blockVisualizer.Setup(tetrino.Blocks[i]);
                blockVisualizer.SetColor(tetrino.Config.Color);

                blocks.Add(blockVisualizer);

                centerPosition += blockVisualizer.transform.localPosition;
            }

            centerPosition /= tetrino.Blocks.Count;
        }

        private void OnStateUpdated(Tetrino.State state)
        {
            if(state == Tetrino.State.OnStack)
            {
                transform.SetParent(tetrinoController.TestRoot);
            }

        }

        private void Update()
        {
            /*
            if (UnityEngine.Input.GetKeyDown(KeyCode.H))
                ToTestPosition();
            if (UnityEngine.Input.GetKeyDown(KeyCode.B))
                ToGamePosition();
            */

            ToGamePosition();
        }


        public void ToContainerPosition()
        {
           // transform.SetParent(tetrino.Container);
            transform.localPosition = Vector3.Lerp(transform.localPosition, -centerPosition, 0.3f);
        }

        public void ToGamePosition()
        {
            transform.SetParent(tetrinoController.VisualizersRoot);
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
