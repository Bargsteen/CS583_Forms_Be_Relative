using System;
using Manager;
using UnityEngine;
using UnityEngine.UI;

namespace Controllers.Menu
{
    public abstract class MenuWithExitController : MonoBehaviour
    {
        [SerializeField] protected Button exitButton;

        protected virtual void Start()
        {
            exitButton.onClick.AddListener(OnExitPressed);
        }
        
        private static void OnExitPressed()
        {
            PersistenceController.SaveGame();
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }
    }
}