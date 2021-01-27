using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndTrigger : MonoBehaviour
{
    public GameObject completeLevelUI;

    private void Start()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            completeLevelUI.SetActive(true);
            //GameObject.Find("Character").GetComponent<CharacterMovement>().enabled = false;
        }
    }
}
