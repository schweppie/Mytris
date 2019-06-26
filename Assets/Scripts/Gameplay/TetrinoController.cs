using JP.Mytris.Data;
using UnityEngine;

namespace JP.Mytrix.Gameplay
{
    public class TetrinoController : MonoBehaviour
    {
        public TetrinoConfig[] config;

        public Tetrino activeTetrino;

        private int angle = 0;
        
        public static Grid Grid = new Grid(10,14);

        public void SpawnTetrino()
        {
            TetrinoConfig activeConfig = config[Random.Range(0, config.Length)];

            Tetrino tetrino = new Tetrino(3,10, activeConfig);
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

        public bool CanMoveTetrino(int xOffset, int yOffset)
        {
            return Grid.CanTetrinoFit(activeTetrino, activeTetrino.X+xOffset, activeTetrino.Y+yOffset, activeTetrino.PatternIndex);
        }

        public bool CanRotateTetrino()
        {
            return Grid.CanTetrinoFit(activeTetrino, activeTetrino.X, activeTetrino.Y, activeTetrino.PatternIndex + 1);
        }

        public void AddTetrinoToBoard()
        {
            PlaceTetrino();
            activeTetrino.Dispose();
        }

        private void PlaceTetrino()
        {
            Grid.AddTetrino(activeTetrino);
        }

        private void Update()
        {
            Grid.DebugDraw();

            if(activeTetrino!=null)
                activeTetrino.DebugDraw();

            if(UnityEngine.Input.GetKeyDown(KeyCode.F1))
                Grid.ClearRow(0);
            if(UnityEngine.Input.GetKeyDown(KeyCode.F2))
                Grid.ClearRow(1);
            if(UnityEngine.Input.GetKeyDown(KeyCode.F3))
                Grid.ClearRow(2);
            if(UnityEngine.Input.GetKeyDown(KeyCode.F4))
                Grid.ClearRow(3);
        }
    }
    
}
