using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinAreaController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("You won!!");
    }
}
