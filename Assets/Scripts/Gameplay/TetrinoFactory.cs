using JP.Mytris.Data;
using UnityEngine;

namespace JP.Mytrix.Gameplay
{
    public class TetrinoFactory : MonoBehaviour
    {
        public TetrinoConfig config;

        public Tetrino activeTetrino;

        private int angle = 0;
        
        public static Grid Grid = new Grid(10,10);

        public Tetrino SpawnTetrino()
        {
            Tetrino tetrino = new Tetrino(5,5, config);
            TetrinoVisualizer instance = Instantiate(config.TetrinoVisualizer);
            
            instance.Setup(tetrino);

            return tetrino;
        }

        private void Awake()
        {
            activeTetrino = SpawnTetrino();
        }

        private void Update()
        {
            Grid.DebugDraw();

            activeTetrino.DebugDraw();

            if (Input.GetKeyDown(KeyCode.E))
                activeTetrino.Rotate();

            if (Input.GetKeyDown(KeyCode.W))
                activeTetrino.Move(0,1);
            if (Input.GetKeyDown(KeyCode.S))
                activeTetrino.Move(0,-1);
            if (Input.GetKeyDown(KeyCode.D))
                activeTetrino.Move(1,0);
            if (Input.GetKeyDown(KeyCode.A))
                activeTetrino.Move(-1,0);
        }
    }
}
