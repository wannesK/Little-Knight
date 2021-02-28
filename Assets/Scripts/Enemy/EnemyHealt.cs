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
    {             
        healt -= damage;
        TakingDamage();

        if (gameObject.CompareTag("Enemy") && healt <= 0)
        {    
            GetComponent<EnemyAI>().enabled = false;
            EnemyDead();
        }
        if (gameObject.CompareTag("EnemyRunner") && healt <= 0)
        {   // Runner DEAD
            GetComponent<EnnemyFollow>().enabled = false;
            transform.GetChild(0).gameObject.SetActive(false);
            EnemyDead();
        }
    }
    public void TakingDamage()
    {
        shake.CamShake();
        GameObject effectClone = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effectClone, 1f);
        animator.SetTrigger("enemyHurt");
        MusicManager.PlaySound("SwordImpact");
    }
    public void EnemyDead()
    {
        animator.SetTrigger("enemyDead");
        Destroy(this.gameObject, 1f);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Water"))
        {
            Destroy(this.gameObject);
        }
    }
}
