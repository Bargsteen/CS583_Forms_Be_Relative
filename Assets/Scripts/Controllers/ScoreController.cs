using System;
using Manager;
using TMPro;
using UnityEngine;

namespace Controllers
{
    public class ScoreController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreText;

        private void Awake()
        {
            GameManager.AddListenerToScoreUpdates(UpdateScore);
        }

        private void UpdateScore(int current, int max)
        {
            scoreText.text = $"{current} / {max}";
        }
    }
}