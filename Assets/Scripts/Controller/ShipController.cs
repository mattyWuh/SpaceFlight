using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(InputHandler), typeof(Rigidbody))]
public class ShipController : MonoBehaviour
{
    // // Variables
    // public float speed = 1f;

    // // Components
    // [HideInInspector]
    // public InputHandler inputs;

    // private void Start()
    // {
    //     inputs = GetComponent<InputHandler>();
    // }


    // void FixedUpdate()
    // {
    //     Move(inputs.movement);
    // }

    // void Move(Vector2 input)
    // {
    //     Vector3 inputDirection = new Vector3(input.x, input.y, 0).normalized;

    //     Vector3 moveVelocity = speed * inputDirection;
    // }

}