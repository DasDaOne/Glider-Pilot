using UnityEngine;
using Random = UnityEngine.Random;

public class RoadSpawner : MonoBehaviour
{
    [Header("Road")]
    [SerializeField] private GameObject roadPrefab;
    [SerializeField] private float rangeToSpawnRoad;
    [Header("Mall")]
    [SerializeField] private GameObject mallPrefab;

    private void LateUpdate()
    {
        if (transform.position.z < rangeToSpawnRoad)
        {
            if(DistanceCounter.Instance.NeedToSpawnMall)
                SpawnMall();
            else
                SpawnRoad();
        }
    }

    private void SpawnRoad()
    {
        Instantiate(roadPrefab, transform.position, transform.rotation, transform.parent.parent);
        Destroy(this);
    }

    private void SpawnMall()
    {
        Instantiate(mallPrefab, transform.position, transform.rotation, transform.parent.parent);
        DistanceCounter.Instance.OnSpawnMall?.Invoke();
        Destroy(this);
    }
}
