using ArthurKehrwald.UserSettings;
using UnityEngine;

namespace ArthurKehrwald.PhysicalDisplay
{
    public class ScreenOption : Option<int>
    {
        [SerializeField]
        private TargetDisplayManager targetDisplayManager;
        [SerializeField]
        private DropdownOptionUi dropdownPrefab;
    
        protected override OptionUi<int> UiPrefab => dropdownPrefab;

        protected override int TargetValue
        {
            get => targetDisplayManager.TargetDisplayIndex;
            set
            {
                GL.Clear(true, true, Color.black);
#if !UNITY_EDITOR
            if (value > 0 && value < Display.displays.Length)
                Display.displays[value].Activate();
#endif
                targetDisplayManager.TargetDisplayIndex = value;
            }
        }
    }
}
