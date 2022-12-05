using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FPSCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private float _hudRefreshRate = 1f;
 
    private float _timer;

    private void Start()
    {
        Application.targetFrameRate = 30;
    }

    private void Update()
    {
        if (Time.unscaledTime > _timer)
        {
            int fps = (int)(1f / Time.unscaledDeltaTime);
            text.text = fps.ToString();
            _timer = Time.unscaledTime + _hudRefreshRate;
        }
    }
}
