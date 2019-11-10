using System;
using UnityEngine.Events;

namespace Misc
{
    [Serializable]
    public class ScoreUpdatedEvent : UnityEvent<int, int>
    {
    }
}