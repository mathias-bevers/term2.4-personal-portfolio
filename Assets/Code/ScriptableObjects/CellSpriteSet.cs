using UnityEngine;

namespace MineSweeper
{
    [CreateAssetMenu(fileName = "Cell Sprite Set", menuName = "MineSweeper/Cell Sprite Set")]

    public class CellSpriteSet : ScriptableObject
    {
        [field: SerializeField] public Sprite unopened { get; private set; }
        [field: SerializeField] public Sprite mine { get; private set; }
        [field: SerializeField] public Sprite exploded { get; private set; }
        [field: SerializeField] public Sprite flag { get; private set; }
        [field: SerializeField] public Sprite invalidFlag { get; private set; }

        [field: SerializeField] public Sprite[] numberSprites;
    }
}