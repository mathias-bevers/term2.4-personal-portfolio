using TMPro;
using UnityEngine;

namespace MineSweeper
{
    public class HeadsUpDisplay : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI minesLeftText;
        [SerializeField] private TextMeshProUGUI timePlayed;

        private int markedCells;
        private float timer;

        public void SetMinesLeft(int minesLeft)
        {
            minesLeftText.SetText($"{GameManager.instance.field.mineCount:000}");
        }

        public void UpdateMinesLeft(bool increase)
        {
            markedCells += increase ? 1 : -1;
            minesLeftText.SetText($"{GameManager.instance.field.mineCount - markedCells:000}");
        }

        private void Update()
        {
            UpdateTimer();
        }

        private void UpdateTimer()
        {
            timer += Time.deltaTime;
            
            int minutes = Mathf.FloorToInt(timer / 60f);
            int seconds = Mathf.FloorToInt(timer - (minutes * 60));
            timePlayed.SetText($"{minutes:00}:{seconds:00}");
        }
    }
}