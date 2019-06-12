using JP.Mytris.Data;
using UnityEngine;

namespace JP.Mytrix.Gameplay
{
    public class TetrinoFactory : MonoBehaviour
    {
        public TetrinoConfig config;

        public Tetrino tetrino;

        private int angle = 0;
        
        public Tetrino SpawnTetrino()
        {
            Tetrino tetrino = new Tetrino(0,0, config);
            TetrinoVisualizer instance = Instantiate(config.TetrinoVisualizer);
            
            instance.Setup(tetrino);

            return tetrino;
        }

        private void Awake()
        {
            tetrino = SpawnTetrino();
        }


        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.W))
                tetrino.Rotate();
            if (Input.GetKeyUp(KeyCode.S))
                tetrino.Move(0,-1);

            if (Input.GetKeyUp(KeyCode.D))
                tetrino.Move(1,0);

            if (Input.GetKeyUp(KeyCode.A))
                tetrino.Move(-1,0);

        }
    }
}
