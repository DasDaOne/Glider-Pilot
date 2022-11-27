using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;
using TMPro;
using UnityEngine;
using Utilities;
using Random = UnityEngine.Random;

public class DistanceCounter : Singleton<DistanceCounter>
{
    private const string PersonalRecordKey = "PersonalRecord";

    [Header("Mall")] 
    [SerializeField] private float minDistanceToSpawnMall;
    [SerializeField] private float maxDistanceToSpawnMall;
    [Header("UI")] 
    [SerializeField] private TextMeshProUGUI distanceText;
    [SerializeField] private TextMeshProUGUI recordText;
    [SerializeField, Min(0.0001f)] private float distanceDivider;

    private float distance;
    private float distanceToSpawnMall;

    private bool needToSpawnMall;

    public bool NeedToSpawnMall => needToSpawnMall;

    private Action onSpawnMall;
    public Action OnSpawnMall => onSpawnMall;

    private void Start()
    {
        recordText.text = $"PB: {ConvertDistance(PlayerPrefs.GetInt(PersonalRecordKey, 0))}";
        onSpawnMall += SetNewDistanceToSpawnMall;
        SetNewDistanceToSpawnMall();
    }

    private void FixedUpdate()
    {
        distance += TerrainManager.Instance.CurrentSpeed * Time.fixedDeltaTime / distanceDivider;

        distanceText.text = ConvertDistance(distance);

        if (distance > distanceToSpawnMall)
            needToSpawnMall = true;
    }

    public void SaveRecord()
    {
        if ((int) distance > PlayerPrefs.GetInt(PersonalRecordKey, 0))
        {
            PlayerPrefs.SetInt(PersonalRecordKey, (int)distance);
        }
    }

    private string ConvertDistance(float dist)
    {
        if (distance < 1000)
            return $"{(int)dist}m";
        
        return $"{Math.Round(dist / 1000, 1)}km";
    }

    private void SetNewDistanceToSpawnMall()
    {
        distanceToSpawnMall = distance + Random.Range(minDistanceToSpawnMall, maxDistanceToSpawnMall);
        needToSpawnMall = false;
    }
}
