using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterHealt : MonoBehaviour
{
    public float playerMaxHealt;
    public float playerCurrentHealt;
    public float enemyDamage;

    public CharacterAnimationController anim;
    private Rigidbody2D rigid;
    private Shake shake; // Camera Shake
    private GameMaster gm;
    private void Awake()
    {
        anim.GetComponent<CharacterAnimationController>();
        rigid = GetComponent<Rigidbody2D>();
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
        transform.position = gm.lastCheckPointPos;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("EnemyHitbox"))
        { // Taking damage
            playerCurrentHealt -= enemyDamage;
            anim.PlayHurtAnim();
            shake.CamShake();                          
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
            GetComponent<CharacterMovement>().enabled = false;
            GetComponent<SlowMotion>().SlowTheTime();
            anim.PlayDeadAnim();
            Invoke("RestartLastCheckPoint", 1.2f);
        }
    }
    public void RestartLastCheckPoint()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
