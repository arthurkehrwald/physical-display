using ArthurKehrwald.UserSettings;
using UnityEngine;

namespace ArthurKehrwald.PhysicalDisplay
{
    public class ScreenHeightOption : DistanceOption
    {
        [SerializeField]
        private PhysicalDisplay display;

        protected override float TargetValue
        {
            get => display.Height;
            set => display.Height = value;
        }
    }
}