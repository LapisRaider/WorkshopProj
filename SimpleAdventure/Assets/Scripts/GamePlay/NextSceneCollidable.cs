using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneCollidable : MonoBehaviour
{
    public string m_nextSceneName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SceneManager.LoadScene(m_nextSceneName);
        }
    }
}
