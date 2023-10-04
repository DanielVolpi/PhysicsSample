using System;
using UnityEngine;

public class CubeData : MonoBehaviour
{
    readonly Color COLOR_NOGRAVITY = new Color(5f / 255f, 196f / 255f, 107f / 255f);
    readonly Color COLOR_GRAVITY = new Color(255f / 255f, 221f / 255f, 89f / 255f);
    readonly Color COLOR_DEFAULT = new Color(210f / 255f, 218f / 255f, 226f / 255f);
    readonly float FLOATINGPOWER = 2.0f;
    readonly float THROWNPOWER = 5.0f;
    CubeProperties m_properties;
    Action<CubeType> m_scorePoints;
    Action<GameObject> m_despawn;

    public void ScorePoints()
    {
        m_scorePoints(m_properties.GetCubeType());
        m_despawn(transform.gameObject);
    }

    public void AddCallbacks(Action<CubeType> p_scorePoints, Action<GameObject> p_despawn)
    {
        m_scorePoints = p_scorePoints;
        m_despawn = p_despawn;
    }

    public void ActivateCube(Vector3 p_position)
    {
        transform.position = p_position;
        SetGravity(true);
        ResetColor();
        transform.gameObject.SetActive(true);
    }

    public void SetCubeProperties(CubeProperties p_cubeProperties)
    {
        m_properties = p_cubeProperties;
        transform.localScale = Vector3.one * m_properties.GetSize();
    }

    public bool IsFloating()
    {
        return !GetComponent<Rigidbody>().useGravity;
    }

    public void LoseGravity()
    {
        Rigidbody l_rigidBody = GetComponent<Rigidbody>();
        l_rigidBody.velocity = Vector3.up * FLOATINGPOWER;
        SetGravity(false);

    }

    public void SetColor()
    {
        Renderer l_meshRenderer = GetComponent<Renderer>();
        Rigidbody l_rigidBody = GetComponent<Rigidbody>();
        l_meshRenderer.materials[0].color = l_rigidBody.useGravity ? COLOR_GRAVITY : COLOR_NOGRAVITY;
    }

    public void ResetColor()
    {
        Renderer l_meshRenderer = GetComponent<Renderer>();
        l_meshRenderer.materials[0].color = COLOR_DEFAULT;
    }

    public void BeThrown()
    {
        Rigidbody l_rigidBody = GetComponent<Rigidbody>();
        l_rigidBody.velocity = Vector3.forward * THROWNPOWER;
        SetGravity(true);
    }

    public void SetGravity(bool p_gravityValue)
    {
        Rigidbody l_rigidBody = GetComponent<Rigidbody>();
        l_rigidBody.useGravity = p_gravityValue;
    }

    void DeSpawnCube()
    {
        gameObject.SetActive(false);
        m_despawn(gameObject);
    }

    public void OnCollisionEnter(Collision p_collision)
    {
        if (p_collision.gameObject.TryGetComponent<ScoreManager>(out var l_scoreManager))
        {
            l_scoreManager.ProcessScore(m_properties.GetCubeType());
            DeSpawnCube();
        }
    }
}
