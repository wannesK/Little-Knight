using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHPBarTrigger : MonoBehaviour
{
    public GameObject bossHPBar;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            bossHPBar.SetActive(true);
        }
    }
}
