using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [Header("Forces")]
    [SerializeField] private float collisionForce;
 
    [Header("Components")]
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private GliderEngine gliderEngine;
    [SerializeField] private GliderAnimation gliderAnimation;
    [SerializeField] private Rigidbody rb;

    private bool isFalling;
    
    private void OnCollisionEnter(Collision other)
    {
        switch (other.collider.tag)
        {
            case "Obstacle":
                if(isFalling) return;
                
                playerMovement.CanMove = false;
                gliderAnimation.Animate = false;
                TerrainSpeedManager.Instance.StopMovement();
        
                rb.constraints = RigidbodyConstraints.None;
                rb.AddForce(Vector3.forward * collisionForce, ForceMode.VelocityChange);
                
                isFalling = true;
                
                break;
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "FuelBuff":
                gliderEngine.AddFuel();
                Destroy(other.gameObject);
                break;
        }
    }
}
