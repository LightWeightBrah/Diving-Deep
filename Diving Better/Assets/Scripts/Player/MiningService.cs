using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

[System.Serializable]
public class MiningService
{
    [SerializeField] private InputActionReference miningAction;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Transform rotator;
    [SerializeField] private Transform movingBeamEndPoint;

    [SerializeField] private float laserDistance;
    [SerializeField] private float damage;
    [SerializeField] private float timeBetweenDamage;

    public bool IsMiningButtonPressed() => this.miningAction.action.IsPressed();

    public void Mine()
    {
        this.ActivateLaser(true);

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        Vector2 aimDireciton = mousePosition - (Vector2)this.rotator.transform.position;
        float angle = Mathf.Atan2(aimDireciton.y, aimDireciton.x) * Mathf.Rad2Deg;
        this.rotator.transform.rotation = Quaternion.Euler(0, 0, angle);

        RaycastHit2D hit = Physics2D.Raycast(this.rotator.transform.position, this.rotator.transform.right, 
            this.laserDistance, this.layerMask);
        
        if (hit)
        {
            this.SetLinePosition(this.rotator.transform.position, hit.point);
            if(hit.collider.TryGetComponent(out MiningBlock miningBlock))
                miningBlock.DealDamage(this.damage, this.timeBetweenDamage);
        }
        else
        {
            this.movingBeamEndPoint.position = this.rotator.transform.position + 
                (this.rotator.transform.right * this.laserDistance);
            this.SetLinePosition(this.rotator.transform.position, this.movingBeamEndPoint.position);
        }
    }

    public void ActivateLaser(bool active)
    {
        this.lineRenderer.enabled = active;
    }

    private void SetLinePosition(Vector2 startPosition, Vector2 endPosition)
    {
        this.lineRenderer.SetPosition(0, startPosition);
        this.lineRenderer.SetPosition(1, endPosition);
    }
}
