using System;
using UnityEngine;

namespace MineSweeper
{
    public class GameManager : Singleton<GameManager>
    {
        [field: SerializeField] public PlayingField field {get; private set;}
       
        
        [SerializeField] private Animator gameEndController;
        
        private static readonly int GameEnd = Animator.StringToHash("GameEnd");
        private static readonly int HasWon = Animator.StringToHash("HasWon");

        private void Start()
        {
            field.CreateGrid();
            field.gameEndedEvent += OnGameEnded;
        }

        private void OnGameEnded(bool hasWon)
        {
            gameEndController.gameObject.SetActive(true);
            
            gameEndController.SetTrigger(GameEnd);
            gameEndController.SetBool(HasWon, hasWon);
        }
    }
}