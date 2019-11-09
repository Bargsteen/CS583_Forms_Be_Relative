﻿using System;
using System.Collections.Generic;
using System.Linq;
using Controllers;
using DefaultNamespace;
using UnityEngine;

namespace Manager
{
    public class ShapeManager : MonoBehaviour
    {
        private ChangeShapeController[] _shapes;

        private void Awake()
        {
            _shapes = FindObjectsOfType<ChangeShapeController>();
        }

        public void ApplyOnEachShape(Action<ChangeShapeController> action)
        {
            foreach (var changeShapeController in _shapes)
            {
                action.Invoke(changeShapeController);
            }
        }
    }
}