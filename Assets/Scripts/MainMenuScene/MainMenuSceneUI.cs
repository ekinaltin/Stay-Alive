using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI bestScoreText;
    private void Start()
    {
        bestScoreText.text = "BestScore\n" + (int)SaveSystem.Instance.GetBestScore();
    }
}
