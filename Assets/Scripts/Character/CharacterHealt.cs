using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterHealt : MonoBehaviour
{
    public float playerCurrentHealt;
    public float enemyDamage;
    public GameObject touchControl;

    private CharacterAnimationController anim;
    private Rigidbody2D rigid;
    private Shake shake; // Camera Shake
    private GameMaster gm;
    private ScoreManager scoreManager;
    private EnnemyFollow runnerGolem;

    private void Awake()
    {
        anim = GetComponent<CharacterAnimationController>();
        rigid = GetComponent<Rigidbody2D>();

        runnerGolem = GameObject.FindGameObjectWithTag("EnemyRunner").GetComponent<EnnemyFollow>();
        scoreManager = GameObject.FindGameObjectWithTag("Data").GetComponent<ScoreManager>();
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();        
    }
    private void Start()
    {
        transform.position = gm.lastCheckPointPos;              
        playerCurrentHealt = scoreManager.data.playerMaxHealt; // setting a character healt from data 
    }
    void OnTriggerEnter2D(Collider2D other)
    {      
        if (other.CompareTag("EnemyHitbox"))
        { 
            CharacterTakeDamage();
        }
        else if (other.CompareTag("Water"))
        {
            rigid.velocity = Vector2.up * 12;
            CharacterTakeDamage();
        }

         CheckForCharacterDead();     
    }
    public void CharacterTakeDamage()
    {
        playerCurrentHealt -= enemyDamage;
        anim.PlayHurtAnim();
        shake.CamShake();
        MusicManager.PlaySound("CharacterHurt");
    }
    public void CheckForCharacterDead()
    {
        if (playerCurrentHealt <= 0)
        {
            playerCurrentHealt = 0;

            GetComponent<CharacterMovement>().enabled = false;
            GetComponent<CharacterCombatControl>().enabled = false;
            GetComponent<SlowMotion>().SlowTheTime();

            runnerGolem.speed = 0f;
            anim.PlayDeadAnim();            
            touchControl.SetActive(false);

            Invoke("RestartLastCheckPoint", 1f);
        }        
    }
    public void RestartLastCheckPoint()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
