using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishEnemy : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody2D;
    [SerializeField] private float movementSpeed;

    private float horizontalDirection = 1.0f;
    private float verticalDirection = 1.0f;

    private void FixedUpdate()
    {
        this.rigidbody2D.velocity += new Vector2(this.horizontalDirection, this.verticalDirection) * this.movementSpeed * Time.fixedDeltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (this.horizontalDirection == 1.0f)
            this.horizontalDirection = -1.0f;
        else
            this.horizontalDirection = 1.0f;

        if(this.verticalDirection == 1.0f)
            this.verticalDirection = -1.0f;
        else
            this.verticalDirection = 1.0f;
    }

}
