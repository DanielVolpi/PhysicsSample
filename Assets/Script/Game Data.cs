using System.Collections.Generic;
using UnityEngine;

public enum CubeType
{
    TinyCube,
    SmallCube,
    LittleCube,
    MediumCube,
    StandardCube,
    LargeCube,
    BigCube,
    HugeCube
}

public struct CubeProperties
{
    CubeType m_type;
    int m_score;
    float m_size;

    public CubeProperties(CubeType p_type, int p_score, float p_size)
    {
        m_type = p_type;
        m_score = p_score;
        m_size = p_size;
    }

    public CubeType GetCubeType()
    {
        return m_type;
    }

    public int GetScore()
    {
        return m_score;
    }

    public float GetSize()
    {
        return m_size;
    }
}

public static class GameData
{
    static Dictionary<CubeType, CubeProperties> m_typesOfCubes;

    static GameData()
    {
        m_typesOfCubes = new Dictionary<CubeType, CubeProperties> {
            { CubeType.TinyCube, new CubeProperties(CubeType.TinyCube, 10, 0.25f) },
            { CubeType.SmallCube, new CubeProperties(CubeType.SmallCube, 25, 0.5f) },
            { CubeType.LittleCube, new CubeProperties(CubeType.LittleCube, 50, 0.75f) },
            { CubeType.MediumCube, new CubeProperties(CubeType.MediumCube, 75, 1) },
            { CubeType.StandardCube, new CubeProperties(CubeType.StandardCube, 150, 1.25f) },
            { CubeType.LargeCube, new CubeProperties(CubeType.LargeCube, 200, 1.5f) },
            { CubeType.BigCube, new CubeProperties(CubeType.BigCube, 250, 1.75f) },
            { CubeType.HugeCube, new CubeProperties(CubeType.HugeCube, 300, 2) }
        };
    }

    public static CubeProperties GetARandomCubeProperties()
    {
        List<CubeType> l_keys = new (m_typesOfCubes.Keys);
        return m_typesOfCubes[l_keys[Random.Range(0, l_keys.Count)]];
    }

    public static int GetCubeScoreByType(CubeType p_type)
    {
        return m_typesOfCubes.TryGetValue(p_type, out CubeProperties l_properties) ? l_properties.GetScore() : 0;
    }
}
