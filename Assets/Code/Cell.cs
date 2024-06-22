using System;
using MineSweeper.Tools;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MineSweeper
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Cell : MonoBehaviour, IPointerClickHandler
    {
        public enum State { Closed, Opened, Marked }

        [SerializeField, Expandable] private CellSpriteSet spriteSet;

        public bool isMine { get; private set; }
        public State state { get; private set; }

        private int neighborCount;
        private PlayingField parent;
        private new SpriteRenderer renderer;
        private Transform cachedTransform;
        private Vector2Int gridPosition;


        public void OnPointerClick(PointerEventData eventData)
        {
            switch (eventData.button)
            {
                case PointerEventData.InputButton.Left:
                    OpenCell();
                    break;
                case PointerEventData.InputButton.Right:
                    MarkCell();
                    break;
                case PointerEventData.InputButton.Middle: break;
                default: throw new ArgumentOutOfRangeException();
            }
        }

        public event Action<bool> revealedEvent;

        public static Cell Create(PlayingField parent, Vector2Int gridPosition, Vector2 worldPosition, Vector2 scale,
            bool isBomb)
        {
            Cell cell = Instantiate(GameAssets.instance.cell);
            cell.cachedTransform = cell.transform;
            cell.renderer = cell.GetComponent<SpriteRenderer>();
            cell.Initialize(parent, gridPosition, worldPosition, scale, isBomb);
            return cell;
        }

        private void Initialize(PlayingField parent, Vector2Int gridPosition, Vector2 worldPosition, Vector2 scale,
            bool isBomb)
        {
            this.parent = parent;
            isMine = isBomb;
            this.gridPosition = gridPosition;

            cachedTransform.SetParent(parent.cachedTransform);
            cachedTransform.localScale = scale;
            cachedTransform.SetLocalPositionAndRotation(worldPosition, Quaternion.identity);

            renderer.sprite = spriteSet.unopened;
        }

        public void SetNearBombCount(int neighborCount) => this.neighborCount = neighborCount;

        private void OpenCell()
        {
            if (state != State.Closed) { return; }

            state = State.Opened;

            renderer.sprite = isMine ? spriteSet.exploded : spriteSet.numberSprites[neighborCount];

            revealedEvent?.Invoke(isMine);

            if (isMine || neighborCount != 0) { return; }

            foreach (Cell neighbor in parent.GetNeighbors(gridPosition.x, gridPosition.y)) { neighbor.OpenCell(); }
        }

        public bool RevealCell()
        {
            if (state == State.Opened) { return false; }

            if (isMine) { renderer.sprite = spriteSet.mine; }
            else if (state == State.Marked) { renderer.sprite = spriteSet.invalidFlag; }
            else { renderer.sprite = spriteSet.numberSprites[neighborCount]; }

            return true;
        }

        private void MarkCell()
        {
            switch (state)
            {
                case State.Opened: return;
                case State.Marked:
                    renderer.sprite = spriteSet.unopened;
                    state = State.Closed;
                    GameManager.instance.hud.UpdateMinesLeft(false);
                    break;
                case State.Closed:
                    renderer.sprite = spriteSet.flag;
                    state = State.Marked;
                    GameManager.instance.hud.UpdateMinesLeft(true);
                    break;
                default: throw new ArgumentOutOfRangeException();
            }
        }
    }
}