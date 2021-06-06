using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryPrediction : MonoBehaviour
{
    public GameObject pointPrefab;

    public GameObject[] trajectoryPoints;

    public int pointsCount;

    private BowRotation _bowRotation;
    private BowShoot _bowShoot;

    private void Awake()
    {
        _bowRotation = GetComponent<BowRotation>();
        _bowShoot = GetComponent<BowShoot>();
    }

    private void Start()
    {
        trajectoryPoints = new GameObject[pointsCount];
        var trajectoryParent = Instantiate(new GameObject("TrajectoryParent"), transform);
        
        for (var i = 0; i < pointsCount; i++)
        {
            trajectoryPoints[i] = Instantiate(pointPrefab,transform.position,Quaternion.identity,trajectoryParent.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (var i = 0; i < trajectoryPoints.Length; i++)
        {
            trajectoryPoints[i].transform.position = SetupTrajectoryPoints(i * 0.1f);
        }
    }

    private Vector2 SetupTrajectoryPoints(float time)
    {
        var currentPosition = (Vector2) transform.position +
                              (_bowRotation.shootDirection.normalized * _bowShoot.launchForce * time) + 0.5f *
                              Physics2D.gravity * (time*time);
        return currentPosition;
    }
}
