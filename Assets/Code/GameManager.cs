using MineSweeper.Tools;
using UnityEngine;

namespace MineSweeper
{
    public class GameManager : Singleton<GameManager>
    {
        public PlayingField field { get; private set; }
        private GameEndScreen gameEndScreen;

        protected override void Awake()
        {
            gameEndScreen = FindObjectOfType<GameEndScreen>(true) ??
                            throw new ComponentNotFoundException<GameEndScreen>();
            CreateGame();
        }

        private void OnGameEnded(bool hasWon)
        {
            gameEndScreen.gameObject.SetActive(true);
            gameEndScreen.GameEnded(hasWon);
        }

        public void CreateGame()
        {
            if (!ReferenceEquals(null, field))
            {
                field.gameEndedEvent -= OnGameEnded;
                Destroy(field.gameObject);
            }

            field = Instantiate(GameAssets.instance.playingField, Vector2.zero, Quaternion.identity);
            field.gameEndedEvent += OnGameEnded;

            field.CreateGrid();
        }
    }
}