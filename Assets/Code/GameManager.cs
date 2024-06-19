using MineSweeper.Tools;
using UnityEngine;

namespace MineSweeper
{
    public class GameManager : Singleton<GameManager>
    {
        public PlayingField field { get; private set; }
        public HeadsUpDisplay hud { get; private set; }
        
        private GameEndScreen gameEndScreen;
        
        protected override void Awake()
        {
            hud = FindObjectOfType<HeadsUpDisplay>(true) ?? throw new ComponentNotFoundException<HeadsUpDisplay>();
            gameEndScreen = FindObjectOfType<GameEndScreen>(true) ??
                            throw new ComponentNotFoundException<GameEndScreen>();
            
            CreateGame();
        }

        private void OnGameEnded(bool hasWon)
        {
            hud.gameObject.SetActive(false);
            
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
            field.CreateGrid();
            field.gameEndedEvent += OnGameEnded;
            
            hud.Initialize(field.mineCount);
        }
    }
}