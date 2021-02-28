using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            MusicManager.PlaySound("Coin");
            ScoreManager.instance.CoinCounter();
            Destroy(this.gameObject);           
        }
    }
}
