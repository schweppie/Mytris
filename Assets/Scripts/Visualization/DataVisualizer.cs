using UnityEngine;

namespace JP.Mytrix.Visualization
{
    public abstract class DataVisualizer<T> : MonoBehaviour
    {
        public abstract void Setup(T data);
    }
}
