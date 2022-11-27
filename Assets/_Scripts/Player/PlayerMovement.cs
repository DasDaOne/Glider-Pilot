using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [Header("Sliders")] 
    [SerializeField] private Slider leftSlider;
    [SerializeField] private Slider rightSlider;
    
    [Header("Values")]
    [SerializeField] private float forwardAcceleration;
    [SerializeField] private float sidewaysInputAcceleration;
    [SerializeField] private float counterForce;
    
    [Header("Other")]
    [SerializeField] private Rigidbody rb;
    
    private bool canMove = true;
    
    private Vector3 movementInputs;
    public Vector3 MovementInputs => movementInputs;
    public bool CanMove { set => canMove = value; }

    private void Update()
    {
        if(!canMove)
            return;
        GetInputs();
        // GetKeyboardInputs();
    }

    private void GetKeyboardInputs()
    {
        float leftRopeInput = 0;
        float rightRopeInput = 0;
        if (Input.GetKey(KeyCode.W))
            leftRopeInput = 1;
        else if (Input.GetKey(KeyCode.S))
            leftRopeInput = -1;
        
        if (Input.GetKey(KeyCode.I))
            rightRopeInput = 1;
        else if (Input.GetKey(KeyCode.K))
            rightRopeInput = -1;
        
        ApplyInputs(leftRopeInput, rightRopeInput);
    }

    private void GetInputs()
    {
        ApplyInputs(leftSlider.value, rightSlider.value);
    }

    private void ApplyInputs(float left, float right)
    {
        movementInputs.x = right - left;
        movementInputs.z = (left + right) / 2;
    }

    private void FixedUpdate()
    {
        if(!canMove)
            return;
        ApplyMovementForces();
    }

    private void ApplyMovementForces()
    {
        TerrainManager.Instance.Accelerate(movementInputs.z * forwardAcceleration);
        rb.AddForce(Vector3.right * (movementInputs.x * sidewaysInputAcceleration), ForceMode.Acceleration);
        rb.AddForce(Vector3.up * counterForce, ForceMode.Acceleration);
    }

    public void AddUpwardsAcceleration(float force)
    {
        rb.AddForce(Vector3.up * force, ForceMode.Acceleration);
    }
}
