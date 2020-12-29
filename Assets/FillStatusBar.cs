using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillStatusBar : MonoBehaviour
{    
    public CharacterHealt playerHealt;
    public Image fillImage;

    private Slider slider;
    private void Awake()
    {
        slider = GetComponent<Slider>();
    }
   
    void Update()
    {
        if (slider.value <= slider.minValue)
        {
            fillImage.enabled = false;
        }
        float fillValue = playerHealt.playerCurrentHealt / playerHealt.playerMaxHealt;
        slider.value = fillValue;
    }
}
