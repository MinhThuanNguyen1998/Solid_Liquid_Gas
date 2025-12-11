using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.WSA;
using static UnityEngine.UI.Image;

public class BottleTrigger : BaseTrigger
{
    [SerializeField] private StepGas m_StepGas;
    [SerializeField] GameObject m_ParentBottle;
    [SerializeField] private Transform m_AnchorPoint;
    [SerializeField] private GameObject m_GasStructureObject;
    [SerializeField] private GameObject m_LiquidStructureObject;

    [Header("Material")]
    [SerializeField] private Material m_OriginMaterial;
    [SerializeField] private Material m_EffectAirMaterial;
    [SerializeField] private Material m_EffectAirMaterial1;
    [SerializeField] Renderer m_BottleRenderer;

    private float m_WaitingTimeToStartCoroutine = 5f;
    private float m_Duration = 10f;

    private void Awake() => SetStructureState(false, false);
    protected override void OnEnter(Collider other)
    {
        if (other.CompareTag("Lid"))
        {
            other.transform.SetParent(m_ParentBottle.transform);
            other.transform.DOMove(m_AnchorPoint.position, 1f)
            .SetEase(Ease.InOutSine)
            .OnComplete(() =>
            {
                other.transform.localPosition = m_AnchorPoint.localPosition;
            });
            m_StepGas?.GoToNextStep();
            StartCoroutine(CoroutineBlend3Materials(m_OriginMaterial, m_EffectAirMaterial,m_EffectAirMaterial1, m_Duration));
        };
    }

    private IEnumerator CoroutineBlend3Materials(Material start, Material mid, Material end, float duration)
    {
        yield return new WaitForSeconds(m_WaitingTimeToStartCoroutine);
        float halfDuration = duration / 2f;
        MagnifyingManager.Instance.ActiveMagnifyingObject(true);
        SetStructureState(true, false);
        yield return StartCoroutine(BlendMaterial(start, mid, duration));
        SetStructureState(false, true);
        yield return StartCoroutine(BlendMaterial(mid, end, duration));
        

    }
    private IEnumerator BlendMaterial(Material from, Material to, float time)
    {
        float t = 0f;
        while (t < time)
        {
            float lerp = t / time;
            t += Time.deltaTime;
            m_BottleRenderer.material.Lerp(from, to, lerp);
            yield return null;
        }
        // Gán mid Material sau Phase 1
        m_BottleRenderer.material = to;
    }
    private void SetStructureState(bool solid, bool liquid)
    {
        m_GasStructureObject.SetActive(solid);
        m_LiquidStructureObject.SetActive(liquid);
    }
}
