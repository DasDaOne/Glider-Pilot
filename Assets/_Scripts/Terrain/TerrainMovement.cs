using UnityEngine;

public class TerrainMovement : MonoBehaviour
{
    private void FixedUpdate()
    {
        transform.position -= Vector3.forward * (TerrainSpeedManager.Instance.CurrentSpeed * Time.fixedDeltaTime);
    }

    private void Update()
    {
        if(transform.position.z < -50)
            Destroy(gameObject);
    }
}
