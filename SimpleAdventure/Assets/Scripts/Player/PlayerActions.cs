using UnityEngine;

[System.Serializable]
public class PlayerActions
{
    public GameObject m_ProjectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        if (m_ProjectilePrefab == null)
            Debug.LogError("No Projectile prefab");
    }

    public void Shoot(Vector3 spawnPos, Vector2 faceDir)
    {
        GameObject projectile = Object.Instantiate(m_ProjectilePrefab);
        projectile.transform.localPosition = Vector3.zero; //reset curr position

        projectile.transform.position = spawnPos;
        Projectile projectileLogic = projectile.GetComponent<Projectile>();
        if (projectileLogic == null)
            Debug.LogError("Projectile script does not exist on projectile");

        projectileLogic.SetDir(faceDir);
    }
}
