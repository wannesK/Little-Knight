using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void PlayJumpingAnim()
    {
        animator.SetBool("isJumping", true);
        animator.SetBool("isRunning", false);
    }
    public void PlayIdleAnim()
    {
        animator.SetBool("isRunning", false);
        animator.SetBool("isJumping", false);
    }

    public void PlayRunningAnim()
    {
        animator.SetBool("isRunning", true);
        animator.SetBool("isJumping", false);
    }

    public void PlayBasicAttackAnim()
    {
        animator.SetTrigger("basicAttack");
    }
    public void PlayStrikeAnim()
    {
        animator.SetTrigger("strike");
    }
    public void PlayDeadAnim()
    {
        animator.SetTrigger("dead");
    }
    public void PlayHurtAnim()
    {
        animator.SetTrigger("hurt");
    }

}
