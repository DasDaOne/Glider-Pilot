using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RoadInitializer : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private GameObject roadSpawnerPrefab;
    [SerializeField] private GameObject streetLightPrefab;
    [SerializeField] private GameObject carPrefab;
    [Header("SpawnPoints")]
    [SerializeField] private Transform roadSpawnPoint;
    [SerializeField] private Transform[] streetLightsSpawnPoints;
    [SerializeField] private Transform leftCarSpawnPoint;
    [SerializeField] private Transform rightCarSpawnPoint;
    [Header("Values")]
    [SerializeField, Range(0, 100)] private float chanceToSpawnStreetLight;
    [SerializeField, Range(0, 100)] private float chanceToSpawnCar;

    private bool canSpawnFrontwardsCar = true;
    
    private void Awake()
    {
        Instantiate(roadSpawnerPrefab, roadSpawnPoint.position, transform.rotation, transform);

        if (Random.Range(0, 100) < chanceToSpawnStreetLight)
        {
            Transform spawnPoint = streetLightsSpawnPoints[Random.Range(0, streetLightsSpawnPoints.Length)];
            Instantiate(streetLightPrefab, spawnPoint.position, spawnPoint.rotation, transform);
        }

        if (Random.Range(0, 100) < chanceToSpawnCar && !TerrainManager.Instance.backwardsCarWasSpawned)
        {
            Instantiate(carPrefab, leftCarSpawnPoint.position, leftCarSpawnPoint.rotation, transform.parent);
        }
        else if (TerrainManager.Instance.backwardsCarWasSpawned)
            TerrainManager.Instance.backwardsCarWasSpawned = false;
    }

    private void Update()
    {
        if(transform.position.z < 0 && canSpawnFrontwardsCar)
        {
            if(Random.Range(0, 100) < chanceToSpawnCar && !TerrainManager.Instance.frontwardsCarWasSpawned && TerrainManager.Instance.amountOfFrontwardsCars < 3)
            {
                Instantiate(carPrefab, rightCarSpawnPoint.position, rightCarSpawnPoint.rotation, transform.parent);
                TerrainManager.Instance.frontwardsCarWasSpawned = true;
                TerrainManager.Instance.amountOfFrontwardsCars++;
            }
            else if (TerrainManager.Instance.frontwardsCarWasSpawned && TerrainManager.Instance.amountOfFrontwardsCars < 3)
                TerrainManager.Instance.frontwardsCarWasSpawned = false;

            canSpawnFrontwardsCar = false;
        }
    }
}
