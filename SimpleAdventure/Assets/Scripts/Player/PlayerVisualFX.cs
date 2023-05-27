using System.Collections;
using UnityEngine;

public class PlayerVisualFX
{
    Animator m_Animator;
    SpriteRenderer m_Sprite;

    private bool m_CanChangeAnimation = true;

    const string PLAYER_IDLE = "PlayerIdle";
    const string PLAYER_ATTACK = "PlayerAttack";
    const string PLAYER_RUN = "PlayerRun";
    const string PLAYER_FALL = "PlayerFall";
    const string PLAYER_JUMP = "PlayerJump";

    public void Init(Animator animator, SpriteRenderer sprite)
    {
        m_Animator = animator;
        m_Sprite = sprite;
    }

    public void Idle(Vector2 faceDir)
    {
        if (m_CanChangeAnimation)
            ChangeAnimation(PLAYER_IDLE);

        m_Sprite.flipX = faceDir.x == -1;
    }

    public void MoveOnGround(Vector2 faceDir)
    {
        if (m_CanChangeAnimation)
            ChangeAnimation(PLAYER_RUN);

        m_Sprite.flipX = faceDir.x == -1;
    }

    public void Jump(Vector2 faceDir)
    {
        if (m_CanChangeAnimation)
            ChangeAnimation(PLAYER_JUMP);

        m_Sprite.flipX = faceDir.x == -1;
    }

    public void PlayerFall(Vector2 faceDir)
    {
        if (m_CanChangeAnimation)
            ChangeAnimation(PLAYER_FALL);

        m_Sprite.flipX = faceDir.x == -1;
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
    }
}
