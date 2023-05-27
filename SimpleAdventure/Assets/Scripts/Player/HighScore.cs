using UnityEngine;

public class HighScore : MonoBehaviour
{
    private static HighScore m_Instance;
    private int m_CurrScore = 0;

    private void Awake()
    {
        if (m_Instance == null)
        {
            m_Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }

    public static HighScore GetInstance()
    {
        return m_Instance;
    }

    public int GetCurrScore()
    {
        return m_CurrScore;
    }

    public void SetCurrScore(int newScore)
    {
        m_CurrScore = newScore;
    }
}
