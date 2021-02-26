using UnityEngine;

public class InterstitialAdTrigger : MonoBehaviour
{
    public ADS adsManager;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            adsManager.ShowInterstitialAd();
            Destroy(this.gameObject, 1f);
        }               
    }
}
