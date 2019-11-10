using System;
using UnityEngine.Events;

namespace Manager
{
    [Serializable]
    public class ScoreUpdatedEvent : UnityEvent<int, int>
    {
    }
}