using System;
using System.Collections.Generic;
using JP.Mytris.Data;

namespace JP.Mytrix.Gameplay
{
    public class Tetrino
    {
        public TetrinoConfig Config { get; private set; }

        private int x;
        private int y;

        private bool[,] patternInstance;

        public List<Block> Blocks { get; private set; }
        
        public Tetrino(int px, int py, TetrinoConfig config)
        {
            this.x = px;
            this.y = py;
            Config = config;
            
            Blocks = new List<Block>();

            patternInstance = new bool[config.PatternWidth, config.PatternHeight];
            
            for(int by = 0; by < config.PatternHeight; by++)
            {
                for(int bx = 0; bx < config.PatternWidth; bx++)
                {
                    Block block = new Block(bx + px, by + py, Config.BlockConfig);
                    Blocks.Add(block);
                }
            }
        }

        public void Rotate()
        {

        }

        public void Move(int x, int y)
        {
            this.x += x;
            this.y += y;

            for(int i=0; i< Blocks.Count; i++)
            {
                Block block = Blocks[i];
                block.SetPosition(block.X + x, block.Y + y);
            }
        }
    }
}
