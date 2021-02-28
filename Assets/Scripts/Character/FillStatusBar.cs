using UnityEngine;
using UnityEngine.UI;

public class FillStatusBar : MonoBehaviour
{    
    public CharacterHealt playerHealt;
    public Image fillImage;

    private Slider slider;
    private ScoreManager scoreManager;
    private void Awake()
    {
        slider = GetComponent<Slider>();
        scoreManager = GameObject.FindGameObjectWithTag("Data").GetComponent<ScoreManager>();
    }
   
    void Update()
    {
        if (slider.value <= slider.minValue)
        {
            fillImage.enabled = false;
        }
        float fillValue = playerHealt.playerCurrentHealt / scoreManager.data.playerMaxHealt;
        slider.value = fillValue;
    }
}
