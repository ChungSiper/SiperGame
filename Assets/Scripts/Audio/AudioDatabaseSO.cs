using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioDatabaseSO", menuName = "Scriptable Objects/AudioDatabaseSO")]
public class AudioDatabaseSO : ScriptableObject
{
    public List<AudioClipData> PlayerSFX = new();
    public List<AudioClipData> EnemySFX = new();
    public List<AudioClipData> USISFX = new();

    private Dictionary<string, AudioClipData> _playerSFXDict = new();
    private Dictionary<string, AudioClipData> _enemySFXDict = new();
    private Dictionary<string, AudioClipData> _usiSFXDict = new();

    void OnValidate()
    {
        InitializeDB(PlayerSFX);
        InitializeDB(EnemySFX);
        InitializeDB(USISFX);
    }
    private void InitializeDB(List<AudioClipData> audioClip)
    {
        foreach (var itemClip in audioClip)
        {
            _playerSFXDict.Add(itemClip.AudioClipName, itemClip);    
        }
    }
    public AudioClipData GetAudioClip(string audioNam)
    {
        if(_playerSFXDict.TryGetValue(audioNam, out var audioClipData))
        {
            return audioClipData;
        }
        return null;
    }

}
