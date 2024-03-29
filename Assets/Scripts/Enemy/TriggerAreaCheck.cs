﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAreaCheck : MonoBehaviour
{
    private EnemyAI enemyParent;
    
    private void Awake()
    {
        enemyParent = GetComponentInParent<EnemyAI>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            enemyParent.target = collider.transform;
            enemyParent.inRange = true;
            enemyParent.followZone.SetActive(true);
        }
    }
}
