using UnityEngine;

public class LevelEndTrigger : MonoBehaviour
{
    public GameObject completeLevelUI;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            LevelComplete();
        }
    }
    public void LevelComplete()
    {
        completeLevelUI.SetActive(true);
    }
}
