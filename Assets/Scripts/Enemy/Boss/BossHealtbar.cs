using UnityEngine;
using UnityEngine.UI;

public class BossHealtbar : MonoBehaviour
{
    public EnemyHealt enemyHealt;

    private Slider healtBar; 
    private LevelEndTrigger end;
    private void Start()
    {
        healtBar = GetComponent<Slider>();
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
