using JP.Mytris.Data;

namespace JP.Mytrix.Gameplay
{
    public class Block : DisposableData
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
        }

        public void SetPosition(int x, int y)
        {
            X = x;
            Y = y;

            DispatchPositionUpdatedEvent();
        }

        private void DispatchPositionUpdatedEvent()
        {
            if (PositionUpdatedEvent != null)
                PositionUpdatedEvent(X, Y);
        }
    }
}
