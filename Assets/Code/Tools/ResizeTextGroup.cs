using System;
using NaughtyAttributes;
using UnityEngine;
using TMPro;

namespace MineSweeper
{
    public class ResizeTextGroup : MonoBehaviour
    {
        private const int AUTO_SIZE_MAX = 32767;
        [SerializeField] private bool resizeOnAwake;

        private void Awake()
        {
            if (!resizeOnAwake) { return; }
            
            ResizeGroup();
        }

        [Button]
        private void ResizeGroup()
        {
            TextMeshProUGUI[] group = GetComponentsInChildren<TextMeshProUGUI>();
            
            float minSize = float.MaxValue;

            foreach (TextMeshProUGUI text in group)
            {
                text.enableAutoSizing = true;
                text.fontSizeMax = AUTO_SIZE_MAX;
                text.ForceMeshUpdate();
                minSize = Mathf.Min(minSize, text.fontSize);
            }

            foreach (TextMeshProUGUI text in group)
            {
                text.fontSizeMax = minSize;
            }
        }
    }
}