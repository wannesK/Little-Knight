using UnityEngine;

public class CharacterCombatControl : MonoBehaviour
{      
    [Header("Basic Attack Settings")]
    public Transform attackPos;
    public LayerMask whatIsEnemies;   
    public int basicAttackDamage = 0;        
    public float startTimeBtwnBasicAttack;  // Delay between basic attacks
    public float attackRange;
    private float timeBtwnBasicAttack;

    [Header("Strike Settings")]
    public int strikeDamage = 0;   
    public float startTimeBtwnStrike; // Delay between strikes
    private float timeBtwnStrike;

    private bool mobileBasicAttack, mobileStrike;

    private CharacterAnimationController animator;
    private ScoreManager scoreManager;
    private CharacterMovement characterMovement;

    private void Awake()
    {
        animator = GetComponent<CharacterAnimationController>();
        characterMovement = GetComponent<CharacterMovement>();
        scoreManager = GameObject.FindGameObjectWithTag("Data").GetComponent<ScoreManager>();
    }
    private void Start()
    {     
        basicAttackDamage = scoreManager.data.dataAttackDamage; // setting a character attack damage from data
        strikeDamage = scoreManager.data.dataStrikeDamage;
    }
    
    void Update()
    {
        BasicAttack();
        Strike();
    }

    public void BasicAttack ()
    {
        if (timeBtwnBasicAttack <= 0)
        {    
            if (Input.GetKeyDown(KeyCode.LeftControl) || mobileBasicAttack)
            {                
                animator.PlayBasicAttackAnim();
                MusicManager.PlaySound("Sword");

                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<EnemyHealt>().EnemyTakeDamage(basicAttackDamage);
                }

                timeBtwnBasicAttack = startTimeBtwnBasicAttack;
            }            
        }
        else
        {
            timeBtwnBasicAttack -= Time.deltaTime;
        }
    }

    public void Strike()
    {
        if (timeBtwnStrike <= 0 && timeBtwnBasicAttack <= 0)
        {   
            if (Input.GetKeyDown(KeyCode.RightControl) || mobileStrike)
            {
                animator.PlayStrikeAnim();
                MusicManager.PlaySound("Sword");

                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<EnemyHealt>().EnemyTakeDamage(strikeDamage);
                }

                timeBtwnStrike = startTimeBtwnStrike;
            }
        }
        else
        {
            timeBtwnStrike -= Time.deltaTime;
        }

    }
    /// <summary>
    /// We can see the attack position and range with this method
    /// </summary>
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

    public void StopCharacterWhenAttack()
    {
        characterMovement.movementSpeed = 0f;
        Invoke("GiveBackMovementSpeed", 0.3f);
    }
    public void GiveBackMovementSpeed()
    {
        characterMovement.movementSpeed = 4f;
    }

    /// <summary>
    ///             MOBILE CONTROLS
    /// </summary>
    public void MobileBasicAttack()
    {
        mobileBasicAttack = true;
    }
    public void MobileStrike()
    {
        mobileStrike = true;
    }

    public void MobileAttackFalse()
    {
        mobileBasicAttack = false;
        mobileStrike = false;
    }
}
