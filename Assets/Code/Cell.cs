using System;
using UnityEngine;

namespace MineSweeper
{
    public class Cell : MonoBehaviour
    {
        private Vector2Int gridPosition;
        private Transform cachedTransform;
        
        public static Cell Create(Vector2Int gridPosition, Transform parent, Vector2 worldPosition, Vector2 scale)
        {
            Cell cell = Instantiate(GameAssets.instance.cell);
            cell.cachedTransform = cell.transform;
            cell.Initialize(gridPosition, parent, worldPosition, scale);
            return cell;
        }

        private void Initialize(Vector2Int gridPosition, Transform parent, Vector2 worldPosition, Vector2 scale)
        {
            this.gridPosition = gridPosition;
            cachedTransform.SetParent(parent);
            cachedTransform.localScale = scale;
            cachedTransform.SetLocalPositionAndRotation(worldPosition, Quaternion.identity);
        }
    }
}