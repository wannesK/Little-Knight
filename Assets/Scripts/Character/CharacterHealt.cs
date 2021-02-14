using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterHealt : MonoBehaviour
{

    public float playerCurrentHealt;
    public float enemyDamage;

    public CharacterAnimationController anim;
    private Rigidbody2D rigid;
    private Shake shake; // Camera Shake
    private GameMaster gm;
    private ScoreManager scoreManager;
    private void Start()
    {
        anim.GetComponent<CharacterAnimationController>();
        rigid = GetComponent<Rigidbody2D>();

        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
        scoreManager = GameObject.FindGameObjectWithTag("Data").GetComponent<ScoreManager>();
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
        transform.position = gm.lastCheckPointPos;

        playerCurrentHealt = scoreManager.data.playerMaxHealt;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("EnemyHitbox"))
        { // Taking damage
            playerCurrentHealt -= enemyDamage;
            anim.PlayHurtAnim();
            shake.CamShake();                          
        }
        else if (other.CompareTag("Water"))
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
