using System;
using Controllers;
using UnityEngine;

namespace Manager
{
    public class ShapeManager : MonoBehaviour
    {
        private ChangeShapeController[] _shapes;

        private void Awake()
        {
            _shapes = FindObjectsOfType<ChangeShapeController>();
            GameManager.SetMaxScore(_shapes.Length);
        }

        public void ApplyOnEachShape(Action<ChangeShapeController> action)
        {
            foreach (var changeShapeController in _shapes)
            {
                if (changeShapeController != null)
                {
                    action.Invoke(changeShapeController);
                }
            }
        }
    }
}


