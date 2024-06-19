using System;
using UnityEngine;
using UnityEngine.UI;

namespace MineSweeper
{
    [RequireComponent(typeof(Animator))]
    public class GameEndScreen : MonoBehaviour
    {
        private static readonly int GameEnd = Animator.StringToHash("GameEnd");
        private static readonly int HasWon = Animator.StringToHash("HasWon");
        private static readonly int GameRestart = Animator.StringToHash("GameRestart");

        [SerializeField] private Button newGameButton;
        [SerializeField] private Button quitButton;
        
        private Animator animationController;

        public void GameEnded(bool hasWon)
        {
            animationController = GetComponent<Animator>();
            
            newGameButton.onClick.AddListener(Restart);
            quitButton.onClick.AddListener(Exit);
            
            animationController.SetTrigger(GameEnd);
            animationController.SetBool(HasWon, hasWon);
        }

        private void Restart()
        {
            GameManager.instance.CreateGame();
            
            newGameButton.onClick.RemoveAllListeners();
            quitButton.onClick.RemoveAllListeners();
            
            animationController.SetTrigger(GameRestart);
            gameObject.SetActive(false);
        }

        private void Exit()
        {
            throw new NotImplementedException("This needs to go to the main menu!");
            newGameButton.onClick.RemoveAllListeners();
            quitButton.onClick.RemoveAllListeners();
        }
    }
}