using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelManager : MonoBehaviour
{
    int levelUnlocked;
    public Button[] buttons;

    [Header("Loading screen settings")]
    public Slider loadingBar;
    public GameObject loadingScreen;
    public GameObject images;
    public TextMeshProUGUI progressText;
    private void Start()
    {
        levelUnlocked = PlayerPrefs.GetInt("levelUnlocked", 1);
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }
        for (int i = 0; i < levelUnlocked; i++)
        {
            buttons[i].interactable = true;
        }
    }
    public void LoadLevel(int levelIndex)
    {
        images.SetActive(false);
        loadingScreen.SetActive(true);

        StartCoroutine(startLoading(levelIndex));
    }
    IEnumerator startLoading(int levelIndex)
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(levelIndex);
        while (!async.isDone)
        {
            float progress = Mathf.Clamp01(async.progress / .9f);
            loadingBar.value = progress;
            progressText.text = "LOADING .. " + (progress * 100).ToString("0");

            yield return null;
        }
    }
}
