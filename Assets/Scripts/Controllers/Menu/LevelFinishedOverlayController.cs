using System;
using Manager;
using UnityEngine;
using UnityEngine.Assertions;

namespace Controllers.Menu
{
    public class LevelFinishedOverlayController : MonoBehaviour
    {
        private void Awake()
        {
            Assert.IsTrue(LevelManager.Instance.LevelCompleted);
        }

        private void Update()
        {
            if (!Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)) return;

            if (LevelManager.Instance.LevelWon)
            {
                // TODO: Display Happy Text
                LevelManager.Instance.LoadNextLevel();
            }
            else
            {
                // TODO: Display sad text
                LevelManager.Instance.LoadCurrentLevel();
            }
        }
    }
}
