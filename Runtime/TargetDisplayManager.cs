using System;
using UnityEngine;

namespace ArthurKehrwald.PhysicalDisplay
{
    public abstract class TargetDisplayManager : MonoBehaviour
    {
        public event EventHandler<int> TargetDisplayChanged;
        private int _lastReportedTargetDisplay;
        public abstract int TargetDisplayIndex { get; set; }

        private void Awake()
        {
            _lastReportedTargetDisplay = TargetDisplayIndex;
        }

        private void Update()
        {
            if (TargetDisplayIndex != _lastReportedTargetDisplay)
            {
                _lastReportedTargetDisplay = TargetDisplayIndex;
                TargetDisplayChanged?.Invoke(this, TargetDisplayIndex);
            }
        }
    }
}