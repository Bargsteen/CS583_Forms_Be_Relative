using Manager;
using Misc;
using UnityEngine;

namespace Controllers
{
    public class CollectorBoxController : MonoBehaviour
    {
        [SerializeField] private Sprite spriteTypeToCollect;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            // Ignore if it wasn't a shape-type
            if (!other.CompareTag(Tag.Shape)) return;

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
    }
}
