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
            
            Blocks = new List<Block>();

            patternInstance = new bool[DataHelper.TETRINO_DIMENSION * DataHelper.TETRINO_DIMENSION];
            
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
        
        public void Rotate(TetrinoRotation rotation)
        {
            for (int i = 0; i < Config.Pattern.Length; i++)
            {
                int x = i % DataHelper.TETRINO_DIMENSION;
                int y = i / DataHelper.TETRINO_DIMENSION;
                
                int rotatedIndex = GetIndex(x, y, rotation);
                patternInstance[rotatedIndex] = Config.Pattern[i];
            }

            int blockIndex = 0;
            for (int i = 0; i < patternInstance.Length; i++)
            {
                if (patternInstance[i])
                {
                    Blocks[blockIndex].SetPosition(i % DataHelper.TETRINO_DIMENSION,
                        i / DataHelper.TETRINO_DIMENSION);
                    blockIndex++;
                }
            }
        }
        
        private int GetIndex(int x, int y, TetrinoRotation rotation)
        {
            int d = DataHelper.TETRINO_DIMENSION;
            
            switch (rotation)
            {
                case TetrinoRotation.Up0: return y * d + x;
                case TetrinoRotation.Right90: return (d * (d-1)) + y - (x * d);
                case TetrinoRotation.Down180: return ((d*d)-1) - (y * d) - x;
                case TetrinoRotation.Left270: return (d-1) - y + (x * d);
            }

            return 0;
        }
    }
}
