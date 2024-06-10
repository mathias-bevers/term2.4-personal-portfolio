using UnityEngine;

namespace MineSweeper
{
    public static class Utils
    {
        public static void RemoveAllChildren(this Transform parent)
        {
            for (int i = parent.childCount - 1; i >= 0; --i)
            {
                if (i >= parent.childCount)
                {
                    continue;
                }

                Object.Destroy(parent.GetChild(i).gameObject);
            }
        }
    }
}