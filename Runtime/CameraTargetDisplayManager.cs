using UnityEngine;

namespace ArthurKehrwald.PhysicalDisplay
{
    [RequireComponent(typeof(Camera))]
    public class CameraTargetDisplayManager : TargetDisplayManager
    {
        public override int TargetDisplayIndex
        {
            get => Camera.targetDisplay;
            set => Camera.targetDisplay = value;
        }
    
        private Camera _cam;
        private Camera Camera
        {
            get
            {
                if (_cam == null)
                    _cam = GetComponent<Camera>();
                return _cam;
            }
        }
    }
}
