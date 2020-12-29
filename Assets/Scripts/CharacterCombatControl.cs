using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCombatControl : MonoBehaviour
{  
    
    [Header("Basic Attack Settings")]
    public Transform attackPos;
    public LayerMask whatIsEnemies;   
    public int basicAttackDamage;        
    public float startTimeBtwAttack;  // Delay between normal attacks
    public float attackRange;
    private float timeBtwAttack;

    [Header("Strike Settings")]
    public int strikeDamage;   
    public float startTimeBetwAttack; // Delay between strikes
    private float timeBetwAttack;

    private CharacterAnimationController animator;

    private void Awake()
    {
        animator = GetComponent<CharacterAnimationController>();
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
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {                
                animator.PlayBasicAttackAnim();
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
        if (timeBetwAttack <= 0 && timeBtwAttack <= 0 )
        {   
            if (Input.GetKeyDown(KeyCode.RightControl))
            {
                animator.PlayStrikeAnim();
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
}
