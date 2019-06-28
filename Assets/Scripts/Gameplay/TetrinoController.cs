using JP.Mytris.Data;
using JP.Mytrix.Flow;
using UnityEngine;

namespace JP.Mytrix.Gameplay
{
    public class TetrinoController : MonoBehaviour
    {

        public TetrinoConfig editorConfig;

        public TetrinoConfig[] config;

        public Tetrino activeTetrino;

        private int angle = 0;

        private GridController gridController;

        public float MoveDuration { get; private set;}

        public void Setup()
        {
            gridController = Locator.Instance.Get<GridController>();

            MoveDuration = 0.3f;
        }

        public void SpawnTetrino()
        {
            TetrinoConfig activeConfig;

            if (editorConfig == null)
                activeConfig = config[Random.Range(0, config.Length)];
            else
                activeConfig = editorConfig;

            Tetrino tetrino = new Tetrino(gridController.Grid.Width/2,gridController.Grid.Height- 5, activeConfig);
            TetrinoVisualizer instance = Instantiate(activeConfig.TetrinoVisualizer);

            instance.Setup(tetrino);
            instance.transform.SetParent(this.transform);

            activeTetrino = tetrino;
        }

        public void MoveTetrino(int xOffset, int yOffset)
        {
            activeTetrino.Move(xOffset,yOffset);
        }

        public void RotateTetrino()
        {
            activeTetrino.Rotate();
        }

        public void ShakeTetrino()
        {
            activeTetrino.Shake();
        }

        public bool CanMoveTetrino(int xOffset, int yOffset)
        {
            return gridController.Grid.CanTetrinoFit(activeTetrino, activeTetrino.X+xOffset, activeTetrino.Y+yOffset, activeTetrino.PatternIndex);
        }

        public bool CanRotateTetrino()
        {
            return gridController.Grid.CanTetrinoFit(activeTetrino, activeTetrino.X, activeTetrino.Y, activeTetrino.PatternIndex + 1);
        }

        public void AddTetrinoToBoard()
        {
            PlaceTetrino();
            activeTetrino.Dispose();
        }

        private void PlaceTetrino()
        {
            gridController.Grid.AddTetrino(activeTetrino);
        }

        private void Update()
        {
            if(activeTetrino!=null)
                activeTetrino.DebugDraw();

            if(UnityEngine.Input.GetKeyDown(KeyCode.F1))
                gridController.Grid.ClearRow(0);
            if(UnityEngine.Input.GetKeyDown(KeyCode.F2))
                gridController.Grid.ClearRow(1);
            if(UnityEngine.Input.GetKeyDown(KeyCode.F3))
                gridController.Grid.ClearRow(2);
            if(UnityEngine.Input.GetKeyDown(KeyCode.F4))
                gridController.Grid.ClearRow(3);
        }
    }
    
}
