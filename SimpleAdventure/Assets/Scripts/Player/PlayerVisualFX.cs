using System.Collections;
using UnityEngine;

public class PlayerVisualFX
{
    Animator m_Animator;

    private bool m_CanChangeAnimation = true;

    const string PLAYER_IDLE = "PlayerIdle";
    const string PLAYER_ATTACK = "PlayerAttack";
    const string PLAYER_RUN = "PlayerRun";
    const string PLAYER_FALL = "PlayerFall";
    const string PLAYER_JUMP = "PlayerJump";

    public PlayerVisualFX(Animator animator)
    {
        m_Animator = animator;
    }

    public void Idle()
    {
        if (m_CanChangeAnimation)
            ChangeAnimation(PLAYER_IDLE);
    }

    public void MoveOnGround()
    {
        if (m_CanChangeAnimation)
            ChangeAnimation(PLAYER_RUN);
    }

    public void Jump()
    {
        if (m_CanChangeAnimation)
            ChangeAnimation(PLAYER_JUMP);
    }

    public void PlayerFall()
    {
        if (m_CanChangeAnimation)
            ChangeAnimation(PLAYER_FALL);
    }

    public void Attack(MonoBehaviour monoBehaviour)
    {
        if (m_CanChangeAnimation)
        {
            ChangeAnimation(PLAYER_ATTACK);

            float attackDelay = m_Animator.GetCurrentAnimatorStateInfo(0).length;
            monoBehaviour.StartCoroutine(PlayWhenAnimationDone(attackDelay));
        }
    }

    private void ChangeAnimation(string animation)
    {
        m_Animator.Play(animation);
    }

    IEnumerator PlayWhenAnimationDone(float animationTime)
    {
        m_CanChangeAnimation = false;

        yield return new WaitForSeconds(animationTime);
        m_CanChangeAnimation = true;

        Debug.Log("Ended");
    }
}
