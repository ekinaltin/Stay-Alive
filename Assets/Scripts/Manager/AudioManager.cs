using TMPro;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance {  get; private set; }
    public AudioClip mainMenuClip;
    public AudioClip gameClip;
    public AudioMixer audioMixer;

    private AudioSource audioSource;

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

        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        SetMasterVolume(SaveSystem.Instance.GetMasterVolume());
    }

    public void Play(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }

    public void Stop()
    {
        audioSource.Stop();
    }

    public void SetMasterVolume(float value)
    {
        value = Mathf.Clamp(value, 0.0001f, 1f);
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(value) * 20f);
        SaveSystem.Instance.SaveMasterVolume();
    }
    public float GetMasterVolume()
    {
        audioMixer.GetFloat("MasterVolume", out float dB);
        return Mathf.Pow(10f, dB / 20f);
    }
}
