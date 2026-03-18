using UnityEngine;

namespace ArthurKehrwald.PhysicalDisplay
{
    public class TargetDisplayCycler : MonoBehaviour
    {
        [SerializeField]
        private TargetDisplayManager targetDisplayManager;

#if !UNITY_EDITOR
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
            targetDisplayManager.TargetDisplayIndex = (targetDisplayManager.TargetDisplayIndex + 1) % Display.displays.Length;
    }
#endif
    }
}