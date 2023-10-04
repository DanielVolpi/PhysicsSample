using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField]
    GameObject m_bulletContainer;
    [SerializeField]
    GameObject m_bulletPrefab;

    static readonly int BULLETQUANTITY = 3;
    Pool m_bulletPool;

    void Start()
    {
        m_bulletPool = new(m_bulletPrefab, m_bulletContainer, BULLETQUANTITY);
    }

    public void Shoot()
    {
        GameObject l_bulletToSpawn = m_bulletPool.PickElementFromPool();
        if (l_bulletToSpawn != null)
        {
            Bullet l_bulletBehaviour = l_bulletToSpawn.GetComponent<Bullet>();
            l_bulletBehaviour.AddCallback(m_bulletPool.AddElementToPool);
            l_bulletBehaviour.SpawnBullet(transform.position, transform.forward);
        }
    }
}
