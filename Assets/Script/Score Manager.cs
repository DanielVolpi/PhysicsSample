using TMPro;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    TMP_Text m_scoreCounterText;
    [SerializeField]
    TMP_Text m_counterText;
    int m_score;
    int m_counter;

    void Start()
    {
        SetScore();
        SetCounter();
    }

    void SetScore(int p_score = 0)
    {
        m_score = p_score;
        m_scoreCounterText.text = m_score.ToString();
    }

    void AddScore(int p_score = 0)
    {
        SetScore(m_score + p_score);
    }

    void SetCounter(int p_counter = 0)
    {
        m_counter = p_counter;
        m_counterText.text = m_counter.ToString();
    }

    void AddCounter(int p_counter = 1)
    {
        SetCounter(m_counter + p_counter);
    }

    public void ProcessScore(CubeType p_cubeType)
    {
        AddScore(GameData.GetCubeScoreByType(p_cubeType));
        AddCounter();
    }

    void Update()
    {
        
    }
}
