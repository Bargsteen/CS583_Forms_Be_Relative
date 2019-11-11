using System;
using UnityEngine;

namespace Controllers
{
    public class MusicController : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(this);
        }
    }
}