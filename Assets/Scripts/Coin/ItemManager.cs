using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Singleton;
using TMPro;

public class ItemManager : Singleton<ItemManager>
{
    public SOInt coins;
    public TextMeshProUGUI coinsText;

    private void Start()
    {
        Reset();
    }

    private void Reset()
    {
        coins.value = 0;
        UpdateCoinsText();
    }

    public void AddCoins(int amount = 1)
    {
        coins.value += amount;
        UpdateCoinsText();
    }

    private void UpdateCoinsText()
    {
        //coinsText.text = "x " + coins.ToString();
        //UIManager.UpdateTextCoins(coins.value.ToString());
    }
}
