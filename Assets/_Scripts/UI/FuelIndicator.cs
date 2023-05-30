using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelIndicator : MonoBehaviour
{
    [SerializeField] private Image indicator;
    [SerializeField] private GameObject background;
    [SerializeField] private PlayerMovement playerMovement;

    private void Update()
    {
        background.SetActive(playerMovement.CurrentFuel < playerMovement.MaxFuel);

        indicator.fillAmount = playerMovement.CurrentFuel / playerMovement.MaxFuel;
    }
}
