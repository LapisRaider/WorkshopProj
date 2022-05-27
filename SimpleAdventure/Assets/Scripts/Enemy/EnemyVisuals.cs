using UnityEngine;

[System.Serializable]
public class EnemyVisuals
{
    [SerializeField] public float HIT_FORCE = 5.0f;
    [SerializeField] public ParticleSystem m_BloodSplatter;

    private Rigidbody2D m_Rigidbody2D;

    public void Init(Rigidbody2D rigidbody2D)
    {
        m_Rigidbody2D = rigidbody2D;
    }

    public void HitEffect(Vector2 hitDir)
    {
        //TODO::
        //flash
        m_Rigidbody2D.velocity += hitDir * HIT_FORCE;

        m_BloodSplatter.Play();
    }
}
