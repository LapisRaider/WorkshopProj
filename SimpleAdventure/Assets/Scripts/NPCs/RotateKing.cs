using System.Collections;
using UnityEngine;

public class RotateKing : MonoBehaviour
{
    public const float ROTATE_TIME = 3.0f;
    public const float ROTATE_AMT = 10.0f;

    private float m_RotateTime = 0.0f;

    void StartRotating()
    {
        m_RotateTime = ROTATE_TIME;
        StartCoroutine(Rotate());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Player player = collision.GetComponent<Player>();
            player.RegisterJumpListener(StartRotating);
        }
    }

    IEnumerator Rotate()
    {
        while (m_RotateTime > 0.0f)
        {
            transform.Rotate(ROTATE_AMT, 0.0f, 0.0f, 0.0f);
            yield return null;
        }

        yield return null;
    }
}
