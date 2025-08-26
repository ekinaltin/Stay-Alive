using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    public static SaveSystem Instance { get; private set; }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveBestScore()
    {
        PlayerPrefs.SetFloat("BestScore", ScoreManager.Instance.bestScore);
        PlayerPrefs.Save();
    }

    public float GetBestScore()
    {
        return PlayerPrefs.GetFloat("BestScore", 0f);
    }

    public void SaveMasterVolume()
    {
        PlayerPrefs.SetFloat("MasterVolume", AudioManager.Instance.GetMasterVolume());
        PlayerPrefs.Save();
    }

    public float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat("MasterVolume", 1f);
    }
}
