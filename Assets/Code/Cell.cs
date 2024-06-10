using System;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MineSweeper
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Cell : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField, Expandable] private CellSpriteSet spriteSet;

        private bool isBomb;
        private int neighborCount;
        private new SpriteRenderer renderer;
        private Transform cachedTransform;

        public void OnPointerClick(PointerEventData eventData)
        {
            switch (eventData.button)
            {
                case PointerEventData.InputButton.Left:
                    OpenSpace();
                    break;
                case PointerEventData.InputButton.Right:
                    MarkSpace();
                    break;
                case PointerEventData.InputButton.Middle: break;
                default: throw new ArgumentOutOfRangeException();
            }
        }

        public static Cell Create(Transform parent, Vector2 worldPosition, Vector2 scale, bool isBomb)
        {
            Cell cell = Instantiate(GameAssets.instance.cell);
            cell.cachedTransform = cell.transform;
            cell.renderer = cell.GetComponent<SpriteRenderer>();
            cell.Initialize(parent, worldPosition, scale, isBomb);
            return cell;
        }

        private void Initialize(Transform parent, Vector2 worldPosition, Vector2 scale, bool isBomb)
        {
            this.isBomb = isBomb;

            cachedTransform.SetParent(parent);
            cachedTransform.localScale = scale;
            cachedTransform.SetLocalPositionAndRotation(worldPosition, Quaternion.identity);

            renderer.sprite = spriteSet.unopened;
        }

        public void SetNeighborCount(int neighorCount)
        {
            throw new NotImplementedException();
        }

        private void OpenSpace()
        {
            if (!isBomb)
            {
                renderer.sprite = spriteSet.numberSprites[neighborCount];
            }
            else
            {
                renderer.sprite = spriteSet.exploded;
                Debug.Log("BOOOOOOM!");
                throw new NotImplementedException("Game over not implemented!");
            }
        }

        private void MarkSpace()
        {
            throw new NotImplementedException();
        }
    }
}