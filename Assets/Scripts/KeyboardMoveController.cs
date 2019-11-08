using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class KeyboardMoveController : MonoBehaviour
{
    public float speed = 10.0f;
    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";

    private Rigidbody2D _rb;
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Get the horizontal and vertical axis.
        // By default they are mapped to the arrow keys.
        // The value is in the range -1 to 1
        float translationX = Input.GetAxis(Horizontal) * speed;

        // Make it move 10 meters per second instead of 10 meters per frame...
        translationX *= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rb.AddForce(new Vector3(0, 7, 0), ForceMode2D.Impulse);
        }

        // Move translation along the object's x-axis
        transform.Translate(translationX, 0, 0);
    }
}
