using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private MovementService movementService;
    [SerializeField] private MiningService miningService;
    [SerializeField] private PlayerControls inputActions;

    private void FixedUpdate()
    {
        this.movementService.Move(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"))); 
    }

    private void Update()
    {
        if (this.movementService.IsBrakePressed())
            this.movementService.Brake();

        if (this.miningService.IsMiningButtonPressed())
            this.miningService.Mine();
        else
            this.miningService.ActivateLaser(false);

    }
}
