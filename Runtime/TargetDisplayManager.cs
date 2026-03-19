using UnityEngine;

namespace ArthurKehrwald.PhysicalDisplay
{
    public abstract class TargetDisplayManager : MonoBehaviour
    {
        [SerializeField] private PhysicalDisplay target;
        
        public abstract int TargetDisplayIndex { get; set; }

        private void OnEnable()
        {
            TargetDisplayIndex = target.MappingIndex;
            target.MappingIndexChanged += TargetOnMappingIndexChanged;
        }
        
        private void OnDisable()
        {
            target.MappingIndexChanged -= TargetOnMappingIndexChanged;
        }

        private void TargetOnMappingIndexChanged(object sender, int index)
        {
            TargetDisplayIndex = index;
        }
    }
}