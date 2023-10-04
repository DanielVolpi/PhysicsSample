using System.Collections.Generic;
using UnityEngine;

public class Pool
{
    GameObject m_prefab;
    GameObject m_parent;
    int m_limit;
    Stack<GameObject> m_pool;

    public Pool(GameObject p_prefab, GameObject p_parent, int p_limit)
    {
        m_prefab = p_prefab;
        m_parent = p_parent;
        m_limit = p_limit;

        m_pool = new();
        for (int i = 0; i < m_limit; i++)
        {
            GameObject l_newCube = Helpers.CreateGameObjectFromPrefab(m_prefab, m_parent, Vector3.zero, false);
            m_pool.Push(l_newCube);
        }
    }

    public GameObject PickElementFromPool()
    {
        return !IsEmpty() ? m_pool.Pop() : null;
    }

    public void AddElementToPool(GameObject p_elementToAdd)
    {
        m_pool.Push(p_elementToAdd);
    }

    public bool IsEmpty()
    {
        return m_pool.Count == 0;
    }
}
