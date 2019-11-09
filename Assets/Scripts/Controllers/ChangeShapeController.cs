using UnityEngine;

namespace Controllers
{
    public class ChangeShapeController : MonoBehaviour
    {
        [SerializeField] private Sprite initialShape;
        [SerializeField] private Sprite secondShape;
        
        [SerializeField] private Collider2D initialCollider;
        [SerializeField] private Collider2D secondCollider;

        private SpriteRenderer _spriteRenderer;
        private Sprite _currentShape;
        private Collider2D _currentCollider;

        private bool _usingInitialShape = true;

        private void Awake()
        {
            _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            _currentShape = gameObject.GetComponent<Sprite>();
            _currentCollider = gameObject.GetComponent<Collider2D>();
        }

        public void ChangeShape()
        {
            // Disable old collider
            _currentCollider.enabled = false;
        
            // Swap shape and collider
            (_currentShape, _currentCollider) =
                _usingInitialShape ? (secondShape, secondCollider) : (initialShape, initialCollider);
        
            // Enable new collider and set new shape
            _currentCollider.enabled = true;
            _spriteRenderer.sprite = _currentShape;
        
            _usingInitialShape = !_usingInitialShape;
        }
    }
}