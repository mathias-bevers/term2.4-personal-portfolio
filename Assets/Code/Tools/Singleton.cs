using System;
using UnityEngine;

namespace MineSweeper
{
    public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        public static bool isInitialized => !ReferenceEquals(null, _instance);

        public static T instanceIfInitialized => isInitialized ? _instance : null;
        
        private static T _instance;
        public static T instance
        {
            get
            {
                // First search for an instance in the current scene.
                if (!isInitialized) { _instance = FindObjectOfType<T>(); }

                // Create a new instance.
                if (!isInitialized)
                {
                    GameObject go = new(typeof(T).Name);
                    _instance = go.AddComponent<T>();
                }

                return _instance;
            }
        }

        protected virtual void OnDestroy()
        {
            if (_instance == this) { _instance = null; }
        }

        protected virtual void Awake()
        {
            if (!isInitialized)
            {
                _instance = this as T;
                return;
            }
            
            if(_instance == this) { return; }
            
            Destroy(this);
        }
    }
}