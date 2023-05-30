using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FloorGenerator : MonoBehaviour
{
    [Header("SpawnPoints")] 
    [SerializeField] private Transform[] wallSpawnPoints;
    [SerializeField] private Transform[] signSpawnPoints;
    
    [Header("Prefabs")]
    [SerializeField] private GameObject window;
    [SerializeField] private GameObject balcony;
    [SerializeField] private GameObject sign;
    
    [Header("Chances")]
    [SerializeField, Range(0, 100)] private float chanceToSpawnBalcony;
    [SerializeField, Range(0, 100)] private float chanceToSpawnSign;

    private void Start()
    {
        foreach (Transform spawnPoint in wallSpawnPoints)
        {
            if (Random.Range(0, 100) < chanceToSpawnBalcony)
            {
                SpawnBalcony(spawnPoint);
            }
            else
            {
                SpawnWindow(spawnPoint);
            }
        }

        foreach (Transform spawnPoint in wallSpawnPoints)
        {
            Destroy(spawnPoint.gameObject);
        }

        foreach (Transform spawnPoint in signSpawnPoints)
        {
            if (Random.Range(0, 100) < chanceToSpawnSign)
            {
                SpawnSign(spawnPoint);
            }
        }
        
        foreach (Transform spawnPoint in signSpawnPoints)
        {
            Destroy(spawnPoint.gameObject);
        }
        
        Destroy(this);
    }

    private void SpawnBalcony(Transform spawnPoint)
    {
        Instantiate(balcony, spawnPoint.position, spawnPoint.rotation, transform);
    }

    private void SpawnWindow(Transform spawnPoint)
    {
        Instantiate(window, spawnPoint.position, spawnPoint.rotation, transform);
    }

    private void SpawnSign(Transform spawnPoint)
    {
        Instantiate(sign, spawnPoint.position, spawnPoint.rotation, transform);
    }
}
