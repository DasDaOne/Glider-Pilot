using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class BuildingSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] buildingBasePrefab;

    private void Start()
    {
        Instantiate(buildingBasePrefab[Random.Range(0, buildingBasePrefab.Length)], transform.position, transform.rotation, transform.parent);
        Destroy(gameObject);
    }
}
