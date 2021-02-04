using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI coinText;
    int coin;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void ChanceCoin(int coinValue)
    {
        coin += coinValue;
        coinText.text = coin.ToString();
    }
}
