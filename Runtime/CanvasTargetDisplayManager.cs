using UnityEngine;

namespace ArthurKehrwald.PhysicalDisplay
{
    [RequireComponent(typeof(Canvas))]
    public class CanvasTargetDisplayManager : TargetDisplayManager
    {
        public override int TargetDisplayIndex
        {
            get => Canvas.targetDisplay;
            set => Canvas.targetDisplay = value;
        }
    
        private Canvas _canvas;
        private Canvas Canvas
        {
            get
            {
                if (_canvas == null)
                    _canvas = GetComponent<Canvas>();
                return _canvas;
            }
        }
    }
}