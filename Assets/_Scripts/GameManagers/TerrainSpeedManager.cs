using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class TerrainSpeedManager : Singleton<TerrainSpeedManager>
{
    [SerializeField] private float maxSpeed;
    [SerializeField] private float minSpeed;
    
    private float currentSpeed;

    public float CurrentSpeed => currentSpeed;

    public void Accelerate(float acceleration)
    {
        currentSpeed = Mathf.Clamp(currentSpeed + acceleration, minSpeed, maxSpeed);
    }

    public void StopMovement()
    {
        currentSpeed = 0;
    }
}
