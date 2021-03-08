using UnityEngine;

public class SlowMotion : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 1.0f;
    }
    public void SlowTheTime()
    {

        if (Time.timeScale == 1.0f)
        {
            Time.timeScale = 0.3f;
        }
        else
        {
            Time.timeScale = 1.0f;
        }            
    }
}
