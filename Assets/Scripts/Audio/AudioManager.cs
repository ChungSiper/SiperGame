using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; set; }
    [SerializeField] private AudioDatabaseSO _audioDatabaseSO;
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        Instance = this;

    }
    public void PlaySFX(string audioName, AudioSource audioSource)
    {
        var audioClipData = _audioDatabaseSO.GetAudioClip(audioName);
        if (audioClipData == null)
        {
            return;
        }
        var audioClip = audioClipData.AudioClip;
        audioSource.clip = audioClip;
        audioSource.Play();
    }
}
