using ArthurKehrwald.UserSettings;
using UnityEngine;

namespace ArthurKehrwald.PhysicalDisplay
{
    public class ScreenWidthOption : DistanceOption
    {
        [SerializeField]
        private PhysicalDisplay display;

        protected override float TargetValue
        {
            get => display.Width;
            set => display.Width = value;
        }
    }
}