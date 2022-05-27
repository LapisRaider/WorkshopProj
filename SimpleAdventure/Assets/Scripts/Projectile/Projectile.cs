using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float m_Speed = 1.0f;
    public string[] m_CollidableTags;

    private Vector2 m_dir = new Vector2(1.0f, 0.0f);

    public void SetDir(Vector2 dir)
    {
        m_dir = dir;
    }

    private void FixedUpdate()
    {
        //Projectile move horizontally in direction
        transform.position += new Vector3(m_dir.x * m_Speed * Time.fixedDeltaTime, 0.0f, 0.0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        for (int i = 0; i < m_CollidableTags.Length; ++i)
        {
            if (m_CollidableTags[i] == collision.tag)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
