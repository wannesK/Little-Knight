using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealtbar : MonoBehaviour
{
    public Slider healtBar;
    public EnemyHealt enemyHealt;

    void Update()
    {
        healtBar.value = enemyHealt.healt;
    }
}
