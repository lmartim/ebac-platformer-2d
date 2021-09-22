using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Core.Singleton;

public class UIManager : Singleton<UIManager>
{

    public TextMeshProUGUI coinsText;

    public static void UpdateTextCoins(string s)
    {
        Instance.coinsText.text = "x " + s;
    }
}
