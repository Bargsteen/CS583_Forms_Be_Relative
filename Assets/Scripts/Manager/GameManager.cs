using Misc;
using UnityEngine.Assertions;
using UnityEngine.Events;

namespace Manager
{
    public class GameManager : Singleton<GameManager>
    {
        private static int _currentScore;
        
        // TODO: Base on current level by getting info from ShapeManager
        private static int _maxScore = 2;
        
        private static readonly ScoreUpdatedEvent OnScoreUpdated = new ScoreUpdatedEvent();
        
        public static void IncrementScore()
        {
            _currentScore += 1;
            OnScoreUpdated?.Invoke(_currentScore, _maxScore);
        }

        public static void DecrementScore()
        {
            _currentScore -= 1;
            OnScoreUpdated?.Invoke(_currentScore, _maxScore);
        }
        
        public static void AddListenerToScoreUpdates(UnityAction<int, int> eventHandler)
        {
            OnScoreUpdated.AddListener(eventHandler);
        }

        private static void SetMaxScore(int maxScore)
        {
            _maxScore = maxScore;
            OnScoreUpdated?.Invoke(_currentScore, _maxScore);
        }
    }
}