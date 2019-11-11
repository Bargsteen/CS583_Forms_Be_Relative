using System;
using Manager;
using Misc;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions;

namespace Controllers.Menu
{
    public class LevelFinishedOverlayController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI headline;
        [SerializeField] private TextMeshProUGUI instructions;
        
        public static GameObject overlayPrefab;
        
        private void Awake()
        {
            if (LevelManager.Instance.LevelWon)
            {
                headline.text = GameText.LevelCompletedHeadline;
                instructions.text = GameText.LevelCompletedInstructions;
            }
            else
            {
                headline.text = GameText.LevelFailedHeadline;
                instructions.text = GameText.LevelFailedInstructions;
            }
        }

        private void Update()
        {
            if (!Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)) return;

            if (LevelManager.Instance.LevelWon)
            {
                LevelManager.Instance.LoadNextLevel();
            }
            else
            {
                LevelManager.Instance.LoadCurrentLevel();
            }
        }
    }
}
