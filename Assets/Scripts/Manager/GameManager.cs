using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        NotStarted,
        Running,
        GameOver
    }

    public static GameManager Instance { get; private set; }
    public GameObject player;
    [HideInInspector] public GameState gameState = GameState.NotStarted;

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

    private void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    private void Update()
    {
        if (gameState == GameState.GameOver)
        {
            Destroy(player);
        }
    }

    public void LoadGame()
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
