using Misc;
using UnityEngine;

namespace Controllers
{
    public class CharacterMovementController : MonoBehaviour
    {
        public CharacterController controller;

        [SerializeField] private float movementSpeed = 40f;

        private float _horizontalMove;
        private bool _jump;

        private void Update()
        {
            _horizontalMove = Input.GetAxisRaw(Axes.Horizontal) * movementSpeed;

            if (Input.GetButtonDown("Jump"))
            {
                _jump = true;
            }
        }

        private void FixedUpdate()
        {
            controller.Move(_horizontalMove * Time.fixedDeltaTime, _jump);
            _jump = false;
        }
    }
}