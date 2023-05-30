using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BuildingGenerator : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private GameObject floor;
    [SerializeField] private GameObject roof;
    [Header("SpawnPoint")]
    [SerializeField] private Transform spawnPoint;
    [Header("Range of random floor amount")]
    [SerializeField] private int minFloorAmount;
    [SerializeField] private int maxFloorAmount;
    [Header("Values")]
    [SerializeField] private float floorHeight = 4f;
    
    private void Start()
    {
        int floorAmount = Random.Range(minFloorAmount, maxFloorAmount);

        for (int i = 0; i < floorAmount; i++)
        {
            SpawnFloor();
        }
        
        SpawnRoof();
    }

    private void SpawnFloor()
    {
        Instantiate(floor, spawnPoint.position, transform.rotation, transform);
        spawnPoint.localPosition += Vector3.up * floorHeight;
    }

    private void SpawnRoof()
    {
        Instantiate(roof, spawnPoint.position, transform.rotation, transform);
    }
}