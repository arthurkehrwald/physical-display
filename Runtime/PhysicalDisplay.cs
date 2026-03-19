using System;
using UnityEngine;

namespace ArthurKehrwald.PhysicalDisplay
{
    public class PhysicalDisplay : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("Index of the physical display in the Unity display array represented by this object")]
        private int mappingIndex;

        public int MappingIndex
        {
            get => mappingIndex;
            set
            {
                if (mappingIndex == value) return;
                GL.Clear(true, true, Color.black);
                mappingIndex = value;
                ActivateDisplayIfNeeded();
                MappingIndexChanged?.Invoke(this, mappingIndex);
            }
        }

        public event EventHandler<int> MappingIndexChanged;

        public float Width
        {
            get => Vector3.Distance(BottomLeftCorner, BottomRightCorner);
            set
            {
                var currentXScale = transform.localScale.x;
                var desiredWidth = value;
                var scaleFactor = desiredWidth / Width;
                var newXScale = currentXScale * scaleFactor;
                transform.localScale = new Vector3(newXScale, transform.localScale.y, transform.localScale.z);
            }
        }

        public float Height
        {
            get => Vector3.Distance(BottomLeftCorner, TopLeftCorner);
            set
            {
                var currentYScale = transform.localScale.y;
                var desiredHeight = value;
                var scaleFactor = desiredHeight / Height;
                var newYScale = currentYScale * scaleFactor;
                transform.localScale = new Vector3(transform.localScale.x, newYScale, transform.localScale.z);
            }
        }

        public float Diagonal => Vector3.Distance(BottomLeftCorner, TopRightCorner);

        public Vector3 BottomLeftCorner => transform.TransformPoint(new Vector3(-0.5f, -0.5f, 0f));
        public Vector3 BottomRightCorner => transform.TransformPoint(new Vector3(0.5f, -0.5f, 0f));
        public Vector3 TopLeftCorner => transform.TransformPoint(new Vector3(-0.5f, 0.5f, 0f));
        public Vector3 TopRightCorner => transform.TransformPoint(new Vector3(0.5f, 0.5f, 0f));
        public Vector3 Center => transform.position;

        private void Awake()
        {
            ActivateDisplayIfNeeded();
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Gizmos.DrawLine(BottomLeftCorner, BottomRightCorner);
            Gizmos.DrawLine(BottomRightCorner, TopRightCorner);
            Gizmos.DrawLine(TopRightCorner, TopLeftCorner);
            Gizmos.DrawLine(TopLeftCorner, BottomLeftCorner);
        }
#endif

        public static PhysicalDisplay FindScreenWithTag(string tag)
        {
            GameObject go;
            try
            {
                go = GameObject.FindGameObjectWithTag(tag);
            }
            catch (UnityException)
            {
                Debug.LogWarning($"Add the tag '{tag}' in the tag manager.");
                return null;
            }

            if (go == null)
            {
                Debug.LogWarning($"Add the tag '{tag}' to an object in your scene.");
                return null;
            }

            if (!go.TryGetComponent(out PhysicalDisplay screen))
            {
                Debug.LogWarning(
                    $"Add the component {typeof(PhysicalDisplay)} to the object tagged '{tag}' in your scene.");
                return null;
            }

            return screen;
        }

        private void ActivateDisplayIfNeeded()
        {
#if !UNITY_EDITOR
            if (MappingIndex >= 0 && MappingIndex < Display.displays.Length)
                Display.displays[MappingIndex].Activate();
#endif
        }
    }
}