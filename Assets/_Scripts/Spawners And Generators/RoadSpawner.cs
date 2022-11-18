using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class RoadSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] roadPrefabs;
    [SerializeField] private float rangeToSpawnRoad;

    private void FixedUpdate()
    {
        if (transform.position.z < rangeToSpawnRoad)
        {
            SpawnRoad();
        }
    }

    private void SpawnRoad()
    {
        Instantiate(roadPrefabs[Random.Range(0, roadPrefabs.Length)], transform.position, transform.rotation, transform.parent.parent);
        Destroy(this);
    }
}
