using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class DeathScreen : MonoBehaviour
{
    [SerializeField] private GameObject deathScreenPanel;
    [SerializeField] private float delay;

    public void ShowDeathScreen()
    {
        StartCoroutine(TimeUtilities.Timer(delay, () =>
        {
            deathScreenPanel.gameObject.SetActive(true);
        }));
    }
}
