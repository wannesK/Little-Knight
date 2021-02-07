using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndTrigger : MonoBehaviour
{
    public GameObject completeLevelUI;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            LevelComplete();
            //GameObject.Find("Character").GetComponent<CharacterMovement>().enabled = false;
        }
    }
    public void LevelComplete()
    {
        completeLevelUI.SetActive(true);
    }
}
