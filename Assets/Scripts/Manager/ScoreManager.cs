using UnityEngine;
using static GameManager;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    [HideInInspector] public float score;
    [HideInInspector] public float bestScore;

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
        bestScore = SaveSystem.Instance.GetBestScore();
    }

    private void Update()
    {
        if (GameManager.Instance.gameState == GameState.Running)
        {
            score += Time.deltaTime * (10f + score % 100);
        }
        else
        {
            if (score > bestScore)
                bestScore = score;
            SaveSystem.Instance.SaveBestScore();
        }
    }
}
