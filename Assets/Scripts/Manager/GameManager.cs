using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public GameObject player;
    [HideInInspector] public bool gameOver;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (gameOver)
        {
            Destroy(player);
        }
    }

    public void RestartGame()
    {
        ScoreManager.Instance.score = 0f;
        SceneManager.LoadScene("GameScene");
    }
    public void LoadMenu()
    {
        ScoreManager.Instance.score = 0f;
        SceneManager.LoadScene("MainMenuScene");
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;
    }
}
