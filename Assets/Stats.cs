using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    private ScoreManager scoreManager;

    public TextMeshProUGUI attackDamageText;
    public TextMeshProUGUI healtText;
    public Button damageUpgradeButton;
    public Button healtUpgradeButton;
    
    void Start()
    {
        scoreManager = GameObject.FindGameObjectWithTag("Data").GetComponent<ScoreManager>();
        CheckForAttackLimit();
        CheckForHealtLimit();
    }
    
    void Update()
    {
        attackDamageText.text = "Attack Dagame : " + scoreManager.data.dataAttackDamage + " - " + scoreManager.data.dataStrikeDamage; ;
        healtText.text = "Healt : " + scoreManager.data.playerMaxHealt;       
    }

    public void CheckForAttackLimit()
    {
        if (scoreManager.data.dataAttackDamage >= 100)
        {
            damageUpgradeButton.interactable = false;
            Debug.Log("Max Attack Reached");
        }
    }
    public void CheckForHealtLimit()
    {
        if (scoreManager.data.playerMaxHealt >= 220)
        {
            healtUpgradeButton.interactable = false;
            Debug.Log("Max Healt Reached");
        }
    }
}
