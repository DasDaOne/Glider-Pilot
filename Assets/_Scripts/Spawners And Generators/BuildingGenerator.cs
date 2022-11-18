using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BuildingGenerator : MonoBehaviour
{
    [SerializeField] private GameObject floor;
    [SerializeField] private GameObject balcony;
    [SerializeField] private GameObject roof;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private int minFloorAmount;
    [SerializeField] private int maxFloorAmount;
    [SerializeField] private float floorHeight = 7.7f;
    [SerializeField, Range(0, 100)] private float chanceOfSpawningBalcony;
    
    private void Start()
    {
        int floorAmount = Random.Range(minFloorAmount, maxFloorAmount);

        for (int i = 0; i < floorAmount; i++)
        {
            if (Random.Range(0, 100) < chanceOfSpawningBalcony)
            {
                SpawnBalcony();
            }
            else
            {
                SpawnFloor();   
            }
        }
        
        SpawnRoof();
    }

    private void SpawnFloor()
    {
        Instantiate(floor, spawnPoint.position, transform.rotation, transform);
        spawnPoint.localPosition += Vector3.up * floorHeight;
    }

    private void SpawnBalcony()
    {
        Instantiate(balcony, spawnPoint.position, transform.rotation, transform);
        spawnPoint.localPosition += Vector3.up * floorHeight;
    }

    private void SpawnRoof()
    {
        Instantiate(roof, spawnPoint.position, transform.rotation, transform);
    }
}