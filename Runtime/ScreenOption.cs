using ArthurKehrwald.UserSettings;
using UnityEngine;

namespace ArthurKehrwald.PhysicalDisplay
{
    public class ScreenOption : Option<int>
    {
        [SerializeField] private PhysicalDisplay physicalDisplay;
        [SerializeField] private DropdownOptionUi dropdownPrefab;

        protected override OptionUi<int> UiPrefab => dropdownPrefab;

        protected override int TargetValue
        {
            get => physicalDisplay.MappingIndex;
            set => physicalDisplay.MappingIndex = value;
        }

        protected override void Awake()
        {
            base.Awake();
            InitDropdown();
        }

        private void InitDropdown()
        {
            var dropdown = Ui as DropdownOptionUi;
            if (!dropdown) return;
#if UNITY_EDITOR
            var numDisplays = 3;
#else
            var numDisplays = Display.displays.Length;
#endif
            var options = new string[numDisplays];
            for (var i = 0; i < numDisplays; i++)
            {
                options[i] = $"Display {i + 1}";
            }

            dropdown.InitOptions(options);
        }
    }
}