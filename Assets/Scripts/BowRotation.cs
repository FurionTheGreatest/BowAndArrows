using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowRotation : MonoBehaviour
{
    public Vector2 shootDirection;
    private Vector2 _bowPosition;

    private void Start()
    {
        _bowPosition = transform.position;
    }

    private void Update()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        shootDirection = CalculateDirection(mousePosition,_bowPosition);
        
        FaceToShootDirection();
    }

    private Vector2 CalculateDirection(Vector2 mousePosition, Vector2 bowPosition)
    {
        return mousePosition - bowPosition;
    }

    private void FaceToShootDirection()
    {
        transform.right = shootDirection;
    }
}
