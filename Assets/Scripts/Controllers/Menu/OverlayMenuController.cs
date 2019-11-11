using Manager;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Controllers.Menu
{
    public class OverlayMenuController : MenuWithExitController
    {
        [SerializeField] private Button resumeButton;
        [SerializeField] private Button restartLevelButton;
        protected override void Start()
        {
            base.Start();
            resumeButton.onClick.AddListener(OnResumePressed);
            restartLevelButton.onClick.AddListener(OnRestartLevelPressed);
        }

        private void OnResumePressed()
        {
            GameManager.Instance.RunGame();
            gameObject.SetActive(false);
        }

        private static void OnRestartLevelPressed()
        {
            LevelManager.Instance.LoadCurrentLevel();
        }
    }
}
