using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

[System.Serializable]
public class MovementService
{
    [SerializeField] private Rigidbody2D rigidbody2D;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float brakingSpeed;

    [SerializeField] private InputActionReference brakeAction;
    [SerializeField] private InputActionReference moveAction;

    private bool isBrakePressed;

    public void Move(Vector2 moveVector)
    {
        if (isBrakePressed) return;

        rigidbody2D.AddForce(moveVector * moveSpeed, ForceMode2D.Force);

        if(rigidbody2D.velocity.magnitude > maxSpeed)
        {
            rigidbody2D.velocity = Vector2.ClampMagnitude(rigidbody2D.velocity, maxSpeed);
        }
    }

    public void Brake()
    {
        rigidbody2D.velocity = Vector2.Lerp(rigidbody2D.velocity, Vector2.zero, brakingSpeed * Time.deltaTime);
        Debug.Log("Braking....");
    }

    public bool IsBrakePressed()
    {
        isBrakePressed = brakeAction.action.IsPressed();
        return isBrakePressed;
    }
}
