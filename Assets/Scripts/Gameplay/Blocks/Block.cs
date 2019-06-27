using System;
using JP.Mytris.Data;

namespace JP.Mytrix.Gameplay.Blocks
{
    public class Block : DisposableData
    {
        public int X {get; private set;}
        public int Y {get; private set;}
        public BlockConfig Config { get; private set; }

        public delegate void PositionUpdateDelegate(int x, int y, PositionUpdateType updateType);
        public event PositionUpdateDelegate PositionUpdatedEvent;

        public Action OnBounceAction;

        public Block(int x, int y, BlockConfig config)
        {
            X = x;
            Y = y;
            Config = config;
        }

        public void SetPosition(int x, int y, PositionUpdateType updateType)
        {
            X = x;
            Y = y;

            DispatchPositionUpdatedEvent(updateType);
        }

        public void Bounce()
        {
            if(OnBounceAction!=null)
                OnBounceAction();
        }

        private void DispatchPositionUpdatedEvent(PositionUpdateType updateType)
        {
            if (PositionUpdatedEvent != null)
                PositionUpdatedEvent(X, Y, updateType);
        }
    }
}
