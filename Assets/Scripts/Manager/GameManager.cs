using Misc;
using UnityEngine;
using UnityEngine.Events;

namespace Manager
{
    public class GameManager : Singleton<GameManager>
    {
        private int _currentScore;
        private int _maxScore;

        public int CurrentLevel { get; } = 1;
        public bool SavedProgressExists { get; } = false;

        public bool GameIsRunning { get; private set; }

        private readonly ScoreUpdatedEvent _onScoreUpdated = new ScoreUpdatedEvent();
        
        public void IncrementScore()
        {
            _currentScore += 1;
            _onScoreUpdated?.Invoke(_currentScore, _maxScore);
        }

        public void AddListenerToScoreUpdates(UnityAction<int, int> eventHandler)
        {
            _onScoreUpdated.AddListener(eventHandler);
        }

        public void SetMaxScore(int maxScore)
        {
            _maxScore = maxScore;
            _onScoreUpdated?.Invoke(_currentScore, _maxScore);
        }

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