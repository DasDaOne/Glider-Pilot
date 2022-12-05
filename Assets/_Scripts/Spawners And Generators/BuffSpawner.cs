using UnityEngine;
using Random = UnityEngine.Random;

public class BuffSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] buffPrefabs;
    [SerializeField, Range(0, 100)] private float chanceToSpawnBuff;

    private void Start()
    {
        if (Random.Range(0, 100) < chanceToSpawnBuff)
            Instantiate(buffPrefabs[Random.Range(0, buffPrefabs.Length)], transform.position, Quaternion.identity, transform.parent);
        Destroy(this);
    }
}
