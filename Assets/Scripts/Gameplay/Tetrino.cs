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

        private TetrinoPattern pattern;

        public List<Block> Blocks { get; private set; }
        
        private int patternIndex = 0;

        public Tetrino(int px, int py, TetrinoConfig config)
        {
            this.x = px;
            this.y = py;
            Config = config;
            
            Blocks = new List<Block>();

            PopulatePattern();
            
            for(int by = 0; by < config.PatternHeight; by++)
            {
                for(int bx = 0; bx < config.PatternWidth; bx++)
                {
                    if(!pattern.GetValue(bx,by))
                        continue;

                    Block block = new Block(bx + px, by + py, Config.BlockConfig);
                    Blocks.Add(block);
                }
            }
        }

        private void UpdateTetrino()
        {
            PopulatePattern();

            int blockIndex = 0;
            for(int by = 0; by < Config.PatternHeight; by++)
            {
                for(int bx = 0; bx < Config.PatternWidth; bx++)
                {
                    if(!pattern.GetValue(bx,by))
                        continue;
                    
                    Blocks[blockIndex].SetPosition(bx + x, by + y);
                    blockIndex++;
                }
            }
        }

        private void PopulatePattern()
        {
            pattern = Config.Patterns[patternIndex % Config.Patterns.Count];
        }

        public void Rotate()
        {
            patternIndex = (patternIndex + 1) % Config.Patterns.Count;
            UpdateTetrino();
        }

        public void Move(int x, int y)
        {
            this.x += x;
            this.y += y;

            UpdateTetrino();
        }
    }
}
