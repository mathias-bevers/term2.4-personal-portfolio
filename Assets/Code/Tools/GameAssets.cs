using UnityEngine;

namespace MineSweeper.Tools
{
    public class GameAssets : MonoBehaviour
    {
        private static GameAssets _instance;
        public static GameAssets instance => _instance ??=
            Instantiate(Resources.Load("GameAssets") as GameObject).GetComponent<GameAssets>();

        [field: SerializeField] public Cell cell { get; private set; }
        [field: SerializeField] public PlayingField playingField { get; private set; }
    }
}