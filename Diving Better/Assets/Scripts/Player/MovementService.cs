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
    [SerializeField] private InputActionReference moveAcftion;

    private bool isBrakePressed;

    public void Move(Vector2 moveVector)
    {
        if (this.isBrakePressed)
        {
            Debug.Log("returning coz break");
            return;
        }


        this.rigidbody2D.AddForce(moveVector * this.moveSpeed, ForceMode2D.Force);

        /*if(this.rigidbody2D.velocity.magnitude > this.maxSpeed)
        {
            this.rigidbody2D.velocity = Vector2.ClampMagnitude(this.rigidbody2D.velocity, this.maxSpeed);
        }*/
    }

    public void Brake()
    {
        this.rigidbody2D.velocity = Vector2.Lerp(this.rigidbody2D.velocity, Vector2.zero, this.brakingSpeed * Time.deltaTime);
        Debug.Log("Braking....");
    }

    public bool IsBrakePressed()
    {
        this.isBrakePressed = this.brakeAction.action.IsPressed();
        return this.isBrakePressed;
    }
}
