using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private static CameraShake m_Instance;

    private Camera mainCamera;
    private IEnumerator m_CurrShake;

    private void Awake()
    {
        if (m_Instance == null)
        {
            m_Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (m_Instance != this)
        {
            Destroy(this);
        }    
    }

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    public static CameraShake GetInstance()
    {
        return m_Instance;
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
