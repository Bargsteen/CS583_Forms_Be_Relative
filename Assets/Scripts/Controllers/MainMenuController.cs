using Manager;
using Misc;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Controllers
{
    public class MainMenuController : MonoBehaviour
    {
        [SerializeField] private Button continueButton;
        [SerializeField] private Button newGameButton;
        [SerializeField] private Button exitButton;
        private void Start()
        {
            if (GameManager.SavedProgressExists)
            {
                continueButton.enabled = true;
            }

            continueButton.onClick.AddListener(OnContinuePressed);
            newGameButton.onClick.AddListener(OnNewGamePressed);
            exitButton.onClick.AddListener(OnExitPressed);
        }

        private static void OnContinuePressed()
        {
            // TODO: Load relevant scene
        }
        
        private static void OnNewGamePressed()
        {
            SceneManager.LoadScene(Scenes.Level(1));
        }
        
        private static void OnExitPressed()
        {
            GameManager.SaveGame();
            #if UNITY_EDITOR
                        UnityEditor.EditorApplication.isPlaying = false;
            #else
                            Application.Quit();
            #endif
        }
        
        
    }
}
