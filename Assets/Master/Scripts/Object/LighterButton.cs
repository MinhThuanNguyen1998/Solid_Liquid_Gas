using UnityEngine;
using DG.Tweening;
public class LighterButton : MonoBehaviour
{
    [SerializeField] private LighterTrigger m_LighterTrigger;
    private Vector3 m_OriginalScale;
    private Tween m_ClickTween;
    private float m_DurationScale = 0.03f;

    private void Awake()
    {
        m_OriginalScale = transform.localScale;
    }
    private void OnMouseDown()
    {
        //Debug.Log("Click");
        m_LighterTrigger.TurnOnLighter();
        AudioMainManager.Instance.PlayOnShot(SoundType.TurnOnLighter);
        PlayClickAnimation();
    }
    private void OnMouseUp()
    {
        //Debug.Log("UnClick");
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
}
