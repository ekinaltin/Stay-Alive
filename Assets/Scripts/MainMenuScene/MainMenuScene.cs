using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScene : MonoBehaviour
{
    private void Start()
    {
        AudioManager.Instance.Play(AudioManager.Instance.mainMenuClip);
    }
    public void LoadGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}
