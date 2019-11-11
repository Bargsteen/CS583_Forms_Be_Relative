using Misc;
using UnityEngine;
using UnityEngine.Events;

namespace Manager
{
    public class GameManager : Singleton<GameManager>
    {
        public bool SavedProgressExists { get; } = false;
        public bool GameIsRunning { get; private set; }
        
        public void SaveGame()
        {
            // TODO: Save game in PlayerPrefs
        }

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
    }
}