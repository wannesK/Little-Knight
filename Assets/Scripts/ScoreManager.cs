using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;
using UnityEngine.Networking;

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
        Debug.Log(filePath);
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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            DeleteData();
            Debug.Log("Datas Deleted");
        }
    }
    public void SaveData()
    {
        FileStream fileStream = new FileStream(filePath, FileMode.Create);
        binaryFormatter.Serialize(fileStream, data);
        fileStream.Close();
        Debug.Log("Data Saved");
    }

    public void LoadData()
    {
        if (File.Exists(filePath))
        {
            FileStream fileStream = new FileStream(filePath, FileMode.Open);
            data = (GameData)binaryFormatter.Deserialize(fileStream);
            coinText.text = " " + data.coin;
            fileStream.Close();
            Debug.Log("Data loaded");
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
    public void DeleteData()
    {
        FileStream fileStream = new FileStream(filePath, FileMode.Create);
        data.coin = 0;
        data.dataAttackDamage = 40;
        data.dataStrikeDamage = 60;
        data.playerMaxHealt = 100;
        coinText.text = "0";
        binaryFormatter.Serialize(fileStream, data);
        fileStream.Close();
    }

    public void CoinCounter()
    {
        data.coin += Random.Range(3, 7);
        coinText.text = data.coin.ToString();
    }

    public void PlayerDamageUpgrade()
    {
        if (data.coin >= 200)
        {
            data.dataAttackDamage += 10;
            data.dataStrikeDamage += 10;

            data.coin -= 200;
            coinText.text = data.coin.ToString();
        }
        else
        {
            Debug.Log("Not enough money");
        }
    }
    public void PlayerHealtUpgrade()
    {
        if (data.coin >= 200)
        {
            data.playerMaxHealt += 20;
            data.coin -= 200;
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
}

