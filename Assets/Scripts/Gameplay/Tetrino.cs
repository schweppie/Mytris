using System.Collections.Generic;
using JP.Mytris.Data;
using UnityEngine;

namespace JP.Mytrix.Gameplay
{
    public class Tetrino : DisposableData
    {
        public TetrinoConfig Config { get; private set; }

        public int X {get; private set; } 
        public int Y {get; private set;}

        private TetrinoPattern pattern;
        public TetrinoPattern Pattern { get{ return pattern; }}

        public List<Block> Blocks { get; private set; }
        
        public int PatternIndex {get ; private set;}

        public Tetrino(int x, int y, TetrinoConfig config)
        {
            X = x;
            Y = y;
            Config = config;
            
            Blocks = new List<Block>();

            PopulatePattern();
            
            for(int by = 0; by < config.PatternHeight; by++)
            {
                for(int bx = 0; bx < config.PatternWidth; bx++)
                {
                    if(!pattern.GetValue(bx,by))
                        continue;

                    Block block = new Block(bx + x, by + y, Config.BlockConfig);
                    Blocks.Add(block);
                }
            }
        }


        public void DebugDraw()
        {

            for(int y = 0; y < pattern.Height; y++)
            {
                for(int x = 0; x < pattern.Width; x++)
                {
                    if(!pattern.GetValue(x,y))
                        continue;

                    Vector3 p1 = new Vector3(x + X, y + Y, 0);
                    Vector3 p2 = new Vector3(x+1+ X, y+ Y);
                    Vector3 p3 = new Vector3(x+ X, y+1+ Y);
                    Vector3 p4 = new Vector3(x+1+ X, y+1+ Y);;                    

                    Debug.DrawLine(p1, p2, Color.red);
                    Debug.DrawLine(p1, p3, Color.red);
                    Debug.DrawLine(p2, p4, Color.red);
                    Debug.DrawLine(p3, p4, Color.red);
                }
            }

            Vector3 pt1 = new Vector3(X, Y, 0);
            Vector3 pt2 = new Vector3(X + pattern.Width, Y, 0);
            Vector3 pt3 = new Vector3(X, Y + pattern.Height, 0);
            Vector3 pt4 = new Vector3(X + pattern.Width, Y + pattern.Height, 0);;                    

            Debug.DrawLine(pt1, pt2, Color.green);
            Debug.DrawLine(pt1, pt3, Color.green);
            Debug.DrawLine(pt2, pt4, Color.green);
            Debug.DrawLine(pt3, pt4, Color.green);
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
                    
                    Blocks[blockIndex].SetPosition(bx + X, by + Y);
                    blockIndex++;
                }
            }
        }

        private void PopulatePattern()
        {
            pattern = Config.Patterns[PatternIndex % Config.Patterns.Count];
        }

        public void Rotate()
        {
            PatternIndex = (PatternIndex + 1) % Config.Patterns.Count;
            UpdateTetrino();
        }

        public void Move(int x, int y)
        {
            this.X += x;
            this.Y += y;

            UpdateTetrino();
        }
    }
}
