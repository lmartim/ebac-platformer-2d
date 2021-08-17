using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Singleton;
using TMPro;

public class ItemManager : Singleton<ItemManager>
{
    public int coins;
    public TextMeshProUGUI coinsText;

    private void Start()
    {
        Reset();
    }

    private void Reset()
    {
        coins = 0;
        UpdateCoinsText();
    }

    public void AddCoins(int amount = 1)
    {
        coins += amount;
        UpdateCoinsText();
    }

    private void UpdateCoinsText()
    {
        coinsText.text = "x " + coins.ToString();
    }
}
