using JP.Mytrix.Gameplay;
using UnityEngine;

namespace JP.Mytris.Data
{
    [CreateAssetMenu(menuName = "Data/BlockConfig", fileName = "BlockConfig")]
    public class BlockConfig : ScriptableObject
    {
        public BlockVisualizer VisualizerPrefab;
    }
}
