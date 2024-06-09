using UnityEngine;

namespace MineSweeper
{
    public class GameAssets : MonoBehaviour
    {
        private static GameAssets _instance;
        public static GameAssets instance => _instance ??=
            Instantiate(Resources.Load("GameAssets") as GameObject).GetComponent<GameAssets>();

        [field: SerializeField] public Cell cell { get; private set; }
    }
}