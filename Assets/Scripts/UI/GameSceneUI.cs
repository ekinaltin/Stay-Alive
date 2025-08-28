using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameSceneUI : MonoBehaviour
{
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private TextMeshProUGUI gameOverScoreText;
    [SerializeField] private TextMeshProUGUI countText;
    [SerializeField] private TextMeshProUGUI gameScoreText;
    [SerializeField] private TextMeshProUGUI gameOverBestScoreText;
    [SerializeField] private GameObject controlButtonsPanel;
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private TextMeshProUGUI volumeSliderText;

    private int startCount = 3;

    private void Start()
    {
        volumeSlider.value = AudioManager.Instance.GetMasterVolume();
        StartCoroutine(CountDown());
    }

    private void Update()
    {
        if(GameManager.Instance.gameState == GameManager.GameState.GameOver)
        {
            LoadGameOverPanel();
        }

        if (settingsPanel.activeInHierarchy)
        {
            volumeSliderText.text = ((int)(AudioManager.Instance.GetMasterVolume()*100f)).ToString();
        }

        gameScoreText.text = ((int)ScoreManager.Instance.score).ToString();
    }

    private void LoadGameOverPanel()
    {
        gameOverPanel.SetActive(true);
        controlButtonsPanel.SetActive(false);
        gameScoreText.gameObject.SetActive(false);
        gameOverScoreText.text = "Score\n" + (int)ScoreManager.Instance.score;
        gameOverBestScoreText.text = "Best Score\n" + (int)ScoreManager.Instance.bestScore;
        GameManager.Instance.gameState = GameManager.GameState.NotStarted;
    }

    private IEnumerator CountDown()
    {
        GameManager.Instance.PauseGame();
        int count = startCount;
        while (count > 0)
        {
            countText.text = count.ToString();
            yield return new WaitForSecondsRealtime(1f);
            count--;
        }
        countText.text = "Start!";
        yield return new WaitForSecondsRealtime(1f);
        gamePanel.SetActive(true);
        countText.transform.parent.gameObject.SetActive(false);
        GameManager.Instance.ResumeGame();
    }
}
