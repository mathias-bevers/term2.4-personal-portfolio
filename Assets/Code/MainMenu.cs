using NaughtyAttributes;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MineSweeper
{
    public class MainMenu : MonoBehaviour
    {
        [Header("Texts")]
        [SerializeField] private TextMeshProUGUI title;
        [SerializeField] private TextMeshProUGUI subtitle;
        [SerializeField] private TextMeshProUGUI version;

        [Header("Buttons")]
        [SerializeField] private Button playButton;
        [SerializeField] private Button exitButton;

        [Header("Other")] 
        [Scene, SerializeField] private int sceneToLoad;

        private void Start()
        {
            title.SetText(Application.productName);
            subtitle.SetText(Application.companyName);
            version.SetText(string.Concat('v', Application.version));
            
            playButton.onClick.AddListener(() => SceneManager.LoadScene(sceneToLoad));
            exitButton.onClick.AddListener(ExitGame);
        }

        private static void ExitGame()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}
