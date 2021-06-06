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
        shootDirection = (Vector2)mousePosition - _bowPosition;
        
        FaceToShootDirection();
    }

    private void FaceToShootDirection()
    {
        transform.right = shootDirection;
    }
}
