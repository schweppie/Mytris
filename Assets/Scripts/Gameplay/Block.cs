using JP.Mytris.Data;
using UnityEngine;

namespace JP.Mytrix.Gameplay
{
    public class Block
    {
        public int X {get; private set;}
        public int Y {get; private set;}
        public BlockConfig Config { get; private set; }

        public delegate void PositionUpdateDelegate(int x, int y);
        public event PositionUpdateDelegate PositionUpdatedEvent;
        
        public Block(int x, int y, BlockConfig config)
        {
            X = x;
            Y = y;
            Config = config;

            Debug.Log("creating block " + x + ", " + y);
        }

        public void SetPosition(int x, int y)
        {
            X = x;
            Y = y;
            
            Debug.Log("SetPosition");

            DispatchPositionUpdatedEvent();
        }

        private void DispatchPositionUpdatedEvent()
        {
            if (PositionUpdatedEvent != null)
                PositionUpdatedEvent(X, Y);
        }
    }
}
