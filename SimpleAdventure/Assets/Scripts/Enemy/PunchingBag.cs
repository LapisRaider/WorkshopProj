using UnityEngine;
using TMPro;

public class PunchingBag : MonoBehaviour
{
    public TextMeshProUGUI m_HighScoreText;

    void Awake()
    {
        if (m_HighScoreText == null)
            Debug.LogError("HighScore text reference is missing");

        m_HighScoreText.text = HighScore.GetInstance().GetCurrScore().ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Projectile")
        {
            HighScore highScore = HighScore.GetInstance();
            int newHighScore = highScore.GetCurrScore() + 1;
            highScore.SetCurrScore(newHighScore);

            m_HighScoreText.text = newHighScore.ToString();
        }
    }
}
