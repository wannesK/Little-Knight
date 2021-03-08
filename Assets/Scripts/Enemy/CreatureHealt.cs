using UnityEngine;

public class CreatureHealt : EnemyHealt
{
    public override void EnemyTakeDamage(int damage)
    {
        base.EnemyTakeDamage(damage);

        if (CheckForDead())
        {
            GetComponent<EnemyAI>().enabled = false;
        }
    }
}
