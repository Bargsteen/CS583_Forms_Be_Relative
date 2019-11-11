using Manager;
using Misc;
using UnityEngine;

namespace Controllers
{
    public class PersistenceController : MonoBehaviour
    {
        private const int DefaultLevel = 1;
        
        public static bool SavedProgressExists => LoadSavedLevel() != DefaultLevel;
        public static void SaveGame()
        {
            PlayerPrefs.SetInt(PlayerPrefsKeys.CurrentLevelKey, LevelManager.Instance.CurrentLevel);
        }

        public static int LoadSavedLevel()
        {
            return PlayerPrefs.GetInt(PlayerPrefsKeys.CurrentLevelKey, 1);
        }
        
    }
}