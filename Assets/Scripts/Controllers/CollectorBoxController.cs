using System;
using Manager;
using Misc;
using UnityEngine;

namespace Controllers
{
    public class CollectorBoxController : MonoBehaviour
    {
        [SerializeField] private Sprite spriteTypeToCollect;
        private bool _isColliding;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            // Ignore if it wasn't a shape-type
            if (!other.CompareTag(Tag.Shape) || _isColliding) return;
            
            // Shapes such as circles have multiple contact points. We need to check whether we are already colliding.
            _isColliding = true;
            
            Destroy(other.gameObject);

            // If it is the correct type of shape
            if (other.GetComponent<SpriteRenderer>().sprite.name == spriteTypeToCollect.name)
            {
                GameManager.IncrementScore();
            }
            else
            {
                GameManager.DecrementScore();
            }
        }

        private void Update()
        {
            _isColliding = false;
        }
    }
}
