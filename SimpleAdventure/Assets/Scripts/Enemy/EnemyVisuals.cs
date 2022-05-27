using System.Collections;
using UnityEngine;

[System.Serializable]
public class EnemyVisuals
{
    public float HIT_FORCE = 5.0f;
    public ParticleSystem m_BloodSplatter;

    [InspectorName("Shake magnitude")]
    public float m_ShakeMagnitude = 1.0f;
    public float m_ShakeDuration = 0.5f;

    [InspectorName("Stutter FX")]
    public float m_StutterFrequency = 0.2f;
    public int m_StutterAmt = 6;
    private SpriteRenderer m_Sprite;

    private Rigidbody2D m_Rigidbody2D;

    public void Init(Rigidbody2D rigidbody2D, SpriteRenderer sprite)
    {
        m_Rigidbody2D = rigidbody2D;
        m_Sprite = sprite;
    }

    public void HitEffect(Vector2 hitDir, MonoBehaviour monoBehaviour)
    {
        m_Rigidbody2D.velocity += hitDir * HIT_FORCE;

        if (m_BloodSplatter != null)
            m_BloodSplatter.Play();

        CameraShake.GetInstance().ShakeCamera(m_ShakeDuration, m_ShakeMagnitude);

        monoBehaviour.StartCoroutine(Flash());
    }

    IEnumerator Flash()
    {
        for (int i = 0; i < m_StutterAmt; ++i)
        {
            m_Sprite.enabled = !m_Sprite.enabled;
            yield return new WaitForSeconds(m_StutterFrequency);
        }

        m_Sprite.enabled = true;
        yield return null;
    }
}
