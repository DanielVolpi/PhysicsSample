using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    readonly float BULLETSPEED = 7f;
    Action<GameObject> m_despawn;

    public void SpawnBullet(Vector3 p_position, Vector3 p_direction)
    {
        transform.position = p_position;
        gameObject.SetActive(true);
        Rigidbody l_rigidBody = GetComponent<Rigidbody>();
        l_rigidBody.velocity = p_direction * BULLETSPEED;
    }

    void DeSpawnBullet()
    {
        gameObject.SetActive(false);
        m_despawn(gameObject);
    }

    public void OnCollisionEnter(Collision p_collision)
    {
        DeSpawnBullet();
        if (p_collision.gameObject.TryGetComponent<CubeData>(out var l_cubeData))
        {
            if(l_cubeData.IsFloating())
            {
                l_cubeData.BeThrown();
            } else
            {
                l_cubeData.LoseGravity();
            }
            
        }
    }

    public void AddCallback(Action<GameObject> p_despawn)
    {
        m_despawn = p_despawn;
    }
}