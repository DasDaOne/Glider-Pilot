using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField] private Slider leftSlider;
    [SerializeField] private Slider rightSlider;

    private Quaternion parachuteDefaultRotation;

    private bool animate = true;

    public bool Animate { set => animate = value;}

    private void Start()
    {
        parachuteDefaultRotation = parachute.rotation;
    }

    private void Update()
    {
        if(!animate)
            return;
        Vector3 leftRopeScale = new Vector3(1, 1, 1 + leftSlider.value * scaleMultiplier);
        Vector3 rightRopeScale = new Vector3(1, 1, 1 + rightSlider.value * scaleMultiplier);

        leftRope.localScale = leftRopeScale;
        rightRope.localScale = rightRopeScale;

        leftHandle.position = leftHandlePoint.position;
        rightHandle.position = rightHandlePoint.position;

        parachute.rotation = parachuteDefaultRotation;
        parachute.Rotate(0, -playerMovement.MovementInputs.x * parachuteRotationMultiplier, 0);
    }
}
