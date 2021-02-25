using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCombatControl : MonoBehaviour
{  
    
    [Header("Basic Attack Settings")]
    public Transform attackPos;
    public LayerMask whatIsEnemies;   
    public int basicAttackDamage = 0;        
    public float startTimeBtwAttack;  // Delay between normal attacks
    public float attackRange;
    private float timeBtwAttack;

    [Header("Strike Settings")]
    public int strikeDamage = 0;   
    public float startTimeBetwAttack; // Delay between strikes
    private float timeBetwAttack;

    private bool mobileBasicAttack, mobileStrike;

    private CharacterAnimationController animator;
    private ScoreManager scoreManager;
    private CharacterMovement characterMovement;
    private void Start()
    {
        animator = GetComponent<CharacterAnimationController>();
        characterMovement = GetComponent<CharacterMovement>();
        scoreManager = GameObject.FindGameObjectWithTag("Data").GetComponent<ScoreManager>();

        basicAttackDamage = scoreManager.data.dataAttackDamage;
        strikeDamage = scoreManager.data.dataStrikeDamage;
    }
    
    void Update()
    {
        BasicAttack();
        Strike();
    }
    /// <summary>
    /// This method is character basic attack 
    /// </summary>
    public void BasicAttack ()
    {
        if (timeBtwAttack <= 0)
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

                timeBtwAttack = startTimeBtwAttack;
            }            
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }

    /// <summary>
    /// This method is character strike 
    /// </summary>
    public void Strike()
    {
        if (timeBetwAttack <= 0 && timeBtwAttack <= 0)
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

                timeBetwAttack = startTimeBetwAttack;
            }
        }
        else
        {
            timeBetwAttack -= Time.deltaTime;
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
