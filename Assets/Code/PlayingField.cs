using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace MineSweeper
{
    public class PlayingField : MonoBehaviour
    {
        [SerializeField] private Vector2Int gridDimensions;

        private int gridSize => gridDimensions.x * gridDimensions.y;

        private Cell[,] grid;
        private Transform cachedTransform;

        private void Awake()
        {
            cachedTransform = transform;
            CreateGrid();
        }

        private void CreateGrid()
        {
            cachedTransform.RemoveAllChildren();

            grid = new Cell[gridDimensions.x, gridDimensions.y];
            int mineAmount = Mathf.RoundToInt(gridSize * 0.1f);
            int[] mineLocations = GetLocationsArray(mineAmount, gridSize);

            Vector2 cellSize = new(1f / gridDimensions.x, 1f / gridDimensions.y);
            Vector2 topRight = new(-(0.5f - cellSize.x * 0.5f), 0.5f - cellSize.y * 0.5f);

            for (int x = 0; x < gridDimensions.x; ++x)
            for (int y = 0; y < gridDimensions.y; ++y)
            {

                Vector2 worldPosition = topRight + new Vector2(cellSize.x * x, -(cellSize.y * y));
                bool isBomb = Array.IndexOf(mineLocations, PositionToOneDimension(x, y)) >= 0;

                Cell cell = Cell.Create(cachedTransform, worldPosition, cellSize, isBomb);

                grid[x, y] = cell;
            }
        }

        private int[] GetLocationsArray(int mineAmount, int max)
        {
            int[] array = new int [mineAmount];
            for (int i = 0; i < array.Length; ++i)
            {
                int r;
                
                do { r = Random.Range(0, max); } while (Array.IndexOf(array, r) >= 0);

                array[i] = r;
            }

            return array;
        }

        private int PositionToOneDimension(int row, int column) =>
            gridDimensions.x * row + column;


        public Cell GetCellFromPosition(int x, int y)
        {
            if (x >= grid.GetLength(0)) { throw new ArgumentOutOfRangeException(nameof(x), grid.GetLength(0), ""); }

            if (y >= grid.GetLength(1)) { throw new ArgumentOutOfRangeException(nameof(x), grid.GetLength(1), ""); }

            return grid[x, y];
        }


        public void CreateGrid(int width, int height)
        {
            gridDimensions = new Vector2Int(width, height);
            CreateGrid();
        }
    }
}