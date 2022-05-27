using UnityEngine;

[System.Serializable]
public class EnemyVisuals
{
    public float m_HitForce = 1.0f;

    private Rigidbody2D m_Rigidbody2D;

    public EnemyVisuals(Rigidbody2D rigidbody2D)
    {
        m_Rigidbody2D = rigidbody2D;
    }

    public void HitEffect(Vector2 hitDir)
    {
        //TODO::
        //flash
        //insert particle effects here
        m_Rigidbody2D.velocity += hitDir * m_HitForce;
    }
}
