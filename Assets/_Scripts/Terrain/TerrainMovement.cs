using UnityEngine;

public class TerrainMovement : MonoBehaviour
{
    [SerializeField] private bool isCar;
    
    private void FixedUpdate()
    {
        if(TerrainManager.Instance.CurrentSpeed == 0)
            return;
        
        if(transform.forward == Vector3.back && isCar)
            transform.position += Vector3.back * ((TerrainManager.Instance.CurrentSpeed + TerrainManager.Instance.CarSpeed) * Time.fixedDeltaTime);
        else if (isCar)
            transform.position += Vector3.forward * ((TerrainManager.Instance.CarSpeed - TerrainManager.Instance.CurrentSpeed) * Time.fixedDeltaTime);
        else
            transform.position += Vector3.back * (TerrainManager.Instance.CurrentSpeed * Time.fixedDeltaTime);
    }

    private void Update()
    {
        if(transform.position.z < TerrainManager.Instance.ZMinimumToDestroy)
            Destroy(gameObject);
        else if (transform.position.z > TerrainManager.Instance.ZMaximumToDestroy)
        {
            Destroy(gameObject);
            TerrainManager.Instance.amountOfFrontwardsCars--;
        }
    }
}
