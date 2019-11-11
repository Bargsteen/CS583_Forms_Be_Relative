using Manager;
using UnityEngine;

namespace Controllers
{
    public class CreditsController : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
            {
                GameManager.Instance.SaveAndExitGame();
            }
        }
    }
}
