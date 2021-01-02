using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealt : MonoBehaviour
{
    public float playerMaxHealt;
    public float playerCurrentHealt;
    public float enemyDamage;

    public CharacterAnimationController anim;

    private Shake shake; // Camera Shake
    private void Awake()
    {
        anim.GetComponent<CharacterAnimationController>();
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "hitbox")
        { // Taking damage
            playerCurrentHealt -= enemyDamage;
            anim.PlayHurtAnim();
            shake.CamShake();           
            Debug.Log("Player take damage   :" + enemyDamage);           

            if (playerCurrentHealt <= 0)
            {   // Player dead  
                //GetComponent<CharacterMovement>().enabled = false;
                //GetComponent<EnemyAI>().enabled = false;
                Debug.Log("YOU ARE DEAD !! ");
                //anim.PlayDeadAnim();
                //Destroy(this.gameObject, 2f);
            }
        }

    }

}
