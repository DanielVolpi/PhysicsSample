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

    void Start()
    {
        m_replayButton.GetComponent<Button>().onClick.AddListener(HandleButtonClick);
    }

    void Update()
    {
        if (!m_timeManager.IsAnyTimeLeft())
        {
            StopGame();
        }
    }

    void StopGame()
    {
        //@ALERT: ¿Por que esto funciona pero el 1f en RestartGame no?
        //Time.timeScale = 0f;
        m_replayPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
    }

    void RestartGame()
    {
        Time.timeScale = 1f;
        //m_replayPanel.SetActive(false);
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
