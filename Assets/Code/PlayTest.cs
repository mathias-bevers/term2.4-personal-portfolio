using System;
using System.Collections;
using UnityEngine;

namespace MineSweeper
{
    public class PlayTest : MonoBehaviour
    {
        public const float DELAY = 0.5f;

        [field: SerializeField]
        public int value { get; private set; }

        private float timer;
        
        
        private void Update()
        {
            timer += Time.deltaTime;
            
            if (timer < DELAY) { return; }

            value = 10;
        }
    }
}