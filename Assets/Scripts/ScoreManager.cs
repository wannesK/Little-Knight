using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;

public class ScoreManager : MonoBehaviour
{  
    public static ScoreManager instance;
    public TextMeshProUGUI coinText;
    public GameData data;

    private BinaryFormatter binaryFormatter;
    private string saveFile;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        binaryFormatter = new BinaryFormatter();
        saveFile = Application.persistentDataPath + "/game.data";
    }

    public void Start()
    {
        LoadGame();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            DeleteData();
            Debug.Log("Coins Deleted");
        }
    }

    public void CoinCounter()
    {
        data.coin += Random.Range(3,8);
        coinText.text = "" + data.coin;
    }

    public void SaveData()
    {
        FileStream fileStream = new FileStream(saveFile, FileMode.Create);
        binaryFormatter.Serialize(fileStream, data);
        fileStream.Close();
    }

    public void LoadData()
    {
        if (File.Exists(saveFile))
        {
            FileStream fileStream = new FileStream(saveFile, FileMode.Open);
            data = (GameData)binaryFormatter.Deserialize(fileStream);
            coinText.text = " " + data.coin;
            fileStream.Close();
        }

    }

    public void DeleteData()
    {
        FileStream fileStream = new FileStream(saveFile, FileMode.Create);
        data.coin = 0;
        coinText.text = "0";
        binaryFormatter.Serialize(fileStream, data);
        fileStream.Close();
    }

    private void OnEnable()
    {
        LoadData();
    }
    private void OnDisable()
    {
        SaveData();
    }

    public void LoadGame()
    {
        if (data.firstLoading)
        {
            data.coin = 0;
            data.firstLoading = false;
        }
    }
}
[System.Serializable] 
public class GameData
{
    public int coin;
    public bool firstLoading;
}

