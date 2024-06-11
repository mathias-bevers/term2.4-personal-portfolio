using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

namespace MineSweeper
{
    public class PlayingField : MonoBehaviour
    {
        [SerializeField] private Vector2Int gridDimensions;
        private int gridSize => gridDimensions.x * gridDimensions.y;

        public int mineCount { get; private set; }
        public Transform cachedTransform { get; private set; }

        private Cell[,] grid;


        private void Awake()
        {
            cachedTransform = transform;
        }

        private int PositionToOneDimension(int row, int column) =>
            gridDimensions.x * row + column;


        public Cell[] GetNeighbors(int x, int y, bool excludeDiagonal = false)
        {
            List<Cell> neighbors = new();

            if (!excludeDiagonal)
            {
                for (int i = -1; i <= 1; ++i)
                for (int ii = -1; ii <= 1; ++ii)
                {
                    if (i == 0 && ii == 0) { continue; }

                    Cell neighbor = GetCellFromPosition(x + i, y + ii);

                    neighbors.Add(neighbor);
                }
            }
            else
            {
                neighbors.Add(GetCellFromPosition(x, y - 1));
                neighbors.Add(GetCellFromPosition(x - 1, y));
                neighbors.Add(GetCellFromPosition(x + 1, y));
                neighbors.Add(GetCellFromPosition(x, y + 1));
            }

            neighbors.RemoveAll(neighbor => ReferenceEquals(null, neighbor));
            return neighbors.ToArray();
        }

        [CanBeNull]
        public Cell GetCellFromPosition(int x, int y)
        {
            if (x < 0 || x >= grid.GetLength(0)) { return null; }

            if (y < 0 || y >= grid.GetLength(1)) { return null; }

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

                Cell cell = Cell.Create(this, new Vector2Int(x, y), worldPosition, cellSize, isBomb);

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