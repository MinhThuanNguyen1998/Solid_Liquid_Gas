using UnityEngine;
using DG.Tweening;
public class LighterButton : MonoBehaviour
{
    private Vector3 m_OriginalScale;
    private Tween m_ClickTween;
    private float m_DurationScale = 0.04f;
    private void Awake()
    {
        m_OriginalScale = transform.localScale;
    }

    private void OnMouseDown()
    {
       Debug.Log("Click");
       PlayClickAnimation();
    }
    private void OnMouseUp()
    {
        Debug.Log("UnClick");
    }
    private void PlayClickAnimation()
    {
        if (m_ClickTween != null && m_ClickTween.IsActive())
            m_ClickTween.Kill();

        float smallScale = 0.001f;
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
