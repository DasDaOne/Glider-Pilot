using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GliderAnimation : MonoBehaviour
{
    [Header("Adjustment values")]
    [SerializeField] private float scaleMultiplier;
    [SerializeField] private float parachuteRotationMultiplier;
    [Header("Models")] 
    [SerializeField] private Transform parachute;
    [Header("Left Side")]
    [SerializeField] private Transform leftRope;
    [SerializeField] private Transform leftHandlePoint;
    [SerializeField] private Transform leftHandle;
    [Header("Right Side")]
    [SerializeField] private Transform rightRope;
    [SerializeField] private Transform rightHandlePoint;
    [SerializeField] private Transform rightHandle;
    [Header("Other")] 
    [SerializeField] private PlayerMovement playerMovement;

    private Quaternion parachuteDefaultRotation;
    
    private void Start()
    {
        parachuteDefaultRotation = parachute.rotation;
    }

    private void Update()
    {
        Vector3 leftRopeScale = new Vector3(1, 1, 1 + playerMovement.LeftHandleInput * scaleMultiplier);
        Vector3 rightRopeScale = new Vector3(1, 1, 1 + playerMovement.RightHandleInput * scaleMultiplier);

        leftRope.localScale = leftRopeScale;
        rightRope.localScale = rightRopeScale;

        leftHandle.position = leftHandlePoint.position;
        rightHandle.position = rightHandlePoint.position;

        parachute.rotation = parachuteDefaultRotation;
        parachute.Rotate(0, -playerMovement.MovementInputs.x * parachuteRotationMultiplier, 0);
    }
}
