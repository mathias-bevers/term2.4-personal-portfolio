using System;
using UnityEngine;

namespace MineSweeper
{
    public class GameManager : Singleton<GameManager>
    {
        [SerializeField] private PlayingField field;

        private void Start()
        {
            field.CreateGrid();
        }
    }
}