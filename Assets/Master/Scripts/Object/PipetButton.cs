using UnityEngine;
using DG.Tweening;
public class PipetButton : MonoBehaviour
{
    [SerializeField] private PipetTrigger m_PipetTrigger;
    private Vector3 m_OriginalScale;
    private Tween m_ClickTween;
    private void Awake()
    {
        m_OriginalScale = transform.localScale;
    }

    private void OnMouseDown()
    {
        //Debug.Log("Click");
        m_PipetTrigger.TriggerActionByButton();
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

        float smallScale = 0.85f;
        m_ClickTween = transform
            .DOScale(m_OriginalScale * smallScale, 0.08f)
            .SetEase(Ease.OutQuad)
            .OnComplete(() =>
            {
                transform.DOScale(m_OriginalScale, 0.08f)
                        .SetEase(Ease.OutQuad);
            });
    }
}
