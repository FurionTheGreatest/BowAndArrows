using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowRotation : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private bool _isHited = false;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if(_isHited) return;
        ApplyRotation();
    }

    private void ApplyRotation()
    {
        Vector2 arrowDirection = _rigidbody2D.velocity;

        var angle = Mathf.Atan2(arrowDirection.y, arrowDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle,Vector3.forward);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        _isHited = true;
        _rigidbody2D.velocity = Vector2.zero;
        _rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
    }
}
