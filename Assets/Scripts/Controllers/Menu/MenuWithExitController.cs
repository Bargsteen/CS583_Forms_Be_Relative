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
            GameManager.Instance.SaveAndExitGame();
        }
    }
}