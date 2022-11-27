using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Utilities;
using Random = UnityEngine.Random;

public class TerrainManager : Singleton<TerrainManager>
{
    [Header("Speed")]
    [SerializeField] private float maxSpeed;
    [SerializeField] private float minSpeed;
    [SerializeField] private float carSpeed;
    [Header("Boundaries")]
    [SerializeField] private float zMinimumToDestroy = -50;
    [SerializeField] private float zMaximumToDestroy = 250;
    
    private float currentSpeed;

    public bool frontwardsCarWasSpawned;
    public bool backwardsCarWasSpawned;
    public int amountOfFrontwardsCars;
    
    public float CurrentSpeed => currentSpeed;

    public float CarSpeed => carSpeed;

    public float ZMinimumToDestroy => zMinimumToDestroy;
    public float ZMaximumToDestroy => zMaximumToDestroy;


    public void Accelerate(float acceleration)
    {
        currentSpeed = Mathf.Clamp(currentSpeed + acceleration, minSpeed, maxSpeed);
    }

    public void StopMovement()
    {
        currentSpeed = 0;
    }
}
