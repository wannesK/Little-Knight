using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    private Rigidbody2D rigid;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Invoke("DropPlatform", 0.5f);
            Destroy(gameObject, 1);
        }
    }
    void DropPlatform()
    {
        rigid.isKinematic = false;
    }
}
