using UnityEngine;

public class Enemy : MonoBehaviour 
{
    public string[] m_CollidableTags;

    public EnemyVisuals m_EnemyVisuals = new EnemyVisuals();

    private void Start()
    {
        m_EnemyVisuals.Init(GetComponent<Rigidbody2D>());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        for (int i = 0; i < m_CollidableTags.Length; ++i)
        {
            if (m_CollidableTags[i] == collision.tag)
            {
                Vector2 hitDir = transform.position - collision.transform.position;
                hitDir.Normalize();

                m_EnemyVisuals.HitEffect(hitDir);
            }
        }
    }
}
