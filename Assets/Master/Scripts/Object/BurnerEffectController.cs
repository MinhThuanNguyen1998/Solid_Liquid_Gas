using System.Collections;
using System.Collections.Generic;
using System.Threading;
using LiquidVolumeFX;
using UnityEngine;

public class BurnerEffectController : MonoBehaviour
{
    [SerializeField] private ParticleSystem m_FireParticleSystem;
    [SerializeField] private ParticleSystem m_SmokeParticleSystem;
    [SerializeField] private LiquidVolume m_LiquidVolume;
    [Header("SoundEffect")]
    [SerializeField] private AudioSource m_AudioSource;
    [SerializeField] private AudioClip m_AudioBoilingWater;
    [Header("StepLiquid")]
    [SerializeField] private StepLiquid m_StepLiquid;
    private float m_WaitingTimeToPlaySmokeParticleSystem = 15f;
    private float m_BoilingPoint = 0.32f;
    private Coroutine m_BoilingCoroutine;

    private void Awake()
    {
        m_FireParticleSystem.Stop();
        m_SmokeParticleSystem.Stop();
    }
    public void TurnOnBoilingEffect()
    {
        if (!m_FireParticleSystem.isPlaying || m_BoilingCoroutine != null) return;
        m_BoilingCoroutine = StartCoroutine(CoroutinePlayBoilingEffectAfterDelay());
    }
    private IEnumerator CoroutinePlayBoilingEffectAfterDelay()
    {
        yield return new WaitForSeconds(m_WaitingTimeToPlaySmokeParticleSystem);
        if (m_SmokeParticleSystem != null)
        {
            m_SmokeParticleSystem.Play();
            PlayLoopSoundBoilingWater();
            m_LiquidVolume.sparklingAmount = m_BoilingPoint;
            MagnifyingManager.Instance.ActiveMagnifyingObject(true);
        }
    }
    public void TurnOnFireEffect()
    {
        m_FireParticleSystem.Play();
        if (m_BoilingCoroutine == null && m_StepLiquid?.CurretSteps >= 1) m_BoilingCoroutine = StartCoroutine(CoroutinePlayBoilingEffectAfterDelay());
    }
    public void TurnOffBoilingEffect()
    {
        if (m_BoilingCoroutine != null)
        {
            StopCoroutine(m_BoilingCoroutine);
            m_BoilingCoroutine = null;
        }
        // Stop particle effects
        if (m_SmokeParticleSystem != null && m_SmokeParticleSystem.isPlaying) m_SmokeParticleSystem.Stop();
        if (m_AudioSource != null && m_AudioSource.isPlaying) m_AudioSource.Stop();
        if (m_LiquidVolume != null) m_LiquidVolume.sparklingAmount = 0f;
    }
    public void PlayLoopSoundBoilingWater()
    {
        m_AudioSource.loop = true;
        m_AudioSource.clip = m_AudioBoilingWater;
        m_AudioSource.Play();
    }
}
