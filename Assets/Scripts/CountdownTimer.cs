using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{   
    private float currentTime = 0f;
    private float startingTime = 3f;
    private bool count;

    public TextMeshProUGUI countDownText;
    public Button strikeButton;

    private void Update()
    {
        if (count)
        {
            strikeButton.interactable = false; 
            currentTime -= 1f * Time.deltaTime;
            countDownText.text = currentTime.ToString("0");
            if (currentTime <= 0)
            {
                currentTime = 0;
                countDownText.gameObject.SetActive(false);
                strikeButton.interactable = true;               
            }
        }
    }
    public void CountDown()
    {
        count = true;
        currentTime = startingTime;
        countDownText.gameObject.SetActive(true);        
    }
}
