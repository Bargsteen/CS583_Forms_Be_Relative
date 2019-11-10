using Manager;
using UnityEngine;

namespace Controllers.Menu
{
    public class PlayLevelOverlayController : MonoBehaviour
    {
        private void Awake()
        {
            // TODO: Find a better place for this call
            GameManager.Instance.PauseGame();
        }

        private void Update()
        {
            if (!Input.GetKeyDown(KeyCode.Return)) return;
            
            gameObject.SetActive(false);
            GameManager.Instance.RunGame();
        }
    }
}