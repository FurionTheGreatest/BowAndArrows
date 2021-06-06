using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowShoot : MonoBehaviour
{
    public float launchForce;
    public GameObject arrowPrefab;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        var arrow = Instantiate(arrowPrefab, transform.position, transform.rotation);
        var arrowRigidbody = arrow.GetComponent<Rigidbody2D>();
        arrowRigidbody.AddForce(transform.right * launchForce);
    }
}
