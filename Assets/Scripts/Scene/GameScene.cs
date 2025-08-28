using UnityEngine;

public class GameScene : MonoBehaviour
{
    private void Start()
    {
        AudioManager.Instance.Play(AudioManager.Instance.gameClip);
        GameManager.Instance.gameState = GameManager.GameState.Running;
    }
}
