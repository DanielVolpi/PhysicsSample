using UnityEngine;
using System.Collections;

public class CubeManager : MonoBehaviour
{
    readonly float RESPAWNDELAY = 1.5f;

    [SerializeField]
    GameObject m_cubeContainer;
    [SerializeField]
    GameObject m_cubePrefab;
    //@DOUBT: ¿Como seria la mejor forma de acceder al manejador de Scoring?
    [SerializeField]
    GameObject m_gameSystem;
    ScoreManager m_scoreManager;

    static readonly int CUBESQUANTITY = 5;
    Pool m_cubePool;

    void Start()
    {
        m_scoreManager = m_gameSystem.GetComponent<ScoreManager>();
        m_cubePool = new(m_cubePrefab, m_cubeContainer, CUBESQUANTITY);
        while(!m_cubePool.IsEmpty())
        {
            SpawnCube();
        }
    }

    void SpawnCube()
    {
        GameObject l_cubeToSpawn = m_cubePool.PickElementFromPool();
        if(l_cubeToSpawn != null)
        {
            CubeData l_currentCubeData = l_cubeToSpawn.GetComponent<CubeData>();
            l_currentCubeData.AddCallbacks(ProcessScore, DeSpawnCube);
            l_currentCubeData.SetCubeProperties(GameData.GetARandomCubeProperties());
            l_currentCubeData.ActivateCube(GetRandomPosition());
        }
    }

    public void ProcessScore(CubeType p_cubeType)
    {
        m_scoreManager.ProcessScore(p_cubeType);
    }

    Vector3 GetRandomPosition()
    {
        return new Vector3(
            Random.Range(
                transform.position.x - transform.localScale.x / 2,
                transform.position.x + transform.localScale.x / 2
            ),
            transform.position.y,
            Random.Range(
                transform.position.z - transform.localScale.z / 2,
                transform.position.z + transform.localScale.z / 2
            )
        );
    }

    IEnumerator TriggerReSpawnCube()
    {
        yield return new WaitForSeconds(RESPAWNDELAY);
        SpawnCube();
    }

    void DeSpawnCube(GameObject p_cubeToDeSpawn)
    {
        m_cubePool.AddElementToPool(p_cubeToDeSpawn);
        p_cubeToDeSpawn.SetActive(false);
        StartCoroutine(TriggerReSpawnCube());
    }

    void Update()
    {
        
    }
}