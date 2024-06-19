using System;
using UnityEngine;

namespace MineSweeper.Tools
{
    public static class Utils
    {
        public static void RemoveAllChildren(this Transform parent)
        {
            for (int i = parent.childCount - 1; i >= 0; --i)
            {
                if (i >= parent.childCount) { continue; }

                UnityEngine.Object.Destroy(parent.GetChild(i).gameObject);
            }
        }

        public static int[] GetRandomInts(int size, int max, int min = 0, bool sorted = false)
        {
            int[] array = new int [size];
            for (int i = 0; i < array.Length; ++i)
            {
                int value;

                do { value = UnityEngine.Random.Range(min, max); } while (Array.IndexOf(array, value) >= 0);

                array[i] = value;
            }

            if(sorted) { Array.Sort(array); }
            
            return array;
        }
    }

    public class ComponentNotFoundException<T> : Exception where T : Component
    {
        public ComponentNotFoundException() : base($"Could not find the component: {typeof(T).Name}") { }
    }
}