using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private MovementService movementService;
    [SerializeField] private PlayerControls inputActions;

    private void FixedUpdate()
    {
        movementService.Move(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"))); 
    }

    private void Update()
    {
        if (movementService.IsBrakePressed())
            movementService.Brake();
    }
}
