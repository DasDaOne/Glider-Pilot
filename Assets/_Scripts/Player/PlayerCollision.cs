using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [Header("Forces")]
    [SerializeField] private float collisionForce;
    [SerializeField] private float movingObstacleCollisionForce;
 
    [Header("Components")]
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private GliderEngine gliderEngine;
    [SerializeField] private GliderAnimation gliderAnimation;
    [SerializeField] private Rigidbody rb;

    private bool isFalling;

    private void Death()
    {
        playerMovement.CanMove = false;
        gliderAnimation.Animate = false;
        EventManager.Instance.deathEvent.Invoke();
                
        rb.constraints = RigidbodyConstraints.None;
        
        isFalling = true;
    }

    private void OnCollisionEnter(Collision other)
    {
        switch (other.collider.tag)
        {
            case "Obstacle":
                if(isFalling) return;
                
                Death();
                
                rb.AddForce(Vector3.forward * collisionForce, ForceMode.Impulse);
                
                break;
            case "MovingObstacle":
                if(isFalling) return;
                
                Death();
                
                rb.AddForce(Vector3.forward * movingObstacleCollisionForce, ForceMode.Impulse);

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
            case "Coin":
                CoinManager.Instance.AddMoney(1);
                Destroy(other.gameObject);
                break;
        }
    }
}
