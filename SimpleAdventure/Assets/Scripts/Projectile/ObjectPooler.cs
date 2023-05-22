using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public GameObject m_ProjectilePrefab;

    private List<GameObject> m_Projectiles = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        if (m_ProjectilePrefab == null)
            Debug.LogError("Projectile prefab is empty");

        SpawnProjectile();
    }

    public void SetProjectile(Vector3 spawnPos, Vector2 faceDir)
    {
        GameObject projectile = GetInactiveProjectile();

        projectile.transform.position = spawnPos;
        Projectile projectileLogic = projectile.GetComponent<Projectile>();
        if (projectileLogic == null)
            Debug.LogError("Projectile script does not exist on projectile");

        projectileLogic.SetDir(faceDir);
        projectile.SetActive(true);
    }

    public GameObject GetInactiveProjectile()
    {
        for (int i = 0; i < m_Projectiles.Count; ++i)
        {
            if (!m_Projectiles[i].activeSelf)
            {
                return m_Projectiles[i];
            }
        }

        SpawnProjectile();

        return GetInactiveProjectile();
    }

    public void SpawnProjectile()
    {
        for (int i = 0; i < 5; ++i)
        {
            GameObject projectile = Instantiate(m_ProjectilePrefab);
            projectile.SetActive(false);
            projectile.transform.SetParent(transform);

            m_Projectiles.Add(projectile);
        }
    }
}
