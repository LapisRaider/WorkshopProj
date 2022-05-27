using UnityEngine;

public class CopyCat : MonoBehaviour
{
    public float m_JumpForce = 1.0f;
    public Rigidbody2D m_rigidbody;

    void Jump()
    {
        m_rigidbody.velocity += Vector2.up * m_JumpForce;
    }
}
