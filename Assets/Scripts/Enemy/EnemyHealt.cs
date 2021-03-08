using UnityEngine;

public class EnemyHealt : MonoBehaviour
{
    public int healt;

    private GameObject hitEffect;    
    private Shake shake;          // Camera Shake
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
        hitEffect = GameObject.FindGameObjectWithTag("EnemyTakeHitEffect").gameObject;
    }
    public virtual void EnemyTakeDamage(int damage)
    {             
        healt -= damage;

        shake.CamShake();
        HitEffect();

        animator.SetTrigger("enemyHurt");
        MusicManager.PlaySound("SwordImpact");
    }

    protected bool CheckForDead()
    {
        if (healt <= 0)
        {
            healt = 0;
            transform.GetChild(0).gameObject.SetActive(false);
            animator.SetTrigger("enemyDead");
            Destroy(this.gameObject, 1f);

            return true;
        }
        return false;
    }
    private void HitEffect()
    {
        GameObject effectClone = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effectClone, 1f);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Water"))
        {
            Destroy(this.gameObject);
        }
    }
}
