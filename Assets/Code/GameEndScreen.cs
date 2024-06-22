using NaughtyAttributes;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        [Scene, SerializeField] private int sceneToLoad;

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

        private void Exit() => SceneManager.LoadScene(sceneToLoad);
    }
}