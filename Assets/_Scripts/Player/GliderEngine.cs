using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GliderEngine : MonoBehaviour
{
    [Header("Fuel Values")]
    [SerializeField] private float maxFuel;
    [SerializeField] private float fuelConsumption;
    [SerializeField] private float passiveFuelIncome;
    
    [Header("Main Values")]
    [SerializeField] private float accelerationForce;

    [Header("Components")]
    [SerializeField] private Image fuelImage;
    [SerializeField] private RectTransform buttonTransform;
    [SerializeField] private PlayerMovement playerMovement;
    
    [Header("AnimationValues")]
    [SerializeField] private Vector3 buttonAnimationScales;
    
    private Vector3 buttonDefaultScale;
    
    private float currentFuel;
    private bool isAccelerating;

    private void Start()
    {
        currentFuel = maxFuel;
        buttonDefaultScale = buttonTransform.localScale;
    }

    private void Update()
    {
        fuelImage.fillAmount = currentFuel / maxFuel;
    }

    private void FixedUpdate()
    {
        if (isAccelerating)
        {
            Accelerate();
        }
        else
        {
            currentFuel = Mathf.Clamp(currentFuel + passiveFuelIncome * Time.fixedDeltaTime, 0, maxFuel);
        }
    }

    public void StartAcceleration()
    {
        isAccelerating = true;
        buttonTransform.localScale = buttonAnimationScales;
    }

    public void StopAcceleration()
    {
        isAccelerating = false;
        buttonTransform.localScale = buttonDefaultScale;
    }

    private void Accelerate()
    {
        if(currentFuel - fuelConsumption * Time.fixedDeltaTime > 0)
        {
            playerMovement.AddUpwardsAcceleration(accelerationForce);
            currentFuel -= fuelConsumption * Time.fixedDeltaTime;
        }
    }

    public void AddFuel()
    {
        currentFuel = Mathf.Clamp(currentFuel + 25, 0, maxFuel);
    }
}
