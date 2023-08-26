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
    [SerializeField] private Tilemap destructableTilemap;
    [SerializeField] private Transform rotator;
    [SerializeField] private Transform movingBeamEndPoint;
    [SerializeField] private UnityEvent<Vector2Int, float> onDamageTile;

    [SerializeField] private float laserDistance;
    [SerializeField] private float damage;

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
            SetLinePosition(this.rotator.transform.position, hit.point);
        }
        else
        {
            this.movingBeamEndPoint.position = this.rotator.transform.position + 
                (this.rotator.transform.right * this.laserDistance);
            this.SetLinePosition(this.rotator.transform.position, this.movingBeamEndPoint.position);
        }

        Vector2 tilePosition = new Vector2(Mathf.FloorToInt(hit.point.x), Mathf.FloorToInt(hit.point.y));
        if(this.rotator.transform.position.x > hit.point.x)
            tilePosition.x -= 1;

        Vector3Int cellPosition = this.destructableTilemap.WorldToCell(tilePosition);
        TileBase tile = this.destructableTilemap.GetTile(cellPosition);
        if (tile != null)
            this.onDamageTile?.Invoke(new Vector2Int(cellPosition.x, cellPosition.y), damage);

        //Debug.DrawLine(rotator.transform.position, hit.point, Color.magenta);
        //Debug.DrawLine(rotator.transform.position, movingBeamEndPoint.position, Color.green);
        //Debug.Log(hit.collider);
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
