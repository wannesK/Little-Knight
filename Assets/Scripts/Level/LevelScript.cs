using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelScript : MonoBehaviour
{
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
        SceneManager.LoadScene("LevelSelect");
    }

    public void ResetLevels()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("Levels Reseted");
    }
    public void LoadLevelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
