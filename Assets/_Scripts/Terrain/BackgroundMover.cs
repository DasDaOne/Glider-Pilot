using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMover : MonoBehaviour
{
    [SerializeField] private Transform target;
    
    private void Update()
    {
        Vector3 pos = transform.position;
        pos.x = target.position.x;
        transform.position = pos;
    }
}
