using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

[System.Serializable]
public class MiningService
{
    [SerializeField] private InputActionReference miningAction;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Tilemap destructableTilemap;
    [SerializeField] private Transform rotator;
    [SerializeField] private Transform movingBeamEndPoint;

    [SerializeField] private float laserDistance;
    [SerializeField] private float damage;

    public bool IsMiningButtonPressed() => miningAction.action.IsPressed();

    public void Mine()
    {
        ActivateLaser(true);

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        Vector2 aimDireciton = mousePosition - (Vector2)rotator.transform.position;
        float angle = Mathf.Atan2(aimDireciton.y, aimDireciton.x) * Mathf.Rad2Deg;
        rotator.transform.rotation = Quaternion.Euler(0, 0, angle);

        RaycastHit2D hit = Physics2D.Raycast(rotator.transform.position, rotator.transform.right, laserDistance, layerMask);
        
        if (hit)
        {
            SetLinePosition(rotator.transform.position, hit.point);
        }
        else
        {
            movingBeamEndPoint.position = rotator.transform.position + (rotator.transform.right * laserDistance);
            SetLinePosition(rotator.transform.position, movingBeamEndPoint.position);
        }

        Vector2 tilePosition = new Vector2(Mathf.FloorToInt(hit.point.x), Mathf.FloorToInt(hit.point.y));
        if(rotator.transform.position.x > hit.point.x)
            tilePosition.x -= 1;
        
        destructableTilemap.SetTile(destructableTilemap.WorldToCell(tilePosition), null);

        Debug.DrawLine(rotator.transform.position, hit.point, Color.magenta);
        Debug.DrawLine(rotator.transform.position, movingBeamEndPoint.position, Color.green);
        Debug.Log(hit.collider);
    }

    public void ActivateLaser(bool active)
    {
        lineRenderer.enabled = active;
    }

    private void SetLinePosition(Vector2 startPosition, Vector2 endPosition)
    {
        lineRenderer.SetPosition(0, startPosition);
        lineRenderer.SetPosition(1, endPosition);
    }
}
