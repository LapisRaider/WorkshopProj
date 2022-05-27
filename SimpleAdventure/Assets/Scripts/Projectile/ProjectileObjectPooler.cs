using System.Collections.Generic;
using UnityEngine;

public class ProjectileObjectPooler : MonoBehaviour
{
    public const int SPAWN_AMT = 5;
    public GameObject m_ProjectilePrefab;

    private List<GameObject> m_Projectiles = new List<GameObject>();

    void Start()
    {
        SpawnMore();
    }

    public GameObject SpawnProjectile(Vector3 spawnPos, Vector2 moveDir)
    {
        GameObject projectile = GetInactiveProjectile();
        projectile.transform.position = spawnPos;

        Projectile projectileLogic = projectile.GetComponent<Projectile>();
        if (projectileLogic == null)
            Debug.LogError("Projectile script does not exist on projectile");

        projectileLogic.SetDir(moveDir);
        projectile.SetActive(true); //make it active

        return projectile;
    }

    public GameObject GetInactiveProjectile()
    {
        for (int i = 0; i < m_Projectiles.Count; ++i)
        {
            if (!m_Projectiles[i].activeSelf)
                return m_Projectiles[i];
        }

        SpawnMore(); // found 0 inactive, spawn more

        return GetInactiveProjectile();
    }

    void SpawnMore()
    {
        if (m_ProjectilePrefab == null)
            Debug.LogError("Projectile Prefab is empty");

        for (int i = 0; i < SPAWN_AMT; ++i)
        {
            GameObject projectileSpawned = Instantiate(m_ProjectilePrefab); //create gameobject
            projectileSpawned.transform.parent = transform; //parent it to this one
            projectileSpawned.transform.localPosition = Vector3.zero; //reset curr position

            projectileSpawned.SetActive(false);
            m_Projectiles.Add(projectileSpawned);
        }
    }
}
