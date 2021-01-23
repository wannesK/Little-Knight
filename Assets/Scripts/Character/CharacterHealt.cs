using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealt : MonoBehaviour
{
    public float playerMaxHealt;
    public float playerCurrentHealt;
    public float enemyDamage;

    public CharacterAnimationController anim;

    private Rigidbody2D rigid;
    private Shake shake; // Camera Shake
    private void Awake()
    {
        anim.GetComponent<CharacterAnimationController>();
        rigid = GetComponent<Rigidbody2D>();
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyHitbox"))
        { // Taking damage
            playerCurrentHealt -= enemyDamage;
            anim.PlayHurtAnim();
            shake.CamShake();           
            Debug.Log("Player take damage   :" + enemyDamage);                  
        }
        else if (collision.gameObject.CompareTag("Water"))
        {
            rigid.velocity = Vector2.up * 12;
            playerCurrentHealt -= enemyDamage;
            shake.CamShake();
            anim.PlayHurtAnim();
        }
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
