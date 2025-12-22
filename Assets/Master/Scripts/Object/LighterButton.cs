using UnityEngine;
using DG.Tweening;
public class LighterButton : MonoBehaviour
{
    [SerializeField] private LighterTrigger m_LighterTrigger;
    [SerializeField] private ParticleSystem m_FireParticleSystem;

    private Vector3 m_OriginalScale;
    private Tween m_ClickTween;
    private float m_DurationScale = 0.03f;
    public bool IsFireOn => m_FireParticleSystem.isPlaying;
    private void Awake()
    {
        m_OriginalScale = transform.localScale;
        m_FireParticleSystem.Stop();
    }
    private void OnMouseDown()
    {
        AudioMainManager.Instance.PlayOnShot(SoundType.TurnOnLighter);
        PlayClickAnimation();
        ToggleFire();
    }
    private void PlayClickAnimation()
    {
        if (m_ClickTween != null && m_ClickTween.IsActive())
            m_ClickTween.Kill();
        float smallScale = 0.1f;
        m_ClickTween = transform
            .DOScale(m_OriginalScale * smallScale, m_DurationScale)
            .SetEase(Ease.OutQuad)
            .OnComplete(() =>
            {
                transform.DOScale(m_OriginalScale, m_DurationScale)
                        .SetEase(Ease.OutQuad);
            });
    }
    private void ToggleFire()
    {
        if (IsFireOn) m_FireParticleSystem.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        else
            m_FireParticleSystem.Play();
            m_LighterTrigger.TurnOnLighter();
    }
}
