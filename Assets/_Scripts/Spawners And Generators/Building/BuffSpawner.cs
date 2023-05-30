using UnityEngine;
using Random = UnityEngine.Random;

public class BuffSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] buffPrefabs;
    [SerializeField, Range(0, 100)] private float chanceToSpawnBuff;

    private void Start()
    {
        if (Random.Range(0, 100) < chanceToSpawnBuff)
        {
            GameObject buffPrefab = buffPrefabs[Random.Range(0, buffPrefabs.Length)];
            Instantiate(buffPrefab, transform.position, buffPrefab.transform.rotation, transform.parent);
        }
        Destroy(this);
    }
}
