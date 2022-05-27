using UnityEngine;

public class CopyCat : MonoBehaviour
{
    public float m_JumpForce = 1.0f;
    public Rigidbody2D m_rigidbody;

    void Jump()
    {
        m_rigidbody.velocity += Vector2.up * m_JumpForce;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //TODO:: change sprite or color to show feedback
            Player player = collision.GetComponent<Player>();
            player.RegisterJumpListener(Jump);
        }
    }
}
