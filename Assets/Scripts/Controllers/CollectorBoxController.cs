﻿using System;
using Manager;
using Misc;
using UnityEngine;
using UnityEngine.Serialization;

namespace Controllers
{
    public class CollectorBoxController : MonoBehaviour
    {
        [SerializeField] private Sprite spriteTypeToCollect;
        private SoundClipController _soundClipController;
        
        private bool _isColliding;

        public ShapeCollectedEvent onShapeCollected = new ShapeCollectedEvent();

        private void Awake()
        {
            onShapeCollected.AddListener(LevelManager.Instance.HandleShapeCollected);
            _soundClipController = GetComponent<SoundClipController>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            // Ignore if it wasn't a shape-type
            if (!other.CompareTag(Tag.Shape) || _isColliding) return;
            
            // Shapes such as circles have multiple contact points. We need to check whether we are already colliding.
            _isColliding = true;
            
            Destroy(other.gameObject);

            bool shapeWasCorrectType = other.GetComponent<SpriteRenderer>().sprite.name == spriteTypeToCollect.name;
            onShapeCollected?.Invoke(shapeWasCorrectType);

            if (shapeWasCorrectType)
            {
                _soundClipController.PlayCorrectShapeSound();
            }
            else
            {
                _soundClipController.PlayWrongShapeSound();
            }
        }

        private void Update()
        {
            _isColliding = false;
        }
    }
}
