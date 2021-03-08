using UnityEngine;

public class RunnerHealt : EnemyHealt
{
    public override void EnemyTakeDamage(int damage)
    {
        base.EnemyTakeDamage(damage);

        if (CheckForDead())
        {
            GetComponent<EnnemyFollow>().enabled = false;
        }
    }    
}
