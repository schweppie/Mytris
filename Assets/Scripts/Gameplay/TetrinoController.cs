using System.Collections;
using JP.Mytris.Data;
using JP.Mytrix.Statemachine;
using JP.Mytrix.Statemachine.Game;
using UnityEngine;

namespace JP.Mytrix.Gameplay
{
    public class TetrinoController : MonoBehaviour
    {
        public TetrinoConfig[] config;

        public Tetrino activeTetrino;

        private int angle = 0;
        
        public static Grid Grid = new Grid(10,15);

        public Tetrino SpawnTetrino()
        {
            TetrinoConfig activeConfig = config[Random.Range(0, config.Length)];

            Tetrino tetrino = new Tetrino(5,11, activeConfig);
            TetrinoVisualizer instance = Instantiate(activeConfig.TetrinoVisualizer);
            
            instance.Setup(tetrino);

            return tetrino;
        }

/*
        private void Awake()
        {
            activeTetrino = SpawnTetrino();

            StartCoroutine(MoveBlockEnumerator());
        }

        private IEnumerator MoveBlockEnumerator()
        {
            while(true)
            {
                yield return new WaitForSeconds(1f);
                if(Grid.CanTetrinoFit(activeTetrino, activeTetrino.X, activeTetrino.Y-1, activeTetrino.PatternIndex))
                {
                    activeTetrino.Move(0,-1);
                }
                else
                    PlaceTetrino();
            }
        }

        private void Update()
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
        private void PlaceTetrino()
        {
            Grid.AddTetrino(activeTetrino);
            activeTetrino = SpawnTetrino();
        }*/
    }
}
