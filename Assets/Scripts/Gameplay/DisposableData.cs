using System;

namespace JP.Mytrix.Gameplay
{
    public abstract class DisposableData : IDisposable
    {
        public delegate void OnDisposeDelegate();
        public event OnDisposeDelegate OnDisposeEvent;

        public virtual void Dispose()
        {
            if(OnDisposeEvent!=null)
                OnDisposeEvent();
        }        
    }
}
