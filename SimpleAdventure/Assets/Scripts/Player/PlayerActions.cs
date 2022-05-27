using UnityEngine;

[System.Serializable]
public class PlayerActions
{
    public ProjectileObjectPooler m_ProjectileObjPooler;

    // Start is called before the first frame update
    void Start()
    {
        if (m_ProjectileObjPooler == null)
            Debug.LogError("No Projectile Obj pooler ref");
    }

    public void Shoot(Vector3 spawnPos, Vector2 faceDir)
    {
        m_ProjectileObjPooler.SpawnProjectile(spawnPos, faceDir);
    }
}
