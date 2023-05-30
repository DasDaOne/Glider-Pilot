using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [Header("Sliders")] 
    [SerializeField] private Slider leftSlider;
    [SerializeField] private Slider rightSlider;
    
    [Header("Forces")]
    [SerializeField] private float forwardAcceleration;
    [SerializeField] private float engineAcceleration;
    [SerializeField] private float fastFallingAcceleration;
    [SerializeField] private float sidewaysInputAcceleration;
    [SerializeField] private float sidewaysMaxSpeed;
    [SerializeField] private float counterForce;
    
    [Header("Fuel Values")]
    [SerializeField] private float maxFuel;
    [SerializeField] private float fuelConsumption;
    [SerializeField] private float passiveFuelIncome;
    
    [Header("Other")]
    [SerializeField] private Rigidbody rb;
    
    private bool canMove = true;
    
    private Vector3 movementInputs;
    public Vector3 MovementInputs => movementInputs;

    private float currentFuel;

    public float CurrentFuel => currentFuel;
    public float MaxFuel => maxFuel;
    
    private void Start()
    {
        currentFuel = maxFuel;
    }
    
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
            leftRopeInput = -1;
        else if (Input.GetKey(KeyCode.S))
            leftRopeInput = 1;
        
        if (Input.GetKey(KeyCode.I))
            rightRopeInput = -1;
        else if (Input.GetKey(KeyCode.K))
            rightRopeInput = 1;
        
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
        EngineAcceleration();
        FastFalling();
    }

    private void ApplyMovementForces()
    {
        TerrainManager.Instance.Accelerate(movementInputs.z * forwardAcceleration);
        if(Mathf.Abs(rb.velocity.x) < sidewaysMaxSpeed)
            rb.AddForce(Vector3.right * (movementInputs.x * sidewaysInputAcceleration), ForceMode.Acceleration);
        rb.AddForce(Vector3.up * counterForce, ForceMode.Acceleration);
    }

    private void EngineAcceleration()
    {
        if (movementInputs.z > 0.9f && currentFuel - fuelConsumption * Time.fixedDeltaTime > 0)
        {
            rb.AddForce(Vector3.up * engineAcceleration, ForceMode.Acceleration);
            currentFuel -= fuelConsumption * Time.fixedDeltaTime;
        }
        else
        {
            currentFuel = Mathf.Clamp(currentFuel + passiveFuelIncome * Time.fixedDeltaTime, 0, maxFuel);
        }
    }

    private void FastFalling()
    {
        if (movementInputs.z < -0.9f)
        {
            rb.AddForce(Vector3.down * fastFallingAcceleration, ForceMode.Acceleration);
        }
    }

    public void AddFuel()
    {
        currentFuel = Mathf.Clamp(currentFuel + 25, 0, maxFuel);
    }

    public void Death()
    {
        canMove = false;
    }
}
