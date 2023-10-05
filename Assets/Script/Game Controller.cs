using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField]
    GameObject m_replayPanel;
    [SerializeField]
    GameObject m_replayButton;
    [SerializeField]
    TimeManager m_timeManager;
    bool m_isPlaying;

    void Start()
    {
        m_isPlaying = true;
        Time.timeScale = 1f;
        m_replayButton.GetComponent<Button>().onClick.AddListener(HandleButtonClick);
    }

    void Update()
    {
        if (!m_timeManager.IsAnyTimeLeft() && m_isPlaying)
        {
            StopGame();
        }
    }

    void StopGame()
    {
        Time.timeScale = 0f;
        m_replayPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
        m_isPlaying = false;
    }

    void RestartGame()
    {
        ReloadScene();
    }

    void HandleButtonClick()
    {
        RestartGame();
    }

    void ReloadScene()
    {
        Scene l_currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(l_currentScene.name);
    }
}
