using Controllers;
using Misc;
using UnityEngine;

namespace Manager
{
    public class GameManager : Singleton<GameManager>
    {
        public bool GameIsRunning { get; private set; }

        public void RunGame()
        {
            GameIsRunning = true;
            
            // Runs the game at regular speed
            Time.timeScale = 1; 
        }

        public void PauseGame()
        { 
            GameIsRunning = false;
            
            // Stops the time in the game
            Time.timeScale = 0;
        }

        public void SaveAndExitGame()
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