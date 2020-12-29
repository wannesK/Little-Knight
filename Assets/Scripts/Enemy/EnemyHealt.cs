using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealt : MonoBehaviour
{
    public int healt;
    
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
        //animator.SetTrigger("guardHurt");
        shake.CamShake();
        Debug.Log("Enemy Take Damage !!  : " + damage);

        if (healt <= 0)
        {     // Enemy dead  
            GetComponent<EnemyAI>().enabled = false;
            Debug.Log("Guard Dead !!");
            animator.SetTrigger("guardDead");
            Destroy (this.gameObject,1f);
        }       
    }
}
