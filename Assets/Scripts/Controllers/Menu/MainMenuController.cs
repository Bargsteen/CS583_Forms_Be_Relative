﻿using Manager;
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
            
            if (PersistenceController.SavedProgressExists)
            {
                continueButton.gameObject.SetActive(true);
            }

            continueButton.onClick.AddListener(OnContinuePressed);
            newGameButton.onClick.AddListener(OnNewGamePressed);
        }

        private static void OnContinuePressed()
        {
            LevelManager.Instance.CurrentLevel = PersistenceController.LoadSavedLevel();
            LevelManager.Instance.LoadCurrentLevel();
        }
        
        private static void OnNewGamePressed()
        {
            LevelManager.Instance.LoadFirstLevel();
        }
    }
}
