using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScene : MonoBehaviour
{
    private void Start()
    {
        AudioManager.Instance.Play(AudioManager.Instance.mainMenuClip);
        GameManager.Instance.gameState = GameManager.GameState.NotStarted;
    }
}
