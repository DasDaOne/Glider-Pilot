using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffSpin : MonoBehaviour
{
    private void Update()
    {
        transform.RotateAround(transform.position, Vector3.up, 75 * Time.deltaTime);
    }
}
