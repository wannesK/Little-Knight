using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    private ScoreManager scoreManager;

    public TextMeshProUGUI attackDamageText;
    public TextMeshProUGUI healtText;
    public TextMeshProUGUI reachedMaxDamageText;
    public TextMeshProUGUI reachedMaxHealtText;
    public TextMeshProUGUI attackUpgradeValueText;
    public TextMeshProUGUI healtUpgradeValueText;

    public Button damageUpgradeButton;
    public Button healtUpgradeButton;
    
    void Start()
    {
        scoreManager = GameObject.FindGameObjectWithTag("Data").GetComponent<ScoreManager>();
        CheckForAttackLimit();
        CheckForHealtLimit();
    }

    public void CheckForAttackLimit()
    {
        if (scoreManager.data.dataAttackDamage == 50)
        {
            attackUpgradeValueText.text = "250";     
        }
        else if (scoreManager.data.dataAttackDamage == 60)
        {
            attackUpgradeValueText.text = "300";
        }
        else if (scoreManager.data.dataAttackDamage == 70)
        {
            attackUpgradeValueText.text = "350";
        }
        else if (scoreManager.data.dataAttackDamage == 80)
        {
            attackUpgradeValueText.text = "400";
        }
        else if (scoreManager.data.dataAttackDamage == 90)
        {
            attackUpgradeValueText.text = "450";
        }
        else if (scoreManager.data.dataAttackDamage >= 100)
        {
            damageUpgradeButton.interactable = false;
            reachedMaxDamageText.gameObject.SetActive(true);
            attackUpgradeValueText.gameObject.SetActive(false);
        }

        attackDamageText.text = "Attack Dagame : " + scoreManager.data.dataAttackDamage + " - " + scoreManager.data.dataStrikeDamage;
    }
    public void CheckForHealtLimit()
    {
        
        if (scoreManager.data.playerMaxHealt == 120)
        {
            healtUpgradeValueText.text = "250";
        }
        else if (scoreManager.data.playerMaxHealt == 140)
        {
            healtUpgradeValueText.text = "300";
        }
        else if (scoreManager.data.playerMaxHealt == 160)
        {
            healtUpgradeValueText.text = "350";
        }
        else if (scoreManager.data.playerMaxHealt == 180)
        {
            healtUpgradeValueText.text = "400";
        }
        else if (scoreManager.data.playerMaxHealt == 200)
        {
            healtUpgradeValueText.text = "450";
        }
        else if (scoreManager.data.playerMaxHealt >= 220)
        {
            healtUpgradeButton.interactable = false;
            reachedMaxHealtText.gameObject.SetActive(true);
            healtUpgradeValueText.gameObject.SetActive(false);
        }

        healtText.text = "Healt : " + scoreManager.data.playerMaxHealt;
    }
}
