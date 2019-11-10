using Misc;
using UnityEngine.Assertions;
using UnityEngine.Events;

namespace Manager
{
    public class GameManager : Singleton<GameManager>
    {
        private static int _currentScore;
        private static int _maxScore;

        public static bool SavedProgressExists { get; } = false;
        
        private static readonly ScoreUpdatedEvent OnScoreUpdated = new ScoreUpdatedEvent();

        public static void IncrementScore()
        {
            _currentScore += 1;
            OnScoreUpdated?.Invoke(_currentScore, _maxScore);
        }

        public static void AddListenerToScoreUpdates(UnityAction<int, int> eventHandler)
        {
            OnScoreUpdated.AddListener(eventHandler);
        }

        public static void SetMaxScore(int maxScore)
        {
            _maxScore = maxScore;
            OnScoreUpdated?.Invoke(_currentScore, _maxScore);
        }

        public static void SaveGame()
        {
            // TODO: Save game in PlayerPrefs
        }
    }
}