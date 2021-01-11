using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealt : MonoBehaviour
{
    public int healt;
    public GameObject hitEffect;
    
    private Shake shake; // Camera Shake
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
    }
    public void EnemyTakeDamage(int damage)
    {  // Enemy taking damage             
        healt -= damage;       
        shake.CamShake();
        GameObject effectClone = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effectClone, 1f);
        animator.SetTrigger("enemyHurt");
        Debug.Log("Enemy Take Damage !!  : " + damage);

        if (healt <= 0 && gameObject.CompareTag("Enemy"))
        {   // Enemys DEAD  
            animator.SetTrigger("enemyDead");
            GetComponent<EnemyAI>().enabled = false;              
            Destroy(this.gameObject, 1f);
            Debug.Log("ENEMY Dead !!");
        }
        if (healt <= 0 && gameObject.CompareTag("EnemyRunner"))
        {   // Runner DEAD
            animator.SetTrigger("enemyDead");
            GetComponent<EnnemyFollow>().enabled = false;
            transform.GetChild(0).gameObject.SetActive(false);
            Destroy(this.gameObject, 1f);
            Debug.Log("ENEMY Dead !!");
        }

    }
}
