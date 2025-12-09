using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86;
public enum SoundType
{
    Button,
    Popup,
    TurnOnLighter,
    Solid,
    Liquid,
    Gas,
}
public class AudioMainManager : SingletonMain<AudioMainManager>
{
    [Header("Audio Effects")]
    [SerializeField] private AudioSource m_AudioSource;
    [SerializeField] private AudioClip m_AudioPopupClip;
    [SerializeField] private AudioClip m_AudioButtonClip;
    [SerializeField] private AudioClip m_AudioTurnOnLighter;

    [SerializeField] private AudioClip m_AudioSolid;
    [SerializeField] private AudioClip m_AudioLiquid;
    [SerializeField] private AudioClip m_AudioGas;
 

    private Dictionary<SoundType, AudioClip> m_SoundMap;
    private void Awake()
    {
        m_SoundMap = new Dictionary<SoundType, AudioClip>
        {
            { SoundType.Button, m_AudioButtonClip },
            { SoundType.Popup, m_AudioPopupClip },
            {SoundType.TurnOnLighter,m_AudioTurnOnLighter },
            {SoundType.Solid,m_AudioSolid},
            {SoundType.Liquid,m_AudioLiquid},
            {SoundType.Gas, m_AudioGas },
        };
    }
    public void PlayOnShot(SoundType soundType)
    {
        if (m_SoundMap.TryGetValue(soundType, out var clip) && clip != null)
            m_AudioSource.PlayOneShot(clip);
        else
            Debug.LogWarning($"AudioManager: AudioClip for {soundType} is not assigned.");
    }
    public void StopSound(SoundType type) => m_AudioSource?.Stop();
    public void StopAtomicSounds()
    {
        if (m_AudioSource != null && m_AudioSource.isPlaying) m_AudioSource.Stop();
    }
    public void PlayLoop(SoundType soundType)
    {
        if (m_SoundMap.TryGetValue(soundType, out var clip) && clip != null && m_AudioSource != null)
        {
            m_AudioSource.loop = true;
            m_AudioSource.clip = clip;
            m_AudioSource.Play();
        }
    }
    public void PlayAudioIntroduction(AudioClip clip)
    {
        m_AudioSource.clip = clip;
        m_AudioSource.Play();
    }
    public void StopLoop()
    {
        if (m_AudioSource != null)
        {
            m_AudioSource.Stop();
            m_AudioSource.loop = false;
            m_AudioSource.clip = null;
        }
    }
}
