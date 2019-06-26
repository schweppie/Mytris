using JP.Mytris.Data;
using UnityEngine;

namespace JP.Mytrix.Gameplay
{
    public class TetrinoController : MonoBehaviour
    {
        public TetrinoConfig[] config;

        public Tetrino activeTetrino;

        private int angle = 0;
        
        public static Grid Grid = new Grid(10,15);

        public void SpawnTetrino()
        {
            TetrinoConfig activeConfig = config[Random.Range(0, config.Length)];

            Tetrino tetrino = new Tetrino(3,8, activeConfig);
            TetrinoVisualizer instance = Instantiate(activeConfig.TetrinoVisualizer);

            instance.Setup(tetrino);

            activeTetrino = tetrino;
        }

        public void MoveTetrinoDown()
        {
            activeTetrino.Move(0,-1);
        }

        public bool CanMoveTetrinoDown()
        {
            return Grid.CanTetrinoFit(activeTetrino, activeTetrino.X, activeTetrino.Y-1, activeTetrino.PatternIndex);
        }

        public void AddTetrinoToBoard()
        {
            PlaceTetrino();
        }

        private void PlaceTetrino()
        {
            Grid.AddTetrino(activeTetrino);
        }

        private void Update()
        {
            Grid.DebugDraw();
        }

/*
        public void UpdateTetrinoController()
        {
            Grid.DebugDraw();

            activeTetrino.DebugDraw();

            if (Input.GetKeyDown(KeyCode.E) && Grid.CanTetrinoFit(activeTetrino, activeTetrino.X, activeTetrino.Y, activeTetrino.PatternIndex + 1))
                activeTetrino.Rotate();

            if (Input.GetKeyDown(KeyCode.W) && Grid.CanTetrinoFit(activeTetrino, activeTetrino.X, activeTetrino.Y + 1, activeTetrino.PatternIndex))
                activeTetrino.Move(0,1);
            if (Input.GetKeyDown(KeyCode.S) && Grid.CanTetrinoFit(activeTetrino, activeTetrino.X, activeTetrino.Y - 1, activeTetrino.PatternIndex))
                activeTetrino.Move(0,-1);
            if (Input.GetKeyDown(KeyCode.D) && Grid.CanTetrinoFit(activeTetrino, activeTetrino.X + 1, activeTetrino.Y, activeTetrino.PatternIndex))
                activeTetrino.Move(1,0);
            if (Input.GetKeyDown(KeyCode.A) && Grid.CanTetrinoFit(activeTetrino, activeTetrino.X - 1, activeTetrino.Y, activeTetrino.PatternIndex))
                activeTetrino.Move(-1,0);

            if (Input.GetKeyDown(KeyCode.Space))
                PlaceTetrino();
        }

        */
    }
    
}
