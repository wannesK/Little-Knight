using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyFollow : MonoBehaviour
{
    public float speed = 3f;
    public float playerFollowRange = 4f;
    public float stopRange = 1f;
    public bool isFlipped = false;
 

    private Transform player;
    private Animator animator;

    void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        
        FollowThePlayer();
        LookAtPlayer();
    }

    public void FollowThePlayer()
    {
        
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        if (distanceFromPlayer < playerFollowRange && distanceFromPlayer > stopRange)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
            
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, playerFollowRange);
        Gizmos.DrawWireSphere(transform.position, stopRange);
    }
    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0);
            isFlipped = false;
        }
        else if (transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0);
            isFlipped = true;
        }

    }    
}
