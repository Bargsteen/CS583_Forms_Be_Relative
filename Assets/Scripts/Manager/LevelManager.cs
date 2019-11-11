using Controllers.Menu;
using Misc;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Manager
{
    public class LevelManager : Singleton<LevelManager>
    {
        public int CurrentLevel { get; private set; } = 1;
        public bool LevelCompleted => ShapesCollectedInLevel == TotalShapesInLevel;
        public bool LevelWon => CorrectShapesCollectedInLevel == TotalShapesInLevel;
        
        private int ShapesCollectedInLevel { get; set; }
        private int CorrectShapesCollectedInLevel { get; set; }
        private int TotalShapesInLevel { get; set; }

        public ShapeManager ShapeManager
        {
            get => _shapeManager;
            set
            {
                _shapeManager = value;
                TotalShapesInLevel = ShapeManager.TotalShapesInLevel;
                _onScoreUpdated?.Invoke(CorrectShapesCollectedInLevel, TotalShapesInLevel);
            }
        }

        private readonly ScoreUpdatedEvent _onScoreUpdated = new ScoreUpdatedEvent();
        private ShapeManager _shapeManager;

        public void LoadNextLevel()
        {
            CurrentLevel += 1;
            LoadCurrentLevel();
        }

        public void LoadCurrentLevel()
        {
            LoadLevel(Scenes.Level(CurrentLevel));
        }

        public void LoadFirstLevel()
        {
            LoadLevel(Scenes.Level(1));
        }

        private void LoadLevel(int level)
        {
            SceneManager.LoadScene(level);
            PrepareForNewLevel();
            
        }

        private void PrepareForNewLevel()
        {
            ShapesCollectedInLevel = 0;
            CorrectShapesCollectedInLevel = 0;
        }

        public void HandleShapeCollected(bool shapeWasCorrectTypeForBox)
        {
            ShapesCollectedInLevel += 1;
            if (shapeWasCorrectTypeForBox)
            {
                CorrectShapesCollectedInLevel += 1;
                
                _onScoreUpdated?.Invoke(CorrectShapesCollectedInLevel, TotalShapesInLevel);
            }
            if (LevelCompleted)
            {
                HandleLevelCompletion();
            }
        }

        public void AddListenerToScoreUpdates(UnityAction<int, int> eventHandler)
        {
            _onScoreUpdated.AddListener(eventHandler);
        }

        private static void HandleLevelCompletion()
        {
            var menuManager = FindObjectOfType<MenuManager>();
            menuManager.ShowLevelFinishedOverlay();
        }
    }
}