using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float inputSensitivity;
    [SerializeField] private Rigidbody rb;

    private PlayerInputs playerInputs;
    
    private float leftHandleInput;
    private float rightHandleInput;

    private Vector3 movementInputs;

    public float LeftHandleInput => leftHandleInput;
    public float RightHandleInput => rightHandleInput;
    public Vector3 MovementInputs => movementInputs;

    private void Awake()
    {
        playerInputs = new PlayerInputs();
    }

    private void Update()
    {
        GetInputs();
    }

    private void GetInputs()
    {
        leftHandleInput = Mathf.Lerp(leftHandleInput, playerInputs.Player.LeftHandle.ReadValue<float>(), Time.deltaTime * inputSensitivity);
        rightHandleInput = Mathf.Lerp(rightHandleInput, playerInputs.Player.RightHandle.ReadValue<float>(), Time.deltaTime * inputSensitivity);

        movementInputs.x = rightHandleInput - leftHandleInput;
        movementInputs.z = (rightHandleInput + leftHandleInput) / 2;
    }

    private void FixedUpdate()
    {
        ApplyMovementForces();
    }

    private void ApplyMovementForces()
    {
        rb.AddForce(movementInputs * movementSpeed, ForceMode.Acceleration);
    }

    private void OnEnable()
    {
        playerInputs.Enable();
    }

    private void OnDisable()
    {
        playerInputs.Disable();
    }
}
