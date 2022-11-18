using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RoadInitializer : MonoBehaviour
{
    [SerializeField] private GameObject roadSpawner;
    [SerializeField] private Transform roadSpawnPoint;
    [SerializeField] private Transform[] streetLightsSpawnPoints;
    [SerializeField] private GameObject streetLightPrefab;
    [SerializeField, Range(0, 100)] private float chanceToSpawnStreetLight;
    
    private void Awake()
    {
        Instantiate(roadSpawner, roadSpawnPoint.position, transform.rotation, transform);
        if (Random.Range(0, 100) < chanceToSpawnStreetLight)
        {
            Transform spawnPoint = streetLightsSpawnPoints[Random.Range(0, streetLightsSpawnPoints.Length)];
            Instantiate(streetLightPrefab, spawnPoint.position, spawnPoint.rotation, transform);
        }
    }
}
