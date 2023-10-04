using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    readonly float GAMETIME = 20f;
    float m_remainingTime;
    [SerializeField]
    TMP_Text m_timerText;

    void Start()
    {
        m_remainingTime = GAMETIME;
        UpdateTimer(0);
    }

    void Update()
    {
        if(IsAnyTimeLeft())
        {
            UpdateTimer(Time.deltaTime);
        }
    }

    public bool IsAnyTimeLeft()
    {
        return m_remainingTime > 0;
    }

    void UpdateTimer(float p_timeElapsed)
    {
        m_remainingTime -= p_timeElapsed;
        if(m_remainingTime < 0)
        {
            m_remainingTime = 0;
        }
        m_timerText.text = ((int)m_remainingTime).ToString();
    }
}
