using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Utilities;

public class CoinManager : Singleton<CoinManager>
{
    private const string MoneyPrefsKey = "Money";
    
    [SerializeField] private TextMeshProUGUI moneyCounter;
    
    private int money;

    public int Money => money;

    private void Start()
    {
        GetPlayerPrefs();
        UpdateMoneyCounter();
    }

    public void AddMoney(int amount)
    {
        money += amount;
        UpdatePlayerPrefs();
        UpdateMoneyCounter();
    }

    public void RemoveMoney(int amount)
    {
        money -= amount;
        UpdatePlayerPrefs();
        UpdateMoneyCounter();
    }

    private void GetPlayerPrefs()
    {
        money = PlayerPrefs.GetInt(MoneyPrefsKey, 0);
    }

    private void UpdatePlayerPrefs()
    {
        PlayerPrefs.SetInt(MoneyPrefsKey, money);
    }

    private void UpdateMoneyCounter()
    {
        moneyCounter.text =  money.ToString();
    }
}
