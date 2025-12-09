using System.Collections;
using System.Threading;
using LiquidVolumeFX;
using UnityEngine;

public class BurnerEffectController : MonoBehaviour
{
    [SerializeField] private ParticleSystem m_FireParticleSystem;
    [SerializeField] private ParticleSystem m_SmokeParticleSystem;
    [SerializeField] private LiquidVolume m_LiquidVolume;
    private float m_WaitingTimeToPlaySmokeParticleSystem = 5f;
    private float m_BoilingPoint = 0.32f;
    private Coroutine m_SmokeCoroutine;

    private void Awake()
    {
        m_FireParticleSystem.Stop();
        m_SmokeParticleSystem.Stop();
    }
    public void TurnOnEffect()
    {
        if (m_FireParticleSystem != null) m_FireParticleSystem.Play();
        if (m_SmokeCoroutine != null) StopCoroutine(m_SmokeCoroutine);
        m_SmokeCoroutine = StartCoroutine(PlaySmokeAfterDelay());
    }
    private IEnumerator PlaySmokeAfterDelay()
    {
        yield return new WaitForSeconds(m_WaitingTimeToPlaySmokeParticleSystem);
        if (m_SmokeParticleSystem != null)
        {
            m_SmokeParticleSystem.Play();
            m_LiquidVolume.sparklingAmount = m_BoilingPoint;
        }       
    }

}
