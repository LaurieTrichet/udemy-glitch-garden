using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarDisplay : MonoBehaviour
{

    [SerializeField] int currentResources = 0;

    [SerializeField] TMPro.TMP_Text startCountText = null;


    public int CurrentResources { get => currentResources; set => currentResources = value; }

    void Start()
    {
        UpdateUI();  
    }

    public void Substract(int cost)
    {
        var newAmount = currentResources - cost;
        currentResources = Math.Max(0, newAmount);
        UpdateUI();
    }

    public void Add(int gain)
    {
        currentResources += gain;
        UpdateUI();
    }

    private void UpdateUI()
    {
        startCountText.text = currentResources.ToString();
    }

    public bool CanPurchase(int cost)
    {
        return CurrentResources >= cost;
    }

    public void MakePurchase(int cost)
    {
        Substract(cost);
    }
}
