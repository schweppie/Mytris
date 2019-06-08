using System.Collections.Generic;
using JP.Mytris.Data;

namespace JP.Mytrix.Gameplay
{
    public class Tetrino
    {
        public TetrinoConfig Config { get; private set; }

        private int x;
        private int y;

        private bool[] patternInstance;

        public List<Block> Blocks { get; private set; }
        
        public Tetrino(int x, int y, TetrinoConfig config)
        {
            this.x = x;
            this.y = y;
            Config = config;

            for (int i = 0; i < config.Pattern.Length; i++)
            {
                if (config.Pattern[i])
                {
                    Block block = new Block(i % DataHelper.TETRINO_DIMENSION,
                        i / DataHelper.TETRINO_DIMENSION, Config.BlockConfig);
                    
                    Blocks.Add(block);
                }
            }
            
            Rotate(TetrinoRotation.Up0);
        }

        private void Move(int x, int y)
        {
            this.x += x;
            this.y += y;
        }
        
        private void Rotate(TetrinoRotation rotation)
        {
            int i=0;
            for (int y = 0; y < DataHelper.TETRINO_DIMENSION; y++)
            {
                for (int x = 0; x < DataHelper.TETRINO_DIMENSION; x++)
                {
                    i++;
                    patternInstance[GetIndex(x,y,rotation)] = Config.Pattern[i];

                    Blocks[i].SetPosition(x + this.x, y + this.y);
                }
            }
        }
        
        private int GetIndex(int x, int y, TetrinoRotation rotation)
        {
            switch (rotation)
            {
                case TetrinoRotation.Up0: return y * 4 + x;
                case TetrinoRotation.Right90: return 12 + y - (x * 4);
                case TetrinoRotation.Down180: return 15 - (y * 4) - x;
                case TetrinoRotation.Left270: return 3 - y + (x * 4);
            }

            return 0;
        }
    }
}
