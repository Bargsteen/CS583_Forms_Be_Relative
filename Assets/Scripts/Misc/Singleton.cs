using UnityEngine;

namespace Misc
{
    public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;

        private static bool ShuttingDown { get; } = false;
        private static object Lock { get; } = new object();

        public static T Instance
        {
            get
            {
                if (ShuttingDown)
                {
                    Debug.LogWarning($"The {typeof(T)} has already been destroyed. Returning null.");
                    return null;
                }

                lock (Lock)
                {
                    // If it already exists, just return it
                    if (_instance != null) return _instance;

                    // Try to find an existing instance and return
                    _instance = FindObjectOfType<T>();
                    if (_instance != null) return _instance;

                    // Otherwise, create a new object, attach an instance to it, and return
                    var singletonObject = new GameObject();
                    _instance = singletonObject.AddComponent<T>();
                    singletonObject.name = $"{typeof(T)} (Singleton)";
                    DontDestroyOnLoad(singletonObject);

                    return _instance;
                }
            }
        }
    }
}