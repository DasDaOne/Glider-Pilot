using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SliderChanger : MonoBehaviour
{
    [SerializeField] private GameObject background;
    
    private Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }
    
    public void OnPointerSliderDown()
    {
        background.SetActive(true);
    }

    public void OnPointerSliderUp()
    {
        slider.value = 0;
        background.SetActive(false);
    }
}