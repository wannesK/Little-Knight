using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelScript : MonoBehaviour
{
    private GameMaster gm;
    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.End))
        {
            ResetLevels();
        }
    }
    public void PassLevel()
    {
        int currentlevel = SceneManager.GetActiveScene().buildIndex;

        if (currentlevel >= PlayerPrefs.GetInt("levelUnlocked"))
        {
            PlayerPrefs.SetInt("levelUnlocked",currentlevel);
        }
        Debug.Log("LEVEL" + PlayerPrefs.GetInt("levelUnlocked") + "UNLOCKED");
        LoadLevelSelect();
    }

    public void ResetLevels()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("Levels Reseted");
    }
    public void LoadLevelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
        gm.lastCheckPointPos = new Vector2(-3, 0);
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
        gm.lastCheckPointPos = new Vector2(-3, 0);
    }
    public void LoadPlayerStats()
    {
        SceneManager.LoadScene("PlayerStats");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
