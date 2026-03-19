using UnityEngine;

namespace ArthurKehrwald.PhysicalDisplay
{
    public class TargetDisplayCycler : MonoBehaviour
    {
        [SerializeField] private PhysicalDisplay physicalDisplay;

#if !UNITY_EDITOR
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Tab))
                physicalDisplay.MappingIndex = (physicalDisplay.MappingIndex + 1) % Display.displays.Length;
        }
#endif
    }
}