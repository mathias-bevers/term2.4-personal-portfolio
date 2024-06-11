using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MineSweeper
{
    public class PlayingField : MonoBehaviour
    {
        [SerializeField] private Vector2Int gridDimensions;
        private int gridSize => gridDimensions.x * gridDimensions.y;

        public int mineCount { get; private set; }

        private Cell[,] grid;
        private Transform cachedTransform;


        private void Awake() { cachedTransform = transform; }

        private int PositionToOneDimension(int row, int column) =>
            gridDimensions.x * row + column;

        private Cell[] GetNeighbors(int x, int y)
        {
            List<Cell> neighbors = new();

            for (int i = -1; i <= 1; ++i)
            for (int ii = -1; ii <= 1; ++ii)
            {
                if (i == 0 && ii == 0) { continue; }

                Vector2Int current = new(x + i, y + ii);

                if (current.x < 0 || current.x >= gridDimensions.x) { continue; }

                if (current.y < 0 || current.y >= gridDimensions.y) { continue; }

                neighbors.Add(GetCellFromPosition(current.x, current.y));
            }

            return neighbors.ToArray();
        }


        public Cell GetCellFromPosition(int x, int y)
        {
            if (x >= grid.GetLength(0)) { throw new ArgumentOutOfRangeException(nameof(x), grid.GetLength(0), ""); }

            if (y >= grid.GetLength(1)) { throw new ArgumentOutOfRangeException(nameof(x), grid.GetLength(1), ""); }

            return grid[x, y];
        }

        public void CreateGrid(Vector2Int? gridDimensions = null)
        {
            if (gridDimensions.HasValue) { this.gridDimensions = gridDimensions.Value; }

            cachedTransform.RemoveAllChildren();

            grid = new Cell[this.gridDimensions.x, this.gridDimensions.y];
            mineCount = Mathf.Max(1, Mathf.RoundToInt(gridSize * 0.1f));
            int[] mineLocations = Utils.GetRandomInts(mineCount, gridSize);

            Vector2 cellSize = new(1f / this.gridDimensions.x, 1f / this.gridDimensions.y);
            Vector2 topRight = new(-(0.5f - cellSize.x * 0.5f), 0.5f - cellSize.y * 0.5f);

            for (int x = 0; x < this.gridDimensions.x; ++x)
            for (int y = 0; y < this.gridDimensions.y; ++y)
            {
                Vector2 worldPosition = topRight + new Vector2(cellSize.x * x, -(cellSize.y * y));
                bool isBomb = Array.IndexOf(mineLocations, PositionToOneDimension(x, y)) >= 0;

                Cell cell = Cell.Create(cachedTransform, worldPosition, cellSize, isBomb);

                grid[x, y] = cell;
            }

            for (int y = 0; y < this.gridDimensions.y; ++y)
            for (int x = 0; x < this.gridDimensions.x; ++x)
            {
                Cell cell = GetCellFromPosition(x, y);

                if (cell.isBomb) { continue; }

                Cell[] neighbors = GetNeighbors(x, y);
                cell.SetNearBombCount(neighbors.Count(neighbor => neighbor.isBomb));
            }
        }
    }
}