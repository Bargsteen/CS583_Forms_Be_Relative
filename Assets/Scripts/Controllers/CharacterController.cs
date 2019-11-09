using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Controllers
{
    public class CharacterController : MonoBehaviour
    {
        [SerializeField] private float jumpForce = 40.0f;
        [SerializeField] private float movementSmoothing = .05f;
        [SerializeField] private bool airControl;
        [SerializeField] private LayerMask whatIsGround;
        [SerializeField] private Transform groundCheck;

        private const float GroundedRadius = .2f;
        private const float DampeningOffset = 10f;
        private bool _grounded;
        private Rigidbody2D _rb;
        private bool _facingRight = true;
        private Vector3 _velocity = Vector3.zero;

        [FormerlySerializedAs("OnLandEvent")] public UnityEvent onLandEvent;
    
        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            if (onLandEvent == null)
            {
                onLandEvent = new UnityEvent();
            }
        }

        private void FixedUpdate()
        {
            bool wasGrounded = _grounded;
            _grounded = false;


        
            foreach (Collider2D c in Physics2D.OverlapCircleAll(groundCheck.position, GroundedRadius, whatIsGround))
            {
                if (c.gameObject == gameObject) continue;
                _grounded = true;
                if (!wasGrounded)
                {
                    onLandEvent.Invoke();
                }
            }
        }

        public void Move(float move, bool jump)
        {
            if (!_grounded && !airControl) return;
        
            Vector3 targetVelocity = new Vector2(move * DampeningOffset, _rb.velocity.y);
            _rb.velocity = Vector3.SmoothDamp(_rb.velocity, targetVelocity, ref _velocity, movementSmoothing);
        
            if (move > 0 && !_facingRight || move < 0 && _facingRight)
            {
                Flip();
            }

            if (!_grounded || !jump) return;
        
            _grounded = false;
            _rb.AddForce(new Vector2(0f, jumpForce));
        }

        private void Flip()
        {
            _facingRight = !_facingRight;
        
            // TODO: Re-enable local scaling when a proper sprite has been added
//        Vector3 scale = transform.localScale;
//        scale.x *= -1;
//        transform.localScale = scale;
        }
    }
}
