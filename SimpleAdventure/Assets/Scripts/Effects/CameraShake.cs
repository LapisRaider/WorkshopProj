using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private Camera mainCamera;

    private IEnumerator m_CurrShake;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    public void ShakeCamera(float duration, float magnitude)
    {
        if (m_CurrShake != null)
            StopCoroutine(m_CurrShake);

        m_CurrShake = Shake(duration, magnitude);
        StartCoroutine(m_CurrShake);
    }

    IEnumerator Shake (float duration, float magnitude)
    {
        Vector3 originalPos = mainCamera.transform.position;

        float elasped = 0.0f;

        while (elasped < duration)
        {
            float x = Random.Range(-1.0f, 1.0f) * magnitude;
            float y = Random.Range(-1.0f, 1.0f) * magnitude;

            transform.position = transform.position + new Vector3(x, y, 0.0f);
            elasped += Time.deltaTime;

            yield return null;
        }

        mainCamera.transform.position = originalPos;
    }
}
