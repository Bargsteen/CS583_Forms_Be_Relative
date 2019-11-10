using Manager;
using Misc;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Controllers.Menu
{
    public class MainMenuController : MenuWithExitController
    {
        [SerializeField] private Button continueButton;
        [SerializeField] private Button newGameButton;
        protected override void Start()
        {
            base.Start();
            
            if (GameManager.Instance.SavedProgressExists)
            {
                continueButton.enabled = true;
            }

            continueButton.onClick.AddListener(OnContinuePressed);
            newGameButton.onClick.AddListener(OnNewGamePressed);
        }

        private static void OnContinuePressed()
        {
            // TODO: Load relevant scene
        }
        
        private static void OnNewGamePressed()
        {
            SceneManager.LoadScene(Scenes.Level(1));
        }
    }
}
