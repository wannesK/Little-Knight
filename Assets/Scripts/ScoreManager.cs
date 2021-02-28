using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;

public class ScoreManager : MonoBehaviour
{  
    public static ScoreManager instance;
    public GameData data;
    private BinaryFormatter binaryFormatter;
    private string filePath;

    public TextMeshProUGUI coinText;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        binaryFormatter = new BinaryFormatter();
        filePath = Application.persistentDataPath + "/game.data";
    }

    public void Start()
    {
        if (data.dataAttackDamage < 39)
        {
            data.dataAttackDamage = 40;
            data.dataStrikeDamage = 60;
            data.playerMaxHealt = 100;
        }
    }
    public void SaveData()
    {
        FileStream fileStream = new FileStream(filePath, FileMode.Create);
        binaryFormatter.Serialize(fileStream, data);
        fileStream.Close();
    }

    public void LoadData()
    {
        if (File.Exists(filePath))
        {
            FileStream fileStream = new FileStream(filePath, FileMode.Open);
            data = (GameData)binaryFormatter.Deserialize(fileStream);
            coinText.text = " " + data.coin;
            fileStream.Close();
        }
        else
        {
            Debug.LogError("Save File Not Found " + filePath);          
        }
    }
    private void OnEnable()
    {
        DatabaseControl();
    }
  
    private void DatabaseControl()
    {
        if (!File.Exists(filePath))
        {
            #if UNITY_ANDROID
            string file = Path.Combine(Application.streamingAssetsPath, "game.data");
            WWW data = new WWW(file);
            while (!data.isDone)
            {

            }
            File.WriteAllBytes(filePath, data.bytes);
            LoadData();
            #endif
        }
        else
        {
            LoadData();
        }
    }
    private void OnDisable()
    {
        SaveData();
    }
    public void CoinCounter()
    {
        data.coin += Random.Range(2, 4);
        coinText.text = data.coin.ToString();
    }
    public void PlayerDamageUpgrade()
    {
        if (data.coin >= 200 && data.dataAttackDamage == 40)
        {
            data.dataAttackDamage += 10;
            data.dataStrikeDamage += 10;

            data.coin -= 200;
            coinText.text = data.coin.ToString();
        }
        else if (data.coin >= 250 && data.dataAttackDamage == 50)
        {
            data.dataAttackDamage += 10;
            data.dataStrikeDamage += 10;

            data.coin -= 250;
            coinText.text = data.coin.ToString();
        }
        else if (data.coin >= 300 && data.dataAttackDamage == 60)
        {
            data.dataAttackDamage += 10;
            data.dataStrikeDamage += 10;

            data.coin -= 300;
            coinText.text = data.coin.ToString();
        }
        else if (data.coin >= 350 && data.dataAttackDamage == 70)
        {
            data.dataAttackDamage += 10;
            data.dataStrikeDamage += 10;

            data.coin -= 350;
            coinText.text = data.coin.ToString();
        }
        else if (data.coin >= 400 && data.dataAttackDamage == 80)
        {
            data.dataAttackDamage += 10;
            data.dataStrikeDamage += 10;

            data.coin -= 400;
            coinText.text = data.coin.ToString();
        }
        else if (data.coin >= 450 && data.dataAttackDamage == 90)
        {
            data.dataAttackDamage += 10;
            data.dataStrikeDamage += 10;

            data.coin -= 450;
            coinText.text = data.coin.ToString();
        }          
        else
        {
            Debug.Log("Not enough money");
        }
    }
    public void PlayerHealtUpgrade()
    {
        if (data.coin >= 200 && data.playerMaxHealt == 100)
        {
            data.playerMaxHealt += 20;
            data.coin -= 200;
            coinText.text = data.coin.ToString();
        }
        else if (data.coin >= 250 && data.playerMaxHealt == 120)
        {
            data.playerMaxHealt += 20;
            data.coin -= 250;
            coinText.text = data.coin.ToString();
        }
        else if (data.coin >= 300 && data.playerMaxHealt == 140)
        {
            data.playerMaxHealt += 20;
            data.coin -= 300;
            coinText.text = data.coin.ToString();
        }
        else if (data.coin >= 350 && data.playerMaxHealt == 160)
        {
            data.playerMaxHealt += 20;
            data.coin -= 350;
            coinText.text = data.coin.ToString();
        }
        else if (data.coin >= 400 && data.playerMaxHealt == 180)
        {
            data.playerMaxHealt += 20;
            data.coin -= 400;
            coinText.text = data.coin.ToString();
        }
        else if (data.coin >= 450 && data.playerMaxHealt == 200)
        {
            data.playerMaxHealt += 20;
            data.coin -= 400;
            coinText.text = data.coin.ToString();
        }
        else
        {
            Debug.Log("Not enough money");
        }
    }
}
[System.Serializable] 
public class GameData
{
    public int coin;
    public int dataAttackDamage;
    public int dataStrikeDamage;
    public int playerMaxHealt;
    public bool inGameMusicOff;
}

