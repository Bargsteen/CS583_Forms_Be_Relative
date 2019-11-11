using System;
using Controllers.Menu;
using UnityEngine;

namespace Manager
{
    public class MenuManager : MonoBehaviour
    {
        [SerializeField] private OverlayMenuController overlayMenuController;
        [SerializeField] private PlayLevelOverlayController playLevelOverlayController;
        [SerializeField] private LevelFinishedOverlayController levelFinishedOverlayController;

        private bool _playLevelOverlayWasActive;
        
        private void Update()
        {
            // TODO: Clean this logic up
            
            if (!Input.GetKeyDown(KeyCode.Escape) && !Input.GetKeyDown(KeyCode.KeypadEnter)) return;
            
            if (GameManager.Instance.GameIsRunning || playLevelOverlayController.isActiveAndEnabled)
            {
                GameManager.Instance.PauseGame();
                
                // Only needed when overlayMenu is opened before a game has been started
                if (playLevelOverlayController.isActiveAndEnabled)
                {
                    playLevelOverlayController.gameObject.SetActive(false);
                    _playLevelOverlayWasActive = true;
                }
                
                overlayMenuController.gameObject.SetActive(true);
            }
            else
            {
                overlayMenuController.gameObject.SetActive(false);
                
                // Re-enable playLevelOverlay if it was on before
                if (_playLevelOverlayWasActive)
                {
                    playLevelOverlayController.gameObject.SetActive(true);
                    _playLevelOverlayWasActive = false;
                }
                else // Otherwise, just run the game
                {
                    GameManager.Instance.RunGame();
                }
            }
        }

        public void ShowLevelFinishedOverlay()
        {
            levelFinishedOverlayController.gameObject.SetActive(true);
        }
    }
}