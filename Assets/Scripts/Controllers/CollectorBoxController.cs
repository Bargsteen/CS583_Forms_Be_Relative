using System;
using Manager;
using UnityEngine;

namespace Controllers
{
    public class CollectorBoxController : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            GameManager.IncrementCurrentScore();
        }
    }
}
