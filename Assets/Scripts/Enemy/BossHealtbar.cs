using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealtbar : MonoBehaviour
{
    public Slider healtBar;
    public EnemyHealt enemyHealt;

    private LevelEndTrigger end;
    private void Start()
    {
        end = GameObject.FindGameObjectWithTag("LevelEnd").GetComponent<LevelEndTrigger>();
    }
    void Update()
    {
        healtBar.value = enemyHealt.healt;
        if (enemyHealt.healt <= 0)
        {
            end.LevelComplete();
        }
    }
}
