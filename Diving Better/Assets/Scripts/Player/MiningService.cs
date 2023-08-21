using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

[System.Serializable]
public class MiningService
{
    [SerializeField] private InputActionReference miningAction;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private Transform minerTransform;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Tilemap destructableTilemap;

    [SerializeField] private float damage;

    public bool IsMiningButtonPressed() => miningAction.action.IsPressed();

    public void Mine()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        Vector2 aimDireciton = mousePosition - (Vector2)minerTransform.position;
        float angle = Mathf.Atan2(aimDireciton.y, aimDireciton.x) * Mathf.Rad2Deg;
        minerTransform.rotation = Quaternion.Euler(0, 0, angle);

        RaycastHit2D raycastHit2D = Physics2D.Raycast(minerTransform.position, minerTransform.transform.right , 100000f, layerMask);
        
        if (raycastHit2D)
        {
            DrawRay(lineRenderer.transform.position, mousePosition);
        }
        else
        {
            DrawRay(lineRenderer.transform.position, lineRenderer.transform.right *  100.0f);
        }

        destructableTilemap.SetTile(destructableTilemap.WorldToCell(raycastHit2D.point), null);

        Debug.DrawLine(minerTransform.position, raycastHit2D.point, Color.magenta);
        Debug.Log(raycastHit2D.collider);
    }


    private void DrawRay(Vector2 startPosition, Vector2 endPosition)
    {
        lineRenderer.SetPosition(0, startPosition);
        lineRenderer.SetPosition(1, endPosition);
    }
}
