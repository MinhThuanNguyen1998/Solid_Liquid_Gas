using System.Collections;
using LiquidVolumeFX;
using UnityEngine;
using static Unity.VisualScripting.Member;
using static UnityEngine.GraphicsBuffer;

public class PipetTrigger : BaseTrigger
{
    [SerializeField] private LiquidVolume m_LiquidVolumePipet;
    [SerializeField] private LiquidVolume m_LiquidVolumeTube;
    [SerializeField] private StepLiquid m_StepLiquid;
    private float m_DurationTime = 4f;
    private float m_MinLevelVolume = 0f;
    private float m_MaxLevelVolume = 0.5f;

    private bool m_IsPipetFilled = false;
    private bool m_IsInTrigger = false;
    private bool m_IsProcessing = false;
    private Collider m_CurrentCollider;
    protected override void OnEnter(Collider other)
    {
        m_CurrentCollider = other;
        m_IsInTrigger = true;
    }
    protected override void OnExit(Collider other)
    {
        if (other == m_CurrentCollider)
        {
            m_CurrentCollider = null;
            m_IsInTrigger = false;
        }
    }
    public void TriggerActionByButton()
    {
        if (m_IsProcessing) return;
        if (!m_IsInTrigger || m_CurrentCollider == null) return;
        // ========= FLASK =========
        if (m_CurrentCollider.CompareTag("Flask"))
        {
            if (m_LiquidVolumePipet.level >= m_MaxLevelVolume ||
                m_LiquidVolumeTube.level >= m_MaxLevelVolume) return;

            m_IsPipetFilled = true;
            StartCoroutine(ChangeLiquidLevel(m_LiquidVolumePipet, m_MaxLevelVolume, m_DurationTime));
            m_StepLiquid?.GoToNextStep();
        }
        // ========= TUBE =========
        else if (m_CurrentCollider.CompareTag("Tube"))
        {
            if (!m_IsPipetFilled || m_LiquidVolumeTube.level >= m_MaxLevelVolume) return;

            StartCoroutine(ChangeLiquidLevel(m_LiquidVolumePipet, m_MinLevelVolume, m_DurationTime));
            StartCoroutine(ChangeLiquidLevel(m_LiquidVolumeTube, m_MaxLevelVolume, m_DurationTime));

            m_StepLiquid?.GoToNextStep();
            MagnifyingManager.Instance.ActiveMagnifyingObject(true);
        }
    }
    IEnumerator ChangeLiquidLevel(LiquidVolume liquid, float targetLevel, float duration)
    {
        MouseDragLock.Block();
        m_IsProcessing = true;
        AudioMainManager.Instance.PlayOnShot(SoundType.Liquid);
        float start = liquid.level;
        float t = 0;
        while (t < duration)
        {
            t += Time.deltaTime;
            liquid.level = Mathf.Lerp(start, targetLevel, t / duration);
            yield return null;
        }
        liquid.level = targetLevel;
        MouseDragLock.Unblock();
        m_IsProcessing = false;
    }
    
}
