using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerMovement
{
    public float m_speed = 1.0f;
    public float m_jumpForce = 1.0f;

    public float m_fallMultiplier = 1.0f;

    private Rigidbody2D m_rb;

    public void Init(Rigidbody2D rb)
    {
        m_rb = rb;
    }

    public void MoveHorizontal(float dirX)
    {
        m_rb.velocity = new Vector2(dirX * m_speed, m_rb.velocity.y);
    }

    public void Jump()
    {
        m_rb.velocity = m_jumpForce * Vector2.up;
    }

    public void Fall()
    {
        if (m_rb.velocity.y >= 0.0f)
            return;

        m_rb.velocity += Vector2.up * Physics2D.gravity.y * m_fallMultiplier;
    }

    public bool IsFalling()
    {
        return m_rb.velocity.y < 0.0f;
    }
}
