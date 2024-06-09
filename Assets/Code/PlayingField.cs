using System;
using UnityEngine;

namespace MineSweeper
{
    public class PlayingField : MonoBehaviour
    {
        [SerializeField] private Vector2Int gridSize;
        
        private Cell[,] grid;
        private Transform cachedTransform;
        
        private void Awake()
        {
            cachedTransform = transform;
            CreateGrid();
        }

        private void CreateGrid()
        {
            grid = new Cell[gridSize.x, gridSize.y];
            
            Vector2 cellSize = new (1f/gridSize.x, 1f/gridSize.y);
            Vector2 topRight = new (-(0.5f - (cellSize.x * 0.5f)), 0.5f - (cellSize.y * 0.5f));
            
            for (int y = 0; y < gridSize.y; ++y)
            for (int x = 0; x < gridSize.x; ++x)
            {
                Vector2 position = topRight + new Vector2(cellSize.x * x, -(cellSize.y * y));
                Cell cell = Cell.Create(new Vector2Int(x, y), cachedTransform, position, cellSize);
                grid[x, y] = cell;
            }
        }

        public Cell GetCellFromPosition(int x, int y)
        {
            if (x >= grid.GetLength(0)) { throw new ArgumentOutOfRangeException(nameof(x), grid.GetLength(0), ""); }
            if (y >= grid.GetLength(1)) { throw new ArgumentOutOfRangeException(nameof(x), grid.GetLength(1), ""); }
            
            return grid[x,y];
        }

        public void CreateGrid(int width, int height)
        {
            for (int i = cachedTransform.childCount - 1; i >= 0; --i)
            {
                Destroy(cachedTransform.GetChild(i).gameObject);    
            }
            
            gridSize = new Vector2Int(width, height);
            CreateGrid();
        }
    }
}