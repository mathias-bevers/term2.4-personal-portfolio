using NaughtyAttributes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MineSweeper
{
    public class HeadsUpDisplay : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI minesLeftText;
        [SerializeField] private TextMeshProUGUI timePlayed;
        [SerializeField] private Button backButton;
        [Scene, SerializeField] private int sceneToLoad;

        private float timer;
        private int markedCells;

        private void Update()
        {
            UpdateTimer();
        }

        private void OnEnable()
        {
            backButton.onClick.AddListener(() => UnityEngine.SceneManagement.SceneManager.LoadScene(sceneToLoad));
        }

        private void OnDisable()
        {
            backButton.onClick.RemoveAllListeners();
        }

        public void Initialize(int minesLeft)
        {
            timer = 0;
            markedCells = 0;

            minesLeftText.SetText($"{minesLeft:000}");
            gameObject.SetActive(true);
        }

        public void UpdateMinesLeft(bool increase)
        {
            markedCells += increase ? 1 : -1;
            minesLeftText.SetText($"{GameManager.instance.field.mineCount - markedCells:000}");
        }

        private void UpdateTimer()
        {
            timer += Time.deltaTime;

            int minutes = Mathf.FloorToInt(timer / 60f);
            int seconds = Mathf.FloorToInt(timer - minutes * 60);
            timePlayed.SetText($"{minutes:00}:{seconds:00}");
        }
    }
}